using Microsoft.AspNetCore.Mvc;
using Plan.API.DTO;
using Plan.Domain.Entities;
using Plan.Logic.Requests.Activities;
using Plan.Logic.Services.Interfaces;
using Plan.UseCases.Requests.Activities;
using Plan.UseCases.Responses;

namespace Plan.API.Controllers;

[ApiController]
[Route("api/activity")]
public class ActivityController : ControllerBase
{
    private readonly ILogger<ActivityController> _logger;
    private readonly IActivityService _service;

    public ActivityController(IActivityService service, ILogger<ActivityController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ActivityDTO>> GetActivityById([FromRoute] Guid id)
    {
        var activity = await _service.GetActivityById(id);
        if (activity == null)
        {
            return NotFound();
        }

        return Ok(new ActivityDTO(activity));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ActivityDTO>>> GetActivities([FromRoute] GetActivitiesRequest request)
    {
        return Ok(await _service.GetActivities(request.SearchValue, request.Page, request.PageSize));
    }

    [HttpPost]
    public async Task<ActionResult<AddActivityResponse>> AddActivity([FromBody] AddActivityRequest request)
    {
        AddActivityResponse response = await _service.AddActivity(request);
        if (response.FailureReason == null)
        {
            return Ok();
        }

        if (response.FailureType == FailureType.User)
        {
            return BadRequest(response);
        }

        return StatusCode(500, response);
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteActivity(Guid id)
    {
        if (await _service.DeleteActivity(id))NotFound();
        return new NotFoundResult();
    }
}