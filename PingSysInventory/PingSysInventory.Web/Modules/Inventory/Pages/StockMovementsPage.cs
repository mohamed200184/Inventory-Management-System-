using PingSysInventory.Inventory;

namespace PingSysInventory.Inventory.Pages;

[PageAuthorize(typeof(StockMovementsRow))]
public class StockMovementsPage : Controller
{
    [Route("Inventory/StockMovements")]
    public ActionResult Index()
    {
        return this.GridPage("@/Inventory/StockMovements/StockMovementsPage",
            StockMovementsRow.Fields.PageTitle());
    }
}
