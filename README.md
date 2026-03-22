# Inventory Management System

**Inventory Management System** built with **Serenity.is** (.NET) and **SQL Server** — categories, products, stock movements (In/Out), server-side stock validation, and optimistic concurrency using **`RowVersion`**.

---

## Features

- CRUD for **Categories**, **Products**, and **Stock Movements**
- **Stock Out** rejected when `CurrentStock < Quantity`
- **Optimistic concurrency** on `Products` via `RowVersion`
- **Low Stock** indicator via computed `StockStatus` on products
- **Indexes** and **seed data** in the SQL script
- **Pagination** in grids via Serenity `ListRequest` (Skip/Take)

---

## Repository layout

Your layout may vary; a typical structure:

```
 database.sql
grant_inventory_permission.sql
README.md
```

Runnable Serenity app (if included in the repo or a sibling path):

```
PingSysInventory/
 PingSysInventory.Web/
     Modules/Inventory/    # Rows, Endpoints, SaveHandlers, TypeScript UI
```

---

## Prerequisites

- **Windows** (recommended for Serenity development)
- **[.NET SDK](https://dotnet.microsoft.com/download)** (e.g. 8.x, match your project)
- **[SQL Server](https://www.microsoft.com/sql-server)** (or compatible)
- **[Node.js](https://nodejs.org/)** (for TypeScript tooling when needed)
- **Git**

---

## Quick start

### 1) Database

1. Create **`PingSysInventory_Default_v1`** (or a name that matches `ConnectionStrings` in `appsettings.json`).
2. Run **`database.sql`** against the **Default** database only (main app DB).
3. After the app has run once so Serenity tables exist (**Users**, **Roles**, …), run **`grant_inventory_permission.sql`** or grant **`Inventory:General`** via the admin UI.

> **Important:** Point **Northwind** to a **separate** database from **Default** in `appsettings.json` to avoid a `Categories` table name clash with the Northwind sample.

### 2) Web app (Serenity)

```bash
cd PingSysInventory.Web
dotnet restore
dotnet build
dotnet run
```

Open the URL shown in the console, sign in, then use **Inventory** → **Categories / Products / Stock Movements**.

---

## Configuration and secrets

- Do **not** commit real passwords or production connection strings in `appsettings.json`.
- Prefer **`appsettings.Development.json`** locally (often gitignored) or an **`appsettings.example.json`** template without secrets.

---

## Stock logic (where it lives)

| Path | Role |
| `Modules/Inventory/RequestHandlers/StockMovementsSaveHandler.cs` | Validates **Out** quantity, updates `CurrentStock` after **In/Out**, conditional update with **`WHERE RowVersion = ?`**; on failure: concurrency or insufficient stock message |
| `Modules/Inventory/ProductsRow.cs` | **`StockStatus`** SQL expression (**Low Stock**), **`RowVersion`** field |
| `database.sql` | **`RowVersion ROWVERSION`** column on `Products` |

---


## Quick manual tests

1. **Insufficient stock:** product stock 10 → Out 8 succeeds → Out 5 fails with not-enough-stock message.
2. **Low stock:** when `CurrentStock < MinimumStock`, **Stock Status** shows **Low Stock**.
3. **Concurrency:** two browsers, same product, overlapping Out — one may fail with concurrency or insufficient stock; stock must not go negative.

---

## Links

- **Serenity** — [https://serenity.is](https://serenity.is)

---

## Author

**mohamed200184** — [Inventory-Management-System](https://github.com/mohamed200184/Inventory-Management-System-)
