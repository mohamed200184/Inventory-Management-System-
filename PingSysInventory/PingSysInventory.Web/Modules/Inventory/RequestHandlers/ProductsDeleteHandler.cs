using MyRow = PingSysInventory.Inventory.ProductsRow;

namespace PingSysInventory.Inventory;

public interface IProductsDeleteHandler : IDeleteHandler<MyRow> { }

public class ProductsDeleteHandler(IRequestContext context)
    : DeleteRequestHandler<MyRow>(context), IProductsDeleteHandler
{
}
