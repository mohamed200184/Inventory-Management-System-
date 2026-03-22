using PingSysInventory.Inventory;

namespace PingSysInventory.Inventory.Forms;

[ColumnsScript("Inventory.StockMovements")]
[BasedOnRow(typeof(StockMovementsRow), CheckNames = true)]
public class StockMovementsColumns
{
    [DisplayName("Db.Shared.RecordId"), AlignRight]
    public int MovementId { get; set; }

    [Width(220)]
    public string ProductName { get; set; }

    [Width(100)]
    public int MovementType { get; set; }

    [Width(80), AlignRight]
    public int Quantity { get; set; }

    [Width(140)]
    public DateTime MovementDate { get; set; }

    [Width(200)]
    public string Notes { get; set; }

    [Width(90), AlignRight]
    public int InsertUserId { get; set; }
}
