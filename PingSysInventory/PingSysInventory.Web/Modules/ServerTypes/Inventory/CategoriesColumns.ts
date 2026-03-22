import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { CategoriesRow } from "./CategoriesRow";

export interface CategoriesColumns {
    CategoryId: Column<CategoriesRow>;
    CategoryName: Column<CategoriesRow>;
    IsActive: Column<CategoriesRow>;
}

export class CategoriesColumns extends ColumnsBase<CategoriesRow> {
    static readonly columnsKey = 'Inventory.Categories';
    static readonly Fields = fieldsProxy<CategoriesColumns>();
}