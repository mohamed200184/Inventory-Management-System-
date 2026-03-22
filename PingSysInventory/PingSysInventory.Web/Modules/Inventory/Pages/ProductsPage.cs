using PingSysInventory.Inventory;

namespace PingSysInventory.Inventory.Pages;

[PageAuthorize(typeof(ProductsRow))]
public class ProductsPage : Controller
{
    [Route("Inventory/Products")]
    public ActionResult Index()
    {
        return this.GridPage("@/Inventory/Products/ProductsPage",
            ProductsRow.Fields.PageTitle());
    }
}
