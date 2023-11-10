using Plan.Data.Entities;

namespace Plan.API.Models;

public class ReservationModel
{
    public Guid Id { get; set; }
    public Guid CreatorUserId { get; set; }
    public int TotalPeople { get; set; }
    public DateTime Date { get; set; }
    
    
    public ReservationEntity ToEntity()
    {
        return new ReservationEntity
        {
            Id = Id,
            CreatorUserId = CreatorUserId,
            TotalPeople = TotalPeople,
            Date = Date
        };
    }
    
    public ReservationModel(ReservationEntity entity)
    {
        Id = entity.Id;
        CreatorUserId = entity.CreatorUserId;
        TotalPeople = entity.TotalPeople;
        Date = entity.Date;
    }
}