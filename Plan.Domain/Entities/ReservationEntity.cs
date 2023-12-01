using System.ComponentModel.DataAnnotations.Schema;

namespace Plan.Domain.Entities;

public class ReservationEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public Guid CreatorUserId { get; set; }
    public int TotalPeople { get; set; }
    public DateTime Date { get; set; }
}