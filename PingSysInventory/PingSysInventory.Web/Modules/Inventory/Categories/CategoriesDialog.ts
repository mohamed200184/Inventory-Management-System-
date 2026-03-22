import { EntityDialog } from "@serenity-is/corelib";
import { CategoriesForm, CategoriesRow, CategoriesService } from "../../ServerTypes/Inventory";
import { nsInventory } from "../../ServerTypes/Namespaces";

export class CategoriesDialog extends EntityDialog<CategoriesRow, any> {
    static override[Symbol.typeInfo] = this.registerClass(nsInventory);

    protected override getFormKey() { return CategoriesForm.formKey; }
    protected override getIdProperty() { return CategoriesRow.idProperty; }
    protected override getLocalTextPrefix() { return CategoriesRow.localTextPrefix; }
    protected override getNameProperty() { return CategoriesRow.nameProperty; }
    protected override getService() { return CategoriesService.baseUrl; }

    protected form = new CategoriesForm(this.idPrefix);
}
