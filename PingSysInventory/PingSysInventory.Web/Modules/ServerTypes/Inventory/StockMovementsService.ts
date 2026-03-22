import { DeleteRequest, DeleteResponse, ListRequest, ListResponse, RetrieveRequest, RetrieveResponse, SaveRequest, SaveResponse, ServiceOptions, serviceRequest } from "@serenity-is/corelib";
import { StockMovementsRow } from "./StockMovementsRow";

export namespace StockMovementsService {
    export const baseUrl = 'Inventory/StockMovements';

    export declare function Create(request: SaveRequest<StockMovementsRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<StockMovementsRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<StockMovementsRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<StockMovementsRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<StockMovementsRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<StockMovementsRow>>;

    export const Methods = {
        Create: "Inventory/StockMovements/Create",
        Update: "Inventory/StockMovements/Update",
        Delete: "Inventory/StockMovements/Delete",
        Retrieve: "Inventory/StockMovements/Retrieve",
        List: "Inventory/StockMovements/List"
    } as const;

    [
        'Create',
        'Update',
        'Delete',
        'Retrieve',
        'List'
    ].forEach(x => {
        (<any>StockMovementsService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}