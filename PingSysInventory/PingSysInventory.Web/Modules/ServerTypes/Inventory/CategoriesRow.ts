import { fieldsProxy, getLookup, getLookupAsync } from "@serenity-is/corelib";

export interface CategoriesRow {
    CategoryId?: number;
    CategoryName?: string;
    IsActive?: boolean;
}

export abstract class CategoriesRow {
    static readonly idProperty = 'CategoryId';
    static readonly nameProperty = 'CategoryName';
    static readonly localTextPrefix = 'Inventory.Categories';
    static readonly lookupKey = 'Inventory.Categories';

    /** @deprecated use getLookupAsync instead */
    static getLookup() { return getLookup<CategoriesRow>('Inventory.Categories') }
    static async getLookupAsync() { return getLookupAsync<CategoriesRow>('Inventory.Categories') }

    static readonly deletePermission = 'Inventory:General';
    static readonly insertPermission = 'Inventory:General';
    static readonly readPermission = 'Inventory:General';
    static readonly updatePermission = 'Inventory:General';

    static readonly Fields = fieldsProxy<CategoriesRow>();
}