import { fieldsProxy, getLookup, getLookupAsync } from "@serenity-is/corelib";

export interface ProductsRow {
    ProductId?: number;
    ProductCode?: string;
    ProductName?: string;
    CategoryId?: number;
    CategoryName?: string;
    CurrentStock?: number;
    MinimumStock?: number;
    UnitPrice?: number;
    IsActive?: boolean;
    StockStatus?: string;
    RowVersion?: number[];
}

export abstract class ProductsRow {
    static readonly idProperty = 'ProductId';
    static readonly nameProperty = 'ProductName';
    static readonly localTextPrefix = 'Inventory.Products';
    static readonly lookupKey = 'Inventory.Products';

    /** @deprecated use getLookupAsync instead */
    static getLookup() { return getLookup<ProductsRow>('Inventory.Products') }
    static async getLookupAsync() { return getLookupAsync<ProductsRow>('Inventory.Products') }

    static readonly deletePermission = 'Inventory:General';
    static readonly insertPermission = 'Inventory:General';
    static readonly readPermission = 'Inventory:General';
    static readonly updatePermission = 'Inventory:General';

    static readonly Fields = fieldsProxy<ProductsRow>();
}