using System.ComponentModel.DataAnnotations.Schema;

namespace Plan.Data.DBO;

public class ReservationDBO
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string CreatorUserId { get; set; }
    public int TotalPeople { get; set; }
    public DateTime Date { get; set; }
}