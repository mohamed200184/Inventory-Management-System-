import { BooleanEditor, initFormType, PrefixedContext, StringEditor } from "@serenity-is/corelib";

export interface CategoriesForm {
    CategoryName: StringEditor;
    IsActive: BooleanEditor;
}

export class CategoriesForm extends PrefixedContext {
    static readonly formKey = 'Inventory.Categories';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!CategoriesForm.init) {
            CategoriesForm.init = true;

            var w0 = StringEditor;
            var w1 = BooleanEditor;

            initFormType(CategoriesForm, [
                'CategoryName', w0,
                'IsActive', w1
            ]);
        }
    }
}