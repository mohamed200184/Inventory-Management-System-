using PingSysInventory.Inventory;

namespace PingSysInventory.Inventory.Forms;

[ColumnsScript("Inventory.Products")]
[BasedOnRow(typeof(ProductsRow), CheckNames = true)]
public class ProductsColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int ProductId { get; set; }

    [EditLink, Width(120)]
    public string ProductCode { get; set; }

    [EditLink, Width(200)]
    public string ProductName { get; set; }

    [QuickFilter, LookupEditor(typeof(CategoriesRow)), Width(150)]
    public int CategoryId { get; set; }

    [Width(150)]
    public string CategoryName { get; set; }

    [Width(90), AlignRight]
    public int CurrentStock { get; set; }

    [Width(90), AlignRight]
    public int MinimumStock { get; set; }

    [Width(90), AlignRight]
    public decimal UnitPrice { get; set; }

    [Width(70)]
    public bool IsActive { get; set; }

    [Width(120)]
    public string StockStatus { get; set; }
}
