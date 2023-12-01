namespace Plan.UseCases.Responses;

public record AddActivityResponse(FailureType? FailureType = null, string? FailureReason = null);

public enum FailureType
{
    User,
    Server
}