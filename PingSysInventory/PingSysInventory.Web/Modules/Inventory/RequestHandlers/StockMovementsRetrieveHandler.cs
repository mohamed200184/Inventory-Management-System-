using MyRow = PingSysInventory.Inventory.StockMovementsRow;

namespace PingSysInventory.Inventory;

public interface IStockMovementsRetrieveHandler : IRetrieveHandler<MyRow> { }

public class StockMovementsRetrieveHandler(IRequestContext context)
    : RetrieveRequestHandler<MyRow>(context), IStockMovementsRetrieveHandler
{
}
