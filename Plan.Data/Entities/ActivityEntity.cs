using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;
using Plan.Logic.Models;

namespace Plan.Data.Entities;

public class ActivityEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string Name { get; set; } = "";
    
    public string LocationName { get; set; } = "";
    public Point Location { get; set; } = Point.Empty;
    public Guid OwnerUserId { get; set; }
    public string? Description { get; set; } = "";

    public ActivityModel ToModel()
    {
        return new ActivityModel
        {
            Id = Id,
            Name = Name,
            LocationName = LocationName,
            Location = Location,
            OwnerUserId = OwnerUserId,
            Description = Description
        };
    }

    public ActivityEntity(ActivityModel model)
    {
        Id = model.Id;
        Name = model.Name;
        LocationName = model.LocationName;
        Location = model.Location;
        OwnerUserId = model.OwnerUserId;
        Description = model.Description;
    }

    public ActivityEntity()
    {
        
    }
}