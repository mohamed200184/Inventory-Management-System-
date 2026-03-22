namespace PingSysInventory.Inventory;

[ConnectionKey("Default"), Module("Inventory"), TableName("Categories")]
[DisplayName("Category"), InstanceName("Category")]
[ReadPermission(PermissionKeys.General)]
[ModifyPermission(PermissionKeys.General)]
[LookupScript("Inventory.Categories", Permission = PermissionKeys.General)]
public sealed class CategoriesRow : Row<CategoriesRow.RowFields>, IIdRow, INameRow
{
    [DisplayName("Category Id"), Identity, IdProperty]
    public int? CategoryId { get => fields.CategoryId[this]; set => fields.CategoryId[this] = value; }

    [DisplayName("Category Name"), Size(100), NotNull, QuickSearch, NameProperty, LookupInclude]
    public string CategoryName { get => fields.CategoryName[this]; set => fields.CategoryName[this] = value; }

    [DisplayName("Active"), NotNull, DefaultValue(true)]
    public bool? IsActive { get => fields.IsActive[this]; set => fields.IsActive[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field CategoryId;
        public StringField CategoryName;
        public BooleanField IsActive;
    }
}
