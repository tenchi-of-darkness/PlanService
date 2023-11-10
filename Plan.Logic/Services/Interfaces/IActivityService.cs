using Plan.API.Models.Responses;
using Plan.Data.Entities;

namespace Plan.Logic.Services.Interfaces;

public interface IActivityService
{
    Task<ActivityEntity> GetActivityById(int id);
    Task<IEnumerable<ActivityEntity>> GetActivities(string? searchValue, int page, int pageSize);
    Task<AddActivityResponse> AddActivity(ActivityEntity model);
}