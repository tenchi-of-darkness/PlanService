namespace Plan.UseCases.Responses;

public record GetActivitiesResponse(IEnumerable<GetActivityResponse> Activities);