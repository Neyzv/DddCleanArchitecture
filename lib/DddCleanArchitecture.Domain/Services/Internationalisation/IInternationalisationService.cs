using DddCleanArchitecture.Domain.Enums;

namespace DddCleanArchitecture.Domain.Services.Internationalisation;

public interface IInternationalisationService
{
    /// <summary>
    /// Triggered when the application language change.
    /// </summary>
    event Action? LanguageChanged;

    /// <summary>
    /// Try to change the application language.
    /// </summary>
    /// <param name="language">The desired language</param>
    /// <returns><c>true</c> if the operation succeeded, otherwise <c>false</c>.</returns>
    bool TryChangeLanguage(Language language);
}