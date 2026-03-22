using PingSysInventory.Inventory;

namespace PingSysInventory.Inventory.Forms;

[ColumnsScript("Inventory.Categories")]
[BasedOnRow(typeof(CategoriesRow), CheckNames = true)]
public class CategoriesColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int CategoryId { get; set; }

    [EditLink, Width(250)]
    public string CategoryName { get; set; }

    [Width(80)]
    public bool IsActive { get; set; }
}
