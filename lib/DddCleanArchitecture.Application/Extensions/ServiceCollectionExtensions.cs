using DddCleanArchitecture.Application.Services.Internationalisation;
using DddCleanArchitecture.Domain.Services.Internationalisation;
using Microsoft.Extensions.DependencyInjection;

namespace DddCleanArchitecture.Application.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add the application layer to the <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The application <see cref="IServiceCollection"/>.</param>
    /// <returns></returns>
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services) =>
        services
            .AddSingleton<IInternationalisationService, InternationalisationService>();
}