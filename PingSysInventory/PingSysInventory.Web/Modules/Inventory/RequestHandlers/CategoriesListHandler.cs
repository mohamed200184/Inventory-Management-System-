using MyRow = PingSysInventory.Inventory.CategoriesRow;

namespace PingSysInventory.Inventory;

public interface ICategoriesListHandler : IListHandler<MyRow> { }

public class CategoriesListHandler(IRequestContext context)
    : ListRequestHandler<MyRow>(context), ICategoriesListHandler
{
}
