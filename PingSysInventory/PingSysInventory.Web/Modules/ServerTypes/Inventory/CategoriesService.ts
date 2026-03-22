import { DeleteRequest, DeleteResponse, ListRequest, ListResponse, RetrieveRequest, RetrieveResponse, SaveRequest, SaveResponse, ServiceOptions, serviceRequest } from "@serenity-is/corelib";
import { CategoriesRow } from "./CategoriesRow";

export namespace CategoriesService {
    export const baseUrl = 'Inventory/Categories';

    export declare function Create(request: SaveRequest<CategoriesRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<CategoriesRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<CategoriesRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<CategoriesRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<CategoriesRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<CategoriesRow>>;

    export const Methods = {
        Create: "Inventory/Categories/Create",
        Update: "Inventory/Categories/Update",
        Delete: "Inventory/Categories/Delete",
        Retrieve: "Inventory/Categories/Retrieve",
        List: "Inventory/Categories/List"
    } as const;

    [
        'Create',
        'Update',
        'Delete',
        'Retrieve',
        'List'
    ].forEach(x => {
        (<any>CategoriesService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}