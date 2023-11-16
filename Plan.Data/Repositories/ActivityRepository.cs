using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Plan.API.Models.Responses;
using Plan.Data.DbContext;
using Plan.Data.Entities;
using Plan.Logic.Repositories.Interfaces;

namespace Plan.Data.Repositories;

public class ActivityRepository : IActivityRepository
{
    private readonly ApplicationDbContext _context;

    public ActivityRepository(ApplicationDbContext applicationDbContext)
    {
        _context = applicationDbContext;
    }

    public Task<ActivityEntity?> GetActivityById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ActivityEntity>> SearchActivityByName(string? searchValue, int page, int pageSize)
    {
        int skip = (page - 1) * pageSize;
        var query = _context.Activities.AsQueryable();

        if (searchValue != null)
        {
            query = query.Where(t => t.Name.Contains(searchValue));
        }

        return await query.Skip(skip)
            .Take(pageSize).ToArrayAsync();
    }

    public async Task<bool> AddActivity(ActivityEntity entity)
    {
        throw new NotImplementedException(); 
   
    }

    public async Task<bool> DeleteActivity(Guid id)
    {
        return await _context.Activities.Where(a => a.Id == id).ExecuteDeleteAsync()==1;
    }
}