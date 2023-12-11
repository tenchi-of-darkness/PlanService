using Microsoft.Extensions.DependencyInjection;
using Plan.UseCases.Services;
using Plan.UseCases.Services.Interfaces;

namespace Plan.UseCases.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddLogic(this IServiceCollection collection)
    {
        
        collection.AddTransient<IActivityService, ActivityService>();
        return collection;
    }
}