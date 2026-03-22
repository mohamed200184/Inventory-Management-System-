namespace PingSysInventory.Inventory;

[EnumKey("Inventory.MovementType")]
public enum MovementType
{
    [Description("Stock In")]
    In = 1,
    [Description("Stock Out")]
    Out = 2
}
