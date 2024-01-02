using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Plan.Data.DBO;

public class ActivityDBO
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string Name { get; set; } = "";
    
    public string LocationName { get; set; } = "";
    public Point Location { get; set; } = Point.Empty;
    public string OwnerUserId { get; set; }
    public string? Description { get; set; } = "";
}