using Plan.UseCases.Requests.Activities;
using Plan.UseCases.Responses;

namespace Plan.UseCases.Services.Interfaces;

public interface IActivityService
{
    Task<GetActivityResponse?> GetActivityById(Guid id);
    Task<GetActivitiesResponse> GetActivities(string? searchValue, int page, int pageSize);
    Task<AddActivityResponse> AddActivity(AddActivityRequest request);
    Task<bool> DeleteActivity(Guid id);
}