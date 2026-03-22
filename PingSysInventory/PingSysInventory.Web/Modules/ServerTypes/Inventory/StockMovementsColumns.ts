import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { StockMovementsRow } from "./StockMovementsRow";

export interface StockMovementsColumns {
    MovementId: Column<StockMovementsRow>;
    ProductName: Column<StockMovementsRow>;
    MovementType: Column<StockMovementsRow>;
    Quantity: Column<StockMovementsRow>;
    MovementDate: Column<StockMovementsRow>;
    Notes: Column<StockMovementsRow>;
    InsertUserId: Column<StockMovementsRow>;
}

export class StockMovementsColumns extends ColumnsBase<StockMovementsRow> {
    static readonly columnsKey = 'Inventory.StockMovements';
    static readonly Fields = fieldsProxy<StockMovementsColumns>();
}