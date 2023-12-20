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

namespace Plan.Tests;

public class ActivityServiceTests
{
    private readonly Mock<IActivityRepository> _activityRepositoryMock = new();
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
    }

    private ActivityService CreateService()
    {
        return new ActivityService(_activityRepositoryMock.Object, _mapper);
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
            OwnerUserId = new Guid()
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

    // [Fact]
    // public async Task GetActivities_ReturnsActivitiesResponse()
    // {
    //     // Arrange
    //     var expectedSearchValue = "sample search value";
    //     var expectedPage = 1;
    //     var expectedPageSize = 5;
    //     var activities = new[]
    //         { new ActivityEntity { Id = Guid.NewGuid() }, new ActivityEntity { Id = Guid.NewGuid() } };
    //     var responses = _mapper.Map<GetActivityResponse[]>(activities);
    //
    //     _activityRepositoryMock.Setup(m => m.SearchActivityByName(expectedSearchValue, expectedPage, expectedPageSize))
    //         .ReturnsAsync(activities);
    //
    //     // Act
    //     var result = await _activityService.GetActivities(expectedSearchValue, expectedPage, expectedPageSize);
    //
    //     // Assert
    //     Assert.Equal(responses, result.Activities ?? Enumerable.Empty<GetActivityResponse>());
    // }
    //
    // [Fact]
    // public async Task GetActivities_Search_CorrectResult()
    // {
    //     //Arrange
    //     string searchValue = "activity";
    //     int page = 1;
    //     int pageSize = 5;
    //     var activities = new List<Entities.Activity>();
    //     var expectedResponse = new GetActivitiesResponse();
    //
    //     _activityRepositoryMock.Setup(x => x.SearchActivityByName(searchValue, page, pageSize))
    //         .ReturnsAsync(activities);
    //     _mapper.Setup(x => x.Map<GetActivityResponse[]>(activities)).Returns(new GetActivityResponse[] { });
    //
    //     //Act
    //     var result = await _activityService.GetActivities(searchValue, page, pageSize);
    //
    //     //Assert
    //     Assert.Equal(expectedResponse, result);
    // }
    //
    //
    // [Fact]
    // public async Task AddActivity()
    // {
    //     //Arrange
    //     var request = new AddActivityRequest("Test", "lokaal", Point.Empty, "test");
    //     var entity = new ActivityEntity();
    //     var service = CreateService();
    //     var expectedResponse = new AddActivityResponse();
    //
    //     _mockActivitymapper.Setup(x => x.Map<ActivityEntity>(request)).Returns(entity);
    //     _activityRepositoryMock.Setup(x => x.AddActivity(entity)).ReturnsAsync(true);
    //
    //     //Act
    //     var result = await _activityService.AddActivity(request);
    //
    //     //Assert
    //     Assert.Equal(expectedResponse, result);
    // }
    //
    //
    // [Fact]
    // public async Task DeleteActivity()
    // {
    //     // Arrange
    //     var expectedActivityId = Guid.NewGuid();
    //     _activityRepositoryMock.Setup(x => x.DeleteActivity(expectedActivityId)).ReturnsAsync(true);
    //
    //     // Act
    //     var result = await _activityService.DeleteActivity(expectedActivityId);
    //
    //     // Assert
    //     Assert.True(result);
    // }
}