using NetTopologySuite.Geometries;
using Plan.UseCases.Responses;

namespace Plan.UseCases.Requests.Activities;

public record AddActivityRequest(string Name, string LocationName, Point Location, string? Description);
