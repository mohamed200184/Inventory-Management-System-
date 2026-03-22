using MyRow = PingSysInventory.Inventory.ProductsRow;

namespace PingSysInventory.Inventory;

public interface IProductsListHandler : IListHandler<MyRow> { }

public class ProductsListHandler(IRequestContext context)
    : ListRequestHandler<MyRow>(context), IProductsListHandler
{
}
