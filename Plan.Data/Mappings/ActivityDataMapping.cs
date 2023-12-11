using AutoMapper;
using Plan.Data.DBO;
using Plan.UseCases.Entities;

namespace Plan.Data.Mappings;

public class ActivityDataMapping: Profile
{
    public ActivityDataMapping()
    {
        CreateMap<ActivityDBO, ActivityEntity>();
        CreateMap<ActivityEntity, ActivityDBO>();
    }
}