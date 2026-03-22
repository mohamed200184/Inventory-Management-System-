import { EntityDialog } from "@serenity-is/corelib";
import { StockMovementsForm, StockMovementsRow, StockMovementsService } from "../../ServerTypes/Inventory";
import { nsInventory } from "../../ServerTypes/Namespaces";

export class StockMovementsDialog extends EntityDialog<StockMovementsRow, any> {
    static override[Symbol.typeInfo] = this.registerClass(nsInventory);

    protected override getFormKey() { return StockMovementsForm.formKey; }
    protected override getIdProperty() { return StockMovementsRow.idProperty; }
    protected override getLocalTextPrefix() { return StockMovementsRow.localTextPrefix; }
    protected override getService() { return StockMovementsService.baseUrl; }

    protected form = new StockMovementsForm(this.idPrefix);
}
