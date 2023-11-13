﻿using Plan.Data.Entities;

namespace Plan.Logic.Repositories.Interfaces;

public interface IActivityRepository
{
    Task<ActivityEntity?> GetActivityById(Guid id);
    Task<IEnumerable<ActivityEntity>> SearchActivityByTitle(string? searchValue, int page, int pageSize);
    Task<bool> AddActivity(ActivityEntity entity);
}