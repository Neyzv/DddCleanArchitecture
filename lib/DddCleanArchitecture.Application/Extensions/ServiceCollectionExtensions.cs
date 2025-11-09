using DddCleanArchitecture.Application.Services.Internationalisation;
using DddCleanArchitecture.Domain.Services.Internationalisation;
using Microsoft.Extensions.DependencyInjection;

namespace DddCleanArchitecture.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services) =>
        services
            .AddSingleton<IInternationalisationService, InternationalisationService>();
}