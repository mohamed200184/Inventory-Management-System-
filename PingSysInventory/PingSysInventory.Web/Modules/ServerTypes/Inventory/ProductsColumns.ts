import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { ProductsRow } from "./ProductsRow";

export interface ProductsColumns {
    ProductId: Column<ProductsRow>;
    ProductCode: Column<ProductsRow>;
    ProductName: Column<ProductsRow>;
    CategoryId: Column<ProductsRow>;
    CategoryName: Column<ProductsRow>;
    CurrentStock: Column<ProductsRow>;
    MinimumStock: Column<ProductsRow>;
    UnitPrice: Column<ProductsRow>;
    IsActive: Column<ProductsRow>;
    StockStatus: Column<ProductsRow>;
}

export class ProductsColumns extends ColumnsBase<ProductsRow> {
    static readonly columnsKey = 'Inventory.Products';
    static readonly Fields = fieldsProxy<ProductsColumns>();
}