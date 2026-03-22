using MyRow = PingSysInventory.Inventory.StockMovementsRow;

namespace PingSysInventory.Inventory;

public interface IStockMovementsDeleteHandler : IDeleteHandler<MyRow> { }

public class StockMovementsDeleteHandler(IRequestContext context)
    : DeleteRequestHandler<MyRow>(context), IStockMovementsDeleteHandler
{
    protected override void ValidateRequest()
    {
        base.ValidateRequest();

        throw new ValidationError("Inventory.MovementsNotDeletable", "MovementsNotDeletable",
            "Stock movements cannot be deleted.");
    }
}
