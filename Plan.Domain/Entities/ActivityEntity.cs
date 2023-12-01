using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Plan.Domain.Entities;

public class ActivityEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string Name { get; set; } = "";

    public string LocationName { get; set; } = "";
    public Point Location { get; set; } = Point.Empty;
    public Guid OwnerUserId { get; set; }
    public string? Description { get; set; } = "";
}