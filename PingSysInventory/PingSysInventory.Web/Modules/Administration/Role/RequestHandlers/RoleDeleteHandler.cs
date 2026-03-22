using MyRow = PingSysInventory.Administration.RoleRow;

namespace PingSysInventory.Administration;

public interface IRoleDeleteHandler : IDeleteHandler<MyRow> { }

public class RoleDeleteHandler(IRequestContext context)
    : DeleteRequestHandler<MyRow>(context), IRoleDeleteHandler
{
}