import { fieldsProxy } from "@serenity-is/corelib";

export interface StockMovementsRow {
    MovementId?: number;
    ProductId?: number;
    ProductName?: string;
    MovementType?: number;
    Quantity?: number;
    MovementDate?: string;
    Notes?: string;
    InsertUserId?: number;
}

export abstract class StockMovementsRow {
    static readonly idProperty = 'MovementId';
    static readonly localTextPrefix = 'Inventory.StockMovements';
    static readonly deletePermission = 'Inventory:General';
    static readonly insertPermission = 'Inventory:General';
    static readonly readPermission = 'Inventory:General';
    static readonly updatePermission = 'Inventory:General';

    static readonly Fields = fieldsProxy<StockMovementsRow>();
}