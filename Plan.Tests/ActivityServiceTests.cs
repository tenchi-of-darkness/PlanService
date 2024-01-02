using AutoMapper;
using Moq;
using NetTopologySuite.Geometries;
using Plan.API.Mappings;
using Plan.Data.Mappings;
using Plan.UseCases.Entities;
using Plan.UseCases.Mappings;
using Plan.UseCases.Repositories.Interfaces;
using Plan.UseCases.Requests.Activities;
using Plan.UseCases.Responses;
using Plan.UseCases.Services;
using Plan.UseCases.Utilities.Interfaces;

namespace Plan.Tests;

public class ActivityServiceTests
{
    private readonly Mock<IActivityRepository> _activityRepositoryMock = new();
    private readonly Mock<IAuthenticationUtility> _authenticationUtilityMock = new (MockBehavior.Strict);
    private readonly IMapper _mapper;
    private const string UserId = "test";

    public ActivityServiceTests()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ActivityMapping>();
            cfg.AddProfile<ActivityDataMapping>();
            cfg.AddProfile<ActivityApiMapping>();
        });
        _mapper = new Mapper(config);
    }

    private ActivityService CreateService()
    {
        _authenticationUtilityMock.Setup(x => x.GetUserId()).Returns(UserId);
        return new ActivityService(_activityRepositoryMock.Object, _mapper, _authenticationUtilityMock.Object);
    }

    [Fact]
    public async Task GetActivityById_ReturnsActivityResponse()
    {
        // Arrange
        var activity = new ActivityEntity
        {
            Description = "Activity",
            Id = Guid.NewGuid(),
            Location = new Point(new Coordinate(1, 5)),
            LocationName = "Eindhoven",
            Name = "Activity",
            OwnerUserId = new string(UserId)
        };
        _activityRepositoryMock.Setup(repo => repo.GetActivityById(It.IsAny<Guid>())).ReturnsAsync(activity);
        var activityService = CreateService();
        var id = Guid.NewGuid();
        var response = _mapper.Map<GetActivityResponse>(activity);

        // Act
        var result = await activityService.GetActivityById(id);

        // Assert
        Assert.Equal(result, response);
    }

    [Fact]
    public async Task GetActivities_ReturnsActivitiesResponse()
    {
        // Arrange
        var expectedSearchValue = "Test activity";
        var expectedPage = 1;
        var expectedPageSize = 5;
        var activityService = CreateService();
        var activities = new[]
            { new ActivityEntity { Id = Guid.NewGuid() }, new ActivityEntity { Id = Guid.NewGuid() } };
        var responses = _mapper.Map<GetActivityResponse[]>(activities);
    
        _activityRepositoryMock.Setup(m => m.SearchActivityByName(expectedSearchValue, expectedPage, expectedPageSize))
            .ReturnsAsync(activities);
    
        // Act
        var result = await activityService.GetActivities(expectedSearchValue, expectedPage, expectedPageSize);
    
        // Assert
        Assert.Equal(responses, result.Activities ?? Enumerable.Empty<GetActivityResponse>());
    }
    
    [Fact]
    public async Task GetActivities_Search_CorrectResult()
    {
        //Arrange
        const string searchValue = "activity";
        int page = 1;
        int pageSize = 5;
        var activityService = CreateService();
        var activities = new List<ActivityEntity>();
        activities.Add(new ActivityEntity
        {
            Id = Guid.NewGuid()
        });
        var response = _mapper.Map<GetActivityResponse[]>(activities);
    
        _activityRepositoryMock.Setup(x => x.SearchActivityByName(searchValue, page, pageSize))
            .ReturnsAsync(activities);
        
        //Act
        var result = await activityService.GetActivities(searchValue, page, pageSize);
    
        //Assert
        Assert.Equal(response.Select(x=>x.Id), result.Activities?.Select(x=>x.Id)??Enumerable.Empty<Guid>());
    }
    
    [Fact]
    public async Task AddActivity()
    {
        //Arrange
        var request = new AddActivityRequest("Test", "lokaal", Point.Empty, "test");
        var activity = new ActivityEntity();
        var activityService = CreateService();
        var expectedResponse = new AddActivityResponse();

        _activityRepositoryMock.Setup(x => x.AddActivity(It.IsAny<ActivityEntity>())).ReturnsAsync(true);
    
        //Act
        var result = await activityService.AddActivity(request);
    
        //Assert
        Assert.Equal(expectedResponse, result);
    }
    
    [Fact]
    public async Task DeleteActivity()
    {
        // Arrange
        var id = Guid.NewGuid();
        var activityService = CreateService();
        _activityRepositoryMock.Setup(x => x.DeleteActivity(id)).ReturnsAsync(true);
    
        // Act
        var result = await activityService.DeleteActivity(id);
    
        // Assert
        _activityRepositoryMock.Verify(repo => repo.DeleteActivity(id), Times.Once);
        Assert.True(result);
    }
}