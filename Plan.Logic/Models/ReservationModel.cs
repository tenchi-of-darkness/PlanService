namespace Plan.Logic.Models;

public class ReservationModel
{
    public Guid Id { get; set; }
    public Guid CreatorUserId { get; set; }
    public int TotalPeople { get; set; }
    public DateTime Date { get; set; }
}