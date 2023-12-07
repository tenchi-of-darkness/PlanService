using AutoMapper;
using Plan.Domain.Entities;
using Plan.Domain.Repositories.Interfaces;
using Plan.Logic.Services.Interfaces;
using Plan.UseCases.Requests.Activities;
using Plan.UseCases.Responses;

namespace Plan.Logic.Services;

public class ActivityService : IActivityService
{
    private readonly IActivityRepository _activityRepository;
    private readonly IMapper _mapper;

    public ActivityService(IActivityRepository activityRepository, IMapper mapper)
    {
        _activityRepository = activityRepository;
        _mapper = mapper;
    }

    public async Task<ActivityEntity?> GetActivityById(Guid id)
    {
        return await _activityRepository.GetActivityById(id);
    }

    public async Task<IEnumerable<ActivityEntity>> GetActivities(string? searchValue, int page, int pageSize)
    {
        return await _activityRepository.SearchActivityByName(searchValue, page, pageSize);
    }

    public async Task<AddActivityResponse> AddActivity(AddActivityRequest request)
    {
        if (request.Description?.Length >255)
        {
            return new AddActivityResponse(FailureType.User,
                "Description has too many characters. Only 255 characters are allowed");
        }

        var activity = _mapper.Map<ActivityEntity>(request);

        // activity.OwnerUserId = 

        if (!await _activityRepository.AddActivity(activity))
        {
            return new AddActivityResponse(FailureType.Server, "Database failure");
        }

        return new AddActivityResponse();
    }

    public async Task<bool> DeleteActivity(Guid id)
    {
        return await _activityRepository.DeleteActivity(id);
    }
}