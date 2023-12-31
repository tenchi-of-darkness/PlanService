﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Plan.Data.DbContext;
using Plan.Data.DBO;
using Plan.UseCases.Entities;
using Plan.UseCases.Repositories.Interfaces;

namespace Plan.Data.Repositories;

public class ActivityRepository : IActivityRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ActivityRepository(ApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _context = applicationDbContext;
        _mapper = mapper;
    }

    public async Task<ActivityEntity?> GetActivityById(Guid id)
    {
        var activity = await _context.Activities.FindAsync(id);
        return _mapper.Map<ActivityEntity>(activity);
    }

    public async Task<IEnumerable<ActivityEntity>> SearchActivityByName(string? searchValue, int page, int pageSize)
    {
        int skip = (page - 1) * pageSize;
        var query = _context.Activities.AsQueryable();

        if (searchValue != null)
        {
            query = query.Where(t => t.Name.Contains(searchValue));
        }

        return _mapper.Map<ActivityEntity[]>(await query.Skip(skip).Take(pageSize).ToArrayAsync());
    }

    public async Task<bool> AddActivity(ActivityEntity entity)
    {
        _context.Activities.Add(_mapper.Map<ActivityDBO>(entity));
        return await _context.SaveChangesAsync() == 1;
    }

    public async Task<bool> DeleteActivity(Guid id)
    {
        return await _context.Activities.Where(a => a.Id == id).ExecuteDeleteAsync()==1;
    }
}