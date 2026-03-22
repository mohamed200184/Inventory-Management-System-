namespace PingSysInventory.Inventory;

[ConnectionKey("Default"), Module("Inventory"), TableName("StockMovements")]
[DisplayName("Stock Movement"), InstanceName("Stock Movement")]
[ReadPermission(PermissionKeys.General)]
[ModifyPermission(PermissionKeys.General)]
public sealed class StockMovementsRow : Row<StockMovementsRow.RowFields>, IIdRow
{
    [DisplayName("Movement Id"), Identity, IdProperty]
    public int? MovementId { get => fields.MovementId[this]; set => fields.MovementId[this] = value; }

    [DisplayName("Product"), NotNull, ForeignKey(typeof(ProductsRow)), LeftJoin("jProd")]
    [LookupEditor(typeof(ProductsRow))]
    public int? ProductId { get => fields.ProductId[this]; set => fields.ProductId[this] = value; }

    [DisplayName("Product"), Expression("jProd.[ProductName]"), QuickSearch]
    public string ProductName { get => fields.ProductName[this]; set => fields.ProductName[this] = value; }

    [DisplayName("Movement Type"), NotNull]
    [EnumEditor]
    public int? MovementType { get => fields.MovementType[this]; set => fields.MovementType[this] = value; }

    [DisplayName("Quantity"), NotNull, IntegerEditor(MinValue = 1)]
    public int? Quantity { get => fields.Quantity[this]; set => fields.Quantity[this] = value; }

    [DisplayName("Movement Date"), NotNull, DateTimeEditor]
    public DateTime? MovementDate { get => fields.MovementDate[this]; set => fields.MovementDate[this] = value; }

    [DisplayName("Notes"), Size(500)]
    public string Notes { get => fields.Notes[this]; set => fields.Notes[this] = value; }

    [DisplayName("Created By"), NotNull, Insertable(false), Updatable(false)]
    public int? InsertUserId { get => fields.InsertUserId[this]; set => fields.InsertUserId[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field MovementId;
        public Int32Field ProductId;
        public StringField ProductName;
        public Int32Field MovementType;
        public Int32Field Quantity;
        public DateTimeField MovementDate;
        public StringField Notes;
        public Int32Field InsertUserId;
    }
}
