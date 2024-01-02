using Microsoft.Extensions.DependencyInjection;
using Plan.UseCases.Mappings;
using Plan.UseCases.Services;
using Plan.UseCases.Services.Interfaces;
using Plan.UseCases.Utilities.Interfaces;

namespace Plan.UseCases.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddLogic(this IServiceCollection collection)
    {
        collection.AddAutoMapper(typeof(ActivityMapping));
        collection.AddTransient<IAuthenticationUtility, AuthenticationUtility>();
        collection.AddTransient<IActivityService, ActivityService>();
        return collection;
    }
}