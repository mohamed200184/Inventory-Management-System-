using MyRow = PingSysInventory.Inventory.CategoriesRow;

namespace PingSysInventory.Inventory;

public interface ICategoriesDeleteHandler : IDeleteHandler<MyRow> { }

public class CategoriesDeleteHandler(IRequestContext context)
    : DeleteRequestHandler<MyRow>(context), ICategoriesDeleteHandler
{
}
