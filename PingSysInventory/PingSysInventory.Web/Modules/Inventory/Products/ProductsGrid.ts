import { EntityGrid } from "@serenity-is/corelib";
import { ProductsColumns, ProductsRow, ProductsService } from "../../ServerTypes/Inventory";
import { nsInventory } from "../../ServerTypes/Namespaces";
import { ProductsDialog } from "./ProductsDialog";

export class ProductsGrid extends EntityGrid<ProductsRow, any> {
    static override[Symbol.typeInfo] = this.registerClass(nsInventory);

    protected override getColumnsKey() { return ProductsColumns.columnsKey; }
    protected override getDialogType() { return ProductsDialog; }
    protected override getIdProperty() { return ProductsRow.idProperty; }
    protected override getLocalTextPrefix() { return ProductsRow.localTextPrefix; }
    protected override getService() { return ProductsService.baseUrl; }

    constructor(props: any) {
        super(props);
    }

    protected override getDefaultSortBy() {
        return [ProductsRow.Fields.ProductName];
    }

    protected override createColumns() {
        let cols = super.createColumns();
        // StockStatus is plain text from server ("Low Stock" or ""). Do not inject HTML here —
        // the grid escapes HTML in cells, so <span class="badge"> would show as visible text.
        let stock = cols.find(x => x.field === "StockStatus");
        if (stock) {
            stock.format = ctx => {
                if (!ctx.value) return "";
                return ctx.escape(String(ctx.value));
            };
        }
        return cols;
    }
}
