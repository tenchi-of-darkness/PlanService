using AutoMapper;
using Plan.API.DTO;
using Plan.Domain.Entities;

namespace Plan.API.Mappings;

public class ActivityApiMapping: Profile
{
    public ActivityApiMapping()
    {
        CreateMap<ActivityDTO, ActivityEntity>();
        CreateMap<ActivityEntity, ActivityEntity>();
    }
}