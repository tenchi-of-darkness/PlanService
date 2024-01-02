namespace Plan.API.DTO;

public class ReservationDTO
{
    public Guid Id { get; set; }
    public string CreatorUserId { get; set; }
    public int TotalPeople { get; set; }
    public DateTime Date { get; set; }
}