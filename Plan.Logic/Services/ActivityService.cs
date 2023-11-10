using Plan.API.Models.Responses;
using Plan.Data.Entities;
using Plan.Logic.Repositories.Interfaces;
using Plan.Logic.Services.Interfaces;

namespace Plan.Logic.Services;

public class ActivityService : IActivityService
{
    private readonly IActivityRepository _activityRepository;

    public ActivityService(IActivityRepository activityRepository)
    {
        _activityRepository = activityRepository;
    }

    public async Task<ActivityEntity> GetActivityById(int id)
    {
        return await _activityRepository.GetActivityById(id);
    }

    public async Task<IEnumerable<ActivityEntity>> GetActivities(string? searchValue, int page, int pageSize)
    {
        return await _activityRepository.SearchActivityByTitle(searchValue, page, pageSize);
    }

    public async Task<AddActivityResponse> AddActivity(ActivityEntity entity)
    {
        if (entity.Description?.Length >255)
        {
            return new AddActivityResponse(FailureType.User,
                "Description has too many characters. Only 255 characters are allowed");
        }

        if (!await _activityRepository.AddActivity(entity))
        {
            return new AddActivityResponse(FailureType.Server, "Database failure");
        }

        return new AddActivityResponse();
    }
}