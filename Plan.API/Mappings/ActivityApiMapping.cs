using AutoMapper;
using NetTopologySuite.Geometries;
using Plan.API.DTO;
using Plan.UseCases.Entities;

namespace Plan.API.Mappings;

public class ActivityApiMapping : Profile
{
    public ActivityApiMapping()
    {
        CreateMap<ActivityDTO, ActivityEntity>()
            .ForMember(x => x.Location, x => x.MapFrom(y => new Point(y.LocationLat, y.LocationLong)));
        CreateMap<ActivityEntity, ActivityDTO>()
            .ForMember(x => x.LocationLat, x => x.MapFrom(y => y.Location.X))
            .ForMember(x => x.LocationLong, x => x.MapFrom(y => y.Location.Y));
    }
}