using PingSysInventory.Inventory;

namespace PingSysInventory.Inventory.Pages;

[PageAuthorize(typeof(CategoriesRow))]
public class CategoriesPage : Controller
{
    [Route("Inventory/Categories")]
    public ActionResult Index()
    {
        return this.GridPage("@/Inventory/Categories/CategoriesPage",
            CategoriesRow.Fields.PageTitle());
    }
}
