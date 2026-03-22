using MyRow = PingSysInventory.Inventory.ProductsRow;

namespace PingSysInventory.Inventory;

public interface IProductsRetrieveHandler : IRetrieveHandler<MyRow> { }

public class ProductsRetrieveHandler(IRequestContext context)
    : RetrieveRequestHandler<MyRow>(context), IProductsRetrieveHandler
{
}
