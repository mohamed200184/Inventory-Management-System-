using MyRow = PingSysInventory.Inventory.CategoriesRow;

namespace PingSysInventory.Inventory;

public interface ICategoriesRetrieveHandler : IRetrieveHandler<MyRow> { }

public class CategoriesRetrieveHandler(IRequestContext context)
    : RetrieveRequestHandler<MyRow>(context), ICategoriesRetrieveHandler
{
}
