using Microsoft.AspNetCore.Mvc;

namespace Plan.Logic.Requests.Activities;

public record GetActivitiesRequest(string? SearchValue, int Page=1, int PageSize=10);