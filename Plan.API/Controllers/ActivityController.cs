using Microsoft.AspNetCore.Mvc;
using Plan.API.Models;
using Plan.API.Models.Responses;
using Plan.Data.Entities;
using Plan.Logic.Requests.Activities;
using Plan.Logic.Services.Interfaces;

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
    public async Task<ActionResult<ActivityModel>> GetActivityById([FromRoute] Guid id)
    {
        ActivityEntity? activity = await _service.GetActivityById(id);
        if (activity == null)
        {
            return NotFound();
        }

        return Ok(new ActivityModel(activity));
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ActivityModel>>> GetActivities([FromRoute] GetActivitiesRequest request)
    {
        return Ok(await _service.GetActivities(request.SearchValue, request.Page, request.PageSize));
    }

    [HttpPost]
    public async Task<ActionResult<AddActivityResponse>> AddActivity([FromBody] ActivityModel model)
    {
        AddActivityResponse response = await _service.AddActivity(model.ToEntity());
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
}