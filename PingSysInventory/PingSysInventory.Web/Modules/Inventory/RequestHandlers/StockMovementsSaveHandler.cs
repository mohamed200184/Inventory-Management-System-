using MyRow = PingSysInventory.Inventory.StockMovementsRow;

namespace PingSysInventory.Inventory;

public interface IStockMovementsSaveHandler : ISaveHandler<MyRow> { }

public class StockMovementsSaveHandler(IRequestContext context, IUserProvider userProvider)
    : SaveRequestHandler<MyRow>(context), IStockMovementsSaveHandler
{
    private readonly IUserProvider userProvider = userProvider ?? throw new ArgumentNullException(nameof(userProvider));

    protected override void ValidateRequest()
    {
        base.ValidateRequest();

        if (IsUpdate)
        {
            throw new ValidationError("Inventory.MovementsNotEditable", "MovementsNotEditable",
                "Stock movements cannot be edited after creation.");
        }

        if (!IsCreate)
            return;

        var productId = Row.ProductId ?? throw new ValidationError("Required", "ProductId", "Product is required.");
        var qty = Row.Quantity ?? throw new ValidationError("Required", "Quantity", "Quantity is required.");
        var mt = (MovementType)(Row.MovementType ?? throw new ValidationError("Required", "MovementType", "Movement type is required."));

        if (mt == MovementType.Out)
        {
            var product = Connection.TryById<ProductsRow>(productId);
            if (product == null)
                throw new ValidationError("NotFound", "ProductId", "Product not found.");

            var available = product.CurrentStock ?? 0;
            if (available < qty)
            {
                throw new ValidationError("NotEnoughStock", "Quantity",
                    $"Not enough stock. Available: {available}");
            }
        }
    }

    protected override void SetInternalFields()
    {
        base.SetInternalFields();

        if (!IsCreate)
            return;

        if (userProvider.GetUserDefinition() is not UserDefinition user)
            throw new ValidationError("NoUser", "User", "User not found.");

        Row.InsertUserId = user.UserId;
        Row.MovementDate ??= DateTime.Now;
    }

    protected override void AfterSave()
    {
        base.AfterSave();

        if (!IsCreate)
            return;

        var productId = Row.ProductId!.Value;
        var qty = Row.Quantity!.Value;
        var mt = (MovementType)Row.MovementType!.Value;

        var pf = ProductsRow.Fields;
        var product = Connection.TryById<ProductsRow>(productId)
            ?? throw new ValidationError("NotFound", "ProductId", "Product not found.");

        var current = product.CurrentStock ?? 0;
        var rowVersion = product.RowVersion;

        if (mt == MovementType.Out)
        {
            if (current < qty)
            {
                throw new ValidationError("NotEnoughStock", "Quantity",
                    $"Not enough stock. Available: {current}");
            }
        }

        var newStock = mt == MovementType.In ? current + qty : current - qty;

        var affected = new SqlUpdate(pf.TableName)
            .Set(pf.CurrentStock, newStock)
            .WhereEqual(pf.ProductId, productId)
            .WhereEqual(pf.RowVersion, rowVersion)
            .Execute(Connection, ExpectedRows.Ignore);

        if (affected != 1)
        {
            throw new ValidationError("Concurrency", "Concurrency",
                "Stock was changed by another transaction. Please retry.");
        }
    }
}
