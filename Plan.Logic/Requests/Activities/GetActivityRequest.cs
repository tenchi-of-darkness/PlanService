using Microsoft.AspNetCore.Mvc;

namespace Plan.Logic.Requests.Activities;

public record GetActivityRequest([FromQuery] string? SearchValue, [FromQuery] int Page=1, [FromQuery] int PageSize=10);