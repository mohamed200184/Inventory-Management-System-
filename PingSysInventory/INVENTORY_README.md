# Inventory module (PingSys task)

This Serene project includes an **Inventory** module with:

- **Categories** – CRUD
- **Products** – CRUD, category lookup, quick filter by category, **Low Stock** badge (SQL expression + red badge in grid)
- **Stock Movements** – create only (no edit/delete of movements), **In/Out** badges, server-side stock rules

## Database

1. Create/use database **`PingSysInventory_Default_v1`** (matches `appsettings.json` → `Data:Default`).
2. Run the SQL script from your task repo: `E:\ProjectCruser\database.sql` (creates `Categories`, `Products`, `StockMovements` + seed).
3. Grant permission **`Inventory:General`** to your admin role (see `E:\ProjectCruser\grant_inventory_permission.sql`).

## Build & run

From `PingSysInventory.Web`:

```powershell
dotnet build
dotnet run
```

Open **Inventory** in the left menu (Categories, Products, Stock Movements).

## Stock rules (server)

Implemented in `StockMovementsSaveHandler`:

- **Out**: rejects if `CurrentStock < Quantity` with message like `Not enough stock. Available: X`.
- **After insert**: updates `Products.CurrentStock` with **`RowVersion`** check; if no row updated → concurrency message and transaction rolls back.

## Notes

- **Server typings**: `dotnet build` runs `sergen servertypings`. If you regenerate typings and get conflicts with hand-written `Modules/ServerTypes/Inventory/*.ts`, prefer the generated files and adjust imports.
- **Products.CurrentStock** is **read-only** on the product form; stock changes are done via **Stock Movements**.
