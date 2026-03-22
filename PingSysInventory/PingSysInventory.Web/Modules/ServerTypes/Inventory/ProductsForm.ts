import { BooleanEditor, DecimalEditor, initFormType, IntegerEditor, LookupEditor, PrefixedContext, StringEditor } from "@serenity-is/corelib";

export interface ProductsForm {
    ProductCode: StringEditor;
    ProductName: StringEditor;
    CategoryId: LookupEditor;
    CurrentStock: IntegerEditor;
    MinimumStock: IntegerEditor;
    UnitPrice: DecimalEditor;
    IsActive: BooleanEditor;
}

export class ProductsForm extends PrefixedContext {
    static readonly formKey = 'Inventory.Products';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!ProductsForm.init) {
            ProductsForm.init = true;

            var w0 = StringEditor;
            var w1 = LookupEditor;
            var w2 = IntegerEditor;
            var w3 = DecimalEditor;
            var w4 = BooleanEditor;

            initFormType(ProductsForm, [
                'ProductCode', w0,
                'ProductName', w0,
                'CategoryId', w1,
                'CurrentStock', w2,
                'MinimumStock', w2,
                'UnitPrice', w3,
                'IsActive', w4
            ]);
        }
    }
}