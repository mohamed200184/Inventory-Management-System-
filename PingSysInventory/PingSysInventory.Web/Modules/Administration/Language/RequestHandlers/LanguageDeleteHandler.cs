using MyRow = PingSysInventory.Administration.LanguageRow;

namespace PingSysInventory.Administration;

public interface ILanguageDeleteHandler : IDeleteHandler<MyRow> { }

public class LanguageDeleteHandler(IRequestContext context)
    : DeleteRequestHandler<MyRow>(context), ILanguageDeleteHandler
{
}