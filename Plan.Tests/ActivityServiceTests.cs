using AutoMapper;
using Moq;
using NetTopologySuite.Geometries;
using Plan.API.Mappings;
using Plan.Data.Mappings;
using Plan.UseCases.Entities;
using Plan.UseCases.Mappings;
using Plan.UseCases.Repositories.Interfaces;
using Plan.UseCases.Responses;
using Plan.UseCases.Services;

namespace Plan.Tests;

public class ActivityServiceTests
{
    private readonly Mock<IActivityRepository> _activityRepositoryMock = new();
    private readonly ActivityService _activityService;
    private readonly IMapper _mapper;

    public ActivityServiceTests()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ActivityMapping>();
            cfg.AddProfile<ActivityDataMapping>();
            cfg.AddProfile<ActivityApiMapping>();
        });
        _mapper = new Mapper(config);
        _activityService = new ActivityService(_activityRepositoryMock.Object, _mapper);
    }
           
    [Fact]
    public async Task GetActivityById_ReturnsActivityResponse()
    {
        // Arrange
        var expectedActivityId = Guid.NewGuid();
        var activity = new ActivityEntity{Id = expectedActivityId};
        var response = _mapper.Map<GetActivityResponse>(activity);
 
        _activityRepositoryMock.Setup(m => m.GetActivityById(expectedActivityId)).ReturnsAsync(activity);
             
        // Act
        var result = await _activityService.GetActivityById(expectedActivityId);
 
        // Assert
        Assert.Equal(response, result);
    }
 
    [Fact]
    public async Task GetActivities_ReturnsActivitiesResponse()
    {
        // Arrange
        // Define expected parameters and responses
        var expectedSearchValue = "sample search value";
        var expectedPage = 1;
        var expectedPageSize = 5;
        var activities = new[] {new ActivityEntity{Id = Guid.NewGuid()}, new ActivityEntity{Id = Guid.NewGuid()}};
        var responses = _mapper.Map<GetActivityResponse[]>(activities);
             
        _activityRepositoryMock.Setup(m => m.SearchActivityByName(expectedSearchValue, expectedPage, expectedPageSize)).ReturnsAsync(activities);
            
        // Act
        var result = await _activityService.GetActivities(expectedSearchValue, expectedPage, expectedPageSize);
 
        // Assert
        Assert.Equal(responses, result.Activities ?? Enumerable.Empty<GetActivityResponse>());
    }
}