using MyRow = PingSysInventory.Inventory.ProductsRow;

namespace PingSysInventory.Inventory;

public interface IProductsSaveHandler : ISaveHandler<MyRow> { }

public class ProductsSaveHandler(IRequestContext context)
    : SaveRequestHandler<MyRow>(context), IProductsSaveHandler
{
}
