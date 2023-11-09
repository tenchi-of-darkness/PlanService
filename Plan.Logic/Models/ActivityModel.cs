using NetTopologySuite.Geometries;

namespace Plan.Logic.Models;

public class ActivityModel
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    
    public string LocationName { get; set; } = "";
    public Point Location { get; set; }
    public Guid OwnerUserId { get; set; }
    public string? Description { get; set; }
}