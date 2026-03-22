-- =============================================
-- Simple Inventory Management Database Script
-- Matches the PingSys Serenity.is technical task
-- =============================================

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

IF OBJECT_ID('dbo.StockMovements', 'U') IS NOT NULL
    DROP TABLE dbo.StockMovements;
GO

IF OBJECT_ID('dbo.Products', 'U') IS NOT NULL
    DROP TABLE dbo.Products;
GO

IF OBJECT_ID('dbo.Categories', 'U') IS NOT NULL
    DROP TABLE dbo.Categories;
GO

-- =============================================
-- 1. Categories
-- =============================================

CREATE TABLE dbo.Categories
(
    CategoryId   INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Categories PRIMARY KEY,
    CategoryName NVARCHAR(100)     NOT NULL,
    IsActive     BIT               NOT NULL CONSTRAINT DF_Categories_IsActive DEFAULT (1)
);
GO

-- =============================================
-- 2. Products (with RowVersion for concurrency)
-- =============================================

CREATE TABLE dbo.Products
(
    ProductId     INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Products PRIMARY KEY,
    ProductCode   NVARCHAR(20)      NOT NULL,
    ProductName   NVARCHAR(200)     NOT NULL,
    CategoryId    INT               NOT NULL,
    CurrentStock  INT               NOT NULL CONSTRAINT DF_Products_CurrentStock DEFAULT (0),
    MinimumStock  INT               NOT NULL CONSTRAINT DF_Products_MinimumStock DEFAULT (0),
    UnitPrice     DECIMAL(18,2)     NOT NULL CONSTRAINT DF_Products_UnitPrice DEFAULT (0),
    IsActive      BIT               NOT NULL CONSTRAINT DF_Products_IsActive DEFAULT (1),
    RowVersion    ROWVERSION        NOT NULL
);
GO

ALTER TABLE dbo.Products
ADD CONSTRAINT UQ_Products_ProductCode UNIQUE (ProductCode);
GO

ALTER TABLE dbo.Products
ADD CONSTRAINT FK_Products_Categories
    FOREIGN KEY (CategoryId) REFERENCES dbo.Categories (CategoryId);
GO

-- Helpful indexes for grids and lookups
CREATE NONCLUSTERED INDEX IX_Products_Category_Active
ON dbo.Products (IsActive, CategoryId, ProductName);
GO

CREATE NONCLUSTERED INDEX IX_Products_CurrentStock
ON dbo.Products (CurrentStock);
GO

-- =============================================
-- 3. StockMovements
-- =============================================

CREATE TABLE dbo.StockMovements
(
    MovementId    INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_StockMovements PRIMARY KEY,
    ProductId     INT               NOT NULL,
    MovementType  TINYINT           NOT NULL, -- 1 = In, 2 = Out
    Quantity      INT               NOT NULL CONSTRAINT CK_StockMovements_Quantity_Positive CHECK (Quantity > 0),
    MovementDate  DATETIME          NOT NULL CONSTRAINT DF_StockMovements_MovementDate DEFAULT (GETDATE()),
    Notes         NVARCHAR(500)     NULL,
    InsertUserId  INT               NOT NULL
);
GO

ALTER TABLE dbo.StockMovements
ADD CONSTRAINT FK_StockMovements_Products
    FOREIGN KEY (ProductId) REFERENCES dbo.Products (ProductId);
GO

CREATE NONCLUSTERED INDEX IX_StockMovements_Product_Date
ON dbo.StockMovements (ProductId, MovementDate);
GO

CREATE NONCLUSTERED INDEX IX_StockMovements_Type_Date
ON dbo.StockMovements (MovementType, MovementDate);
GO

-- =============================================
-- 4. Seed Data (for testing)
-- =============================================

-- Categories
INSERT INTO dbo.Categories (CategoryName, IsActive)
VALUES
    (N'Electronics', 1),
    (N'Groceries',   1),
    (N'Stationery',  1);
GO

-- Products
INSERT INTO dbo.Products
    (ProductCode, ProductName, CategoryId, CurrentStock, MinimumStock, UnitPrice, IsActive)
