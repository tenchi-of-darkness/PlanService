using Plan.Domain.Entities;
using Plan.UseCases.Requests.Activities;
using Plan.UseCases.Responses;

namespace Plan.Logic.Services.Interfaces;

public interface IActivityService
{
    Task<ActivityEntity?> GetActivityById(Guid id);
    Task<IEnumerable<ActivityEntity>> GetActivities(string? searchValue, int page, int pageSize);
    Task<AddActivityResponse> AddActivity(AddActivityRequest request);
    Task<bool> DeleteActivity(Guid id);
}