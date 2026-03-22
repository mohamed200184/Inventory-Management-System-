import { EntityGrid } from "@serenity-is/corelib";
import { StockMovementsColumns, StockMovementsRow, StockMovementsService } from "../../ServerTypes/Inventory";
import { nsInventory } from "../../ServerTypes/Namespaces";
import { StockMovementsDialog } from "./StockMovementsDialog";

export class StockMovementsGrid extends EntityGrid<StockMovementsRow, any> {
    static override[Symbol.typeInfo] = this.registerClass(nsInventory);

    protected override getColumnsKey() { return StockMovementsColumns.columnsKey; }
    protected override getDialogType() { return StockMovementsDialog; }
    protected override getIdProperty() { return StockMovementsRow.idProperty; }
    protected override getLocalTextPrefix() { return StockMovementsRow.localTextPrefix; }
    protected override getService() { return StockMovementsService.baseUrl; }

    constructor(props: any) {
        super(props);
    }

    protected override getDefaultSortBy() {
        return [StockMovementsRow.Fields.MovementDate];
    }

    protected override createColumns() {
        let cols = super.createColumns();
        let mt = cols.find(x => x.field === "MovementType");
        if (mt) {
            mt.format = ctx => {
                if (ctx.value === 1)
                    return `<span class="badge bg-success text-white">In</span>`;
                if (ctx.value === 2)
                    return `<span class="badge bg-danger text-white">Out</span>`;
                return String(ctx.value ?? "");
            };
        }
        return cols;
    }

}