VALUES
    (N'EL-001', N'Laptop',        1, 10,  2, 15000.00, 1),
    (N'EL-002', N'Wireless Mouse',1,  2,  5,   300.00, 1), -- Low stock case
    (N'GR-001', N'Rice 5kg',      2,  0, 10,   150.00, 1), -- Out of stock case
    (N'ST-001', N'Blue Pen',      3,100, 20,     5.00, 1),
    (N'ST-002', N'Notebook A5',   3, 50, 10,    20.00, 1);
GO

-- Simple stock movements for testing
-- Assuming a system user with ID = 1
INSERT INTO dbo.StockMovements
    (ProductId, MovementType, Quantity, MovementDate, Notes, InsertUserId)
VALUES
    -- Laptop: stock in then out
    (1, 1, 5,  DATEADD(DAY, -5, GETDATE()), N'Initial stock in', 1),
    (1, 2, 3,  DATEADD(DAY, -3, GETDATE()), N'Sold 3 units',     1),
    -- Wireless Mouse: almost low stock
    (2, 1, 10, DATEADD(DAY, -7, GETDATE()), N'Initial stock in', 1),
    (2, 2, 8,  DATEADD(DAY, -1, GETDATE()), N'Sold 8 units',     1),
    -- Blue Pen: large quantity
    (4, 1, 100,DATEADD(DAY, -10, GETDATE()),N'Initial stock in', 1);
GO

-- NOTE:
-- CurrentStock values above are set manually to desired test levels.
-- In a real system, you would prefer to recompute them from StockMovements or
-- keep them consistent through SaveHandler logic only.

-- Grant Inventory:General to the default "Administrators" role (RoleId = 1) in Serenity Default DB.
-- Run this on PingSysInventory_Default_v1 AFTER the app has created Serenity tables (Users, Roles, RolePermissions).
-- Adjust RoleId if your admin role is different.





-- 1) إنشاء دور إذا لم يكن موجودًا
IF NOT EXISTS (SELECT 1 FROM dbo.Roles WHERE RoleName = N'Administrators')
BEGIN
    INSERT INTO dbo.Roles (RoleName)
    VALUES (N'Administrators');

    SET @RoleId = SCOPE_IDENTITY();
END
ELSE
BEGIN
    SELECT @RoleId = RoleId FROM dbo.Roles WHERE RoleName = N'Administrators';
END

-- 2) ربط المستخدم admin بالدور
IF NOT EXISTS (
    SELECT 1 FROM dbo.UserRoles
    WHERE UserId = 1 AND RoleId = @RoleId
)
BEGIN
    INSERT INTO dbo.UserRoles (UserId, RoleId)
    VALUES (1, @RoleId);
END

-- 3) صلاحية المخزون للدور
IF NOT EXISTS (
    SELECT 1 FROM dbo.RolePermissions
    WHERE RoleId = @RoleId AND PermissionKey = N'Inventory:General'
)
BEGIN
    INSERT INTO dbo.RolePermissions (RoleId, PermissionKey)
    VALUES (@RoleId, N'Inventory:General');
END

SELECT @RoleId AS CreatedOrExistingRoleId;

-----------------------------
SELECT * FROM dbo.Roles;
SELECT * FROM dbo.UserRoles;
SELECT * FROM dbo.RolePermissions WHERE PermissionKey = N'Inventory:General';

UPDATE dbo.Users
SET IsActive = 1
WHERE Email = N'ms8789287@gmail.com';
------------------------------------------------
SELECT UserId, Username, Email, IsActive, Source
FROM dbo.Users
WHERE Email = N'ms8789287@gmail.com';

------------------------------------
DECLARE @uid INT =
(
    SELECT TOP 1 UserId FROM dbo.Users WHERE Email = N'ms8789287@gmail.com'
);

DECLARE @rid INT =
(
    SELECT TOP 1 RoleId FROM dbo.Roles WHERE RoleName = N'Administrators'
);

IF @uid IS NOT NULL AND @rid IS NOT NULL
   AND NOT EXISTS (SELECT 1 FROM dbo.UserRoles WHERE UserId = @uid AND RoleId = @rid)
BEGIN
    INSERT INTO dbo.UserRoles (UserId, RoleId)
    VALUES (@uid, @rid);
END