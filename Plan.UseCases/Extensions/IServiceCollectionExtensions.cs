using Microsoft.Extensions.DependencyInjection;
using Plan.Logic.Services;
using Plan.Logic.Services.Interfaces;

namespace Plan.Logic.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddLogic(this IServiceCollection collection)
    {
        
        collection.AddTransient<IActivityService, ActivityService>();
        return collection;
    }
}