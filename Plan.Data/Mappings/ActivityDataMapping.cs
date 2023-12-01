using AutoMapper;
using Plan.Domain.Entities;
using Plan.Data.DBO;

namespace Plan.Data.Mappings;

public class ActivityDataMapping: Profile
{
    public ActivityDataMapping()
    {
        CreateMap<ActivityDBO, ActivityEntity>();
        CreateMap<ActivityEntity, ActivityDBO>();
    }
}