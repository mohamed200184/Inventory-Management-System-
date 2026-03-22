namespace PingSysInventory.Inventory;

[ConnectionKey("Default"), Module("Inventory"), TableName("Products")]
[DisplayName("Product"), InstanceName("Product")]
[ReadPermission(PermissionKeys.General)]
[ModifyPermission(PermissionKeys.General)]
[LookupScript("Inventory.Products", Permission = PermissionKeys.General)]
public sealed class ProductsRow : Row<ProductsRow.RowFields>, IIdRow, INameRow
{
    [DisplayName("Product Id"), Identity, IdProperty]
    public int? ProductId { get => fields.ProductId[this]; set => fields.ProductId[this] = value; }

    [DisplayName("Product Code"), Size(20), NotNull, QuickSearch, LookupInclude]
    public string ProductCode { get => fields.ProductCode[this]; set => fields.ProductCode[this] = value; }

    [DisplayName("Product Name"), Size(200), NotNull, QuickSearch, NameProperty, LookupInclude]
    public string ProductName { get => fields.ProductName[this]; set => fields.ProductName[this] = value; }

    [DisplayName("Category"), NotNull, ForeignKey(typeof(CategoriesRow)), LeftJoin("jCat")]
    [LookupEditor(typeof(CategoriesRow))]
    public int? CategoryId { get => fields.CategoryId[this]; set => fields.CategoryId[this] = value; }

    [DisplayName("Category"), Expression("jCat.[CategoryName]"), QuickSearch]
    public string CategoryName { get => fields.CategoryName[this]; set => fields.CategoryName[this] = value; }

    [DisplayName("Current Stock"), NotNull, DefaultValue(0)]
    public int? CurrentStock { get => fields.CurrentStock[this]; set => fields.CurrentStock[this] = value; }

    [DisplayName("Minimum Stock"), NotNull, DefaultValue(0)]
    public int? MinimumStock { get => fields.MinimumStock[this]; set => fields.MinimumStock[this] = value; }

    [DisplayName("Unit Price"), NotNull, Scale(2), DefaultValue(0)]
    public decimal? UnitPrice { get => fields.UnitPrice[this]; set => fields.UnitPrice[this] = value; }

    [DisplayName("Active"), NotNull, DefaultValue(true)]
    public bool? IsActive { get => fields.IsActive[this]; set => fields.IsActive[this] = value; }

    [DisplayName("Stock Status"), Expression("(CASE WHEN T0.[CurrentStock] < T0.[MinimumStock] THEN N'Low Stock' ELSE N'' END)")]
    public string StockStatus { get => fields.StockStatus[this]; set => fields.StockStatus[this] = value; }

    [DisplayName("Row Version"), NotNull, Insertable(false), Updatable(false), MinSelectLevel(SelectLevel.Always)]
    public byte[] RowVersion { get => fields.RowVersion[this]; set => fields.RowVersion[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field ProductId;
        public StringField ProductCode;
        public StringField ProductName;
        public Int32Field CategoryId;
        public StringField CategoryName;
        public Int32Field CurrentStock;
        public Int32Field MinimumStock;
        public DecimalField UnitPrice;
        public BooleanField IsActive;
        public StringField StockStatus;
        public ByteArrayField RowVersion;
    }
}
