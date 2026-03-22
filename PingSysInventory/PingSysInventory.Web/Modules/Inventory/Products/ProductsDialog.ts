import { EntityDialog } from "@serenity-is/corelib";
import { ProductsForm, ProductsRow, ProductsService } from "../../ServerTypes/Inventory";
import { nsInventory } from "../../ServerTypes/Namespaces";

export class ProductsDialog extends EntityDialog<ProductsRow, any> {
    static override[Symbol.typeInfo] = this.registerClass(nsInventory);

    protected override getFormKey() { return ProductsForm.formKey; }
    protected override getIdProperty() { return ProductsRow.idProperty; }
    protected override getLocalTextPrefix() { return ProductsRow.localTextPrefix; }
    protected override getNameProperty() { return ProductsRow.nameProperty; }
    protected override getService() { return ProductsService.baseUrl; }

    protected form = new ProductsForm(this.idPrefix);
}
