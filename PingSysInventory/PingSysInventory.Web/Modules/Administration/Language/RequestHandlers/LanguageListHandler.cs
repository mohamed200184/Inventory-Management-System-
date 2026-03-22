using MyRow = PingSysInventory.Administration.LanguageRow;

namespace PingSysInventory.Administration;

public interface ILanguageListHandler : IListHandler<MyRow> { }

public class LanguageListHandler(IRequestContext context)
    : ListRequestHandler<MyRow>(context), ILanguageListHandler
{
}