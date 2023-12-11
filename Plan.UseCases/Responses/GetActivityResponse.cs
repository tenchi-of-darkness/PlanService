using NetTopologySuite.Geometries;

namespace Plan.UseCases.Responses;

public record GetActivityResponse(Guid Id, string Name, string LocationName, Point Location, Guid OwnerUserId,
    string Description);
