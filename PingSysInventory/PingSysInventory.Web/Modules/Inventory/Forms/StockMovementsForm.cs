using PingSysInventory.Inventory;

namespace PingSysInventory.Inventory.Forms;

[FormScript("Inventory.StockMovements")]
[BasedOnRow(typeof(StockMovementsRow), CheckNames = true)]
public class StockMovementsForm
{
    public int ProductId { get; set; }
    public int MovementType { get; set; }
    public int Quantity { get; set; }
    public DateTime MovementDate { get; set; }
    public string Notes { get; set; }
}
