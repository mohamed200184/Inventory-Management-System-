using MyRow = PingSysInventory.Administration.LanguageRow;

namespace PingSysInventory.Administration;

public interface ILanguageSaveHandler : ISaveHandler<MyRow> { }

public class LanguageSaveHandler(IRequestContext context)
    : SaveRequestHandler<MyRow>(context), ILanguageSaveHandler
{
}