using Plan.API.Models.Responses;
using Plan.Data.DbContext;
using Plan.Data.Entities;
using Plan.Logic.Repositories.Interfaces;

namespace Plan.Data.Repositories;

public class ActivityRepository : IActivityRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public ActivityRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public Task<ActivityEntity?> GetActivityById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ActivityEntity>> SearchActivityByTitle(string? searchValue, int page, int pageSize)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> AddActivity(ActivityEntity entity)
    {
        throw new NotImplementedException();
    }
}