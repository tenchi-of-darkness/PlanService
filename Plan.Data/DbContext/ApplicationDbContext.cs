using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Plan.Data.DBO;
using Plan.Domain.Entities;

namespace Plan.Data.DbContext;

public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    private readonly IConfiguration _configuration;

    public ApplicationDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(_configuration.GetConnectionString("Default"), ServerVersion.AutoDetect(_configuration.GetConnectionString("NoDatabase")),
            options =>
            {
                options.UseNetTopologySuite();
            });
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActivityDBO>().HasKey(x => x.Id);
        modelBuilder.Entity<ReservationDBO>().HasKey(x => x.Id);
    }
    
    public DbSet<ActivityDBO> Activities { get; set; } = null!;
    public DbSet<ReservationDBO> Reservations { get; set; } = null!;
}