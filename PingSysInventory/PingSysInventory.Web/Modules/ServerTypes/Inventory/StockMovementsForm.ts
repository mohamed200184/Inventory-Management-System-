import { DateTimeEditor, EnumEditor, initFormType, IntegerEditor, LookupEditor, PrefixedContext, StringEditor } from "@serenity-is/corelib";

export interface StockMovementsForm {
    ProductId: LookupEditor;
    MovementType: EnumEditor;
    Quantity: IntegerEditor;
    MovementDate: DateTimeEditor;
    Notes: StringEditor;
}

export class StockMovementsForm extends PrefixedContext {
    static readonly formKey = 'Inventory.StockMovements';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!StockMovementsForm.init) {
            StockMovementsForm.init = true;

            var w0 = LookupEditor;
            var w1 = EnumEditor;
            var w2 = IntegerEditor;
            var w3 = DateTimeEditor;
            var w4 = StringEditor;

            initFormType(StockMovementsForm, [
                'ProductId', w0,
                'MovementType', w1,
                'Quantity', w2,
                'MovementDate', w3,
                'Notes', w4
            ]);
        }
    }
}