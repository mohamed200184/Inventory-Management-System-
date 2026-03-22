using MyRow = PingSysInventory.Inventory.StockMovementsRow;

namespace PingSysInventory.Inventory;

public interface IStockMovementsListHandler : IListHandler<MyRow> { }

public class StockMovementsListHandler(IRequestContext context)
    : ListRequestHandler<MyRow>(context), IStockMovementsListHandler
{
}
