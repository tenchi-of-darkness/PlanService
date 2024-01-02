using NetTopologySuite.Geometries;

namespace Plan.API.DTO;

public class ActivityDTO
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    
    public string LocationName { get; set; }
    
    public double LocationLat { get; set; }
    public double LocationLong { get; set; }
    public string OwnerUserId { get; set; }
    public string? Description { get; set; }
}