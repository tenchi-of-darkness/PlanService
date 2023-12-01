using NetTopologySuite.Geometries;
using Plan.Domain.Entities;

namespace Plan.API.DTO;

public class ActivityDTO
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    
    public string LocationName { get; set; }
    
    public Point Location { get; set; } = Point.Empty;
    public double LocationLat { get; set; }
    public double LocationLong { get; set; }
    public Guid OwnerUserId { get; set; }
    public string? Description { get; set; }
    
    
    public ActivityEntity ToEntity()
    {
        return new ActivityEntity
        {
            Id = Id,
            Name = Name,
            LocationName = LocationName,
            Location = new Point(LocationLat, LocationLong),
            OwnerUserId = OwnerUserId,
            Description = Description
        };
    }

    public ActivityDTO(ActivityEntity entity)
    {
        Id = entity.Id;
        Name = entity.Name;
        LocationName = entity.LocationName;
        LocationLat = entity.Location.X;
        LocationLong = entity.Location.Y;
        OwnerUserId = entity.OwnerUserId;
        Description = entity.Description;
    }
}