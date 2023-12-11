using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Plan.Data.DbContext;
using Plan.Data.Mappings;
using Plan.Data.Repositories;
using Plan.UseCases.Repositories.Interfaces;

namespace Plan.Data.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddData(this IServiceCollection collection, IConfiguration configuration)
    {
        collection.AddTransient<IActivityRepository, ActivityRepository>();
        collection.AddAutoMapper(typeof(ActivityDataMapping));
        collection.AddDbContext<ApplicationDbContext>(builder =>
        {
            builder.UseMySql(configuration.GetConnectionString("Default"), ServerVersion.AutoDetect(configuration.GetConnectionString("NoDatabase")),
                options =>
                {
                    options.UseNetTopologySuite();
                });
        });
        collection.AddTransient<IActivityRepository, ActivityRepository>();
        return collection;
    }
}