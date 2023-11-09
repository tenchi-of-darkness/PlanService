using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;
using Plan.Logic.Models;

namespace Plan.Data.Entities;

public class ReservationEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public Guid CreatorUserId { get; set; }
    public int TotalPeople { get; set; }
    public DateTime Date { get; set; }

    public ReservationModel ToModel()
    {
        return new ReservationModel
        {
            Id = Id,
            CreatorUserId = CreatorUserId,
            TotalPeople = TotalPeople,
            Date = Date
        };
    }
    
    public ReservationEntity(ReservationModel model)
    {
        Id = model.Id;
        CreatorUserId = model.CreatorUserId;
        TotalPeople = model.TotalPeople;
        Date = model.Date;
    }

    public ReservationEntity()
    {
        
    }
}