using PingSysInventory.Inventory;

namespace PingSysInventory.Inventory.Forms;

[FormScript("Inventory.Categories")]
[BasedOnRow(typeof(CategoriesRow), CheckNames = true)]
public class CategoriesForm
{
    public string CategoryName { get; set; }
    public bool IsActive { get; set; }
}
