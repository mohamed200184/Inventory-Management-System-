import { EntityGrid } from "@serenity-is/corelib";
import { CategoriesColumns, CategoriesRow, CategoriesService } from "../../ServerTypes/Inventory";
import { nsInventory } from "../../ServerTypes/Namespaces";
import { CategoriesDialog } from "./CategoriesDialog";

export class CategoriesGrid extends EntityGrid<CategoriesRow, any> {
    static override[Symbol.typeInfo] = this.registerClass(nsInventory);

    protected override getColumnsKey() { return CategoriesColumns.columnsKey; }
    protected override getDialogType() { return CategoriesDialog; }
    protected override getIdProperty() { return CategoriesRow.idProperty; }
    protected override getLocalTextPrefix() { return CategoriesRow.localTextPrefix; }
    protected override getService() { return CategoriesService.baseUrl; }

    constructor(props: any) {
        super(props);
    }

    protected override getDefaultSortBy() {
        return [CategoriesRow.Fields.CategoryName];
    }
}
