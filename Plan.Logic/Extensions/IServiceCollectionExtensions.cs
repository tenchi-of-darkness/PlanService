using Microsoft.Extensions.DependencyInjection;

namespace Plan.Logic.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddLogic(this IServiceCollection collection)
    {
        return collection;
    }
}