using MyRow = PingSysInventory.Inventory.CategoriesRow;

namespace PingSysInventory.Inventory;

public interface ICategoriesSaveHandler : ISaveHandler<MyRow> { }

public class CategoriesSaveHandler(IRequestContext context)
    : SaveRequestHandler<MyRow>(context), ICategoriesSaveHandler
{
}
