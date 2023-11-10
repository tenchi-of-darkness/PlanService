using NetTopologySuite.Geometries;
using Plan.Data.Entities;

namespace Plan.API.Models;

public class ActivityModel
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    
    public string LocationName { get; set; } = "";
    public Point Location { get; set; }
    public Guid OwnerUserId { get; set; }
    public string? Description { get; set; }
    
    

    public ActivityEntity ToEntity()
    {
        return new ActivityEntity
        {
            Id = Id,
            Name = Name,
            LocationName = LocationName,
            Location = Location,
            OwnerUserId = OwnerUserId,
            Description = Description
        };
    }

    public ActivityModel(ActivityEntity entity)
    {
        Id = entity.Id;
        Name = entity.Name;
        LocationName = entity.LocationName;
        Location = entity.Location;
        OwnerUserId = entity.OwnerUserId;
        Description = entity.Description;
    }
}