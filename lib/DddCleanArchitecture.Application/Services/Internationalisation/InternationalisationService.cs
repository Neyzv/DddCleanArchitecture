using System.Collections.ObjectModel;
using System.Globalization;
using DddCleanArchitecture.Domain.Enums;
using DddCleanArchitecture.Domain.Services.Internationalisation;

namespace DddCleanArchitecture.Application.Services.Internationalisation;

public sealed class InternationalisationService
    : IInternationalisationService
{
    private static readonly ReadOnlyDictionary<Language, string> LanguageDictionary = new Dictionary<Language, string>
    {
        [Language.English] = "en-US",
        [Language.French] = "fr-FR",
    }.AsReadOnly();

    private readonly Lock _lock = new();

    public event Action? LanguageChanged;

    public bool TryChangeLanguage(Language language)
    {
        if (!LanguageDictionary.TryGetValue(language, out var culture))
            return false;

        using (_lock.EnterScope())
        {
            var cultureInfo = new CultureInfo(culture);

            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            LanguageChanged?.Invoke();
        }

        return true;
    }
}