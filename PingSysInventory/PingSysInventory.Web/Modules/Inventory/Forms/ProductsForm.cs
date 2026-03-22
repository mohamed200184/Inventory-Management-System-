using PingSysInventory.Inventory;

namespace PingSysInventory.Inventory.Forms;

[FormScript("Inventory.Products")]
[BasedOnRow(typeof(ProductsRow), CheckNames = true)]
public class ProductsForm
{
    public string ProductCode { get; set; }
    public string ProductName { get; set; }
    public int CategoryId { get; set; }

    [ReadOnly(true)]
    public int CurrentStock { get; set; }

    public int MinimumStock { get; set; }
    public decimal UnitPrice { get; set; }
    public bool IsActive { get; set; }
}
