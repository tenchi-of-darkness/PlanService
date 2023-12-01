using AutoMapper;
using Plan.Domain.Entities;
using Plan.UseCases.Requests.Activities;
using Plan.UseCases.Responses;

namespace Plan.Logic.Mappings;

public class ActivityMapping: Profile
{
    public ActivityMapping()
    {
        CreateMap<AddActivityRequest, ActivityEntity>();
        CreateMap<ActivityEntity, AddActivityResponse>();
    }
}