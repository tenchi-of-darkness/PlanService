using AutoMapper;
using Plan.UseCases.Entities;
using Plan.UseCases.Requests.Activities;
using Plan.UseCases.Responses;

namespace Plan.UseCases.Mappings;

public class ActivityMapping: Profile
{
    public ActivityMapping()
    {
        CreateMap<AddActivityRequest, ActivityEntity>();
        CreateMap<ActivityEntity, AddActivityResponse>();
    }
}