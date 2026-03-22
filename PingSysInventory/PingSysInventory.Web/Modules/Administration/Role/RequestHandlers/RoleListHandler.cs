using MyRow = PingSysInventory.Administration.RoleRow;

namespace PingSysInventory.Administration;

public interface IRoleListHandler : IListHandler<MyRow> { }

public class RoleListHandler(IRequestContext context)
    : ListRequestHandler<MyRow>(context), IRoleListHandler
{
}