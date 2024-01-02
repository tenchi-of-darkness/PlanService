using System.ComponentModel.DataAnnotations.Schema;

namespace Plan.UseCases.Entities;

public class ReservationEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string CreatorUserId { get; set; }
    public int TotalPeople { get; set; }
    public DateTime Date { get; set; }
}