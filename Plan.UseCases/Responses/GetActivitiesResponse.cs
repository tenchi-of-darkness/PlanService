namespace Plan.UseCases.Responses;

public record GetActivitiesResponse(IEnumerable<GetActivityResponse>? Activities, string? Error = null)
{
    public GetActivitiesResponse(string error) : this(null, error){}
};