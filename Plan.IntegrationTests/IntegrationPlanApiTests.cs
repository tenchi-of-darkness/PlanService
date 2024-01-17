using System.Diagnostics;
using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using NetTopologySuite.Geometries;
using Plan.API;
using Plan.API.DTO;
using Plan.UseCases.Requests.Activities;
using Plan.UseCases.Responses;
using Plan.UseCases.Services;

namespace Plan.IntegrationTests;

public class PlanIntegrationTests: IClassFixture<WebApplicationFactory<PlanApiProgram>>
{
    private readonly WebApplicationFactory<PlanApiProgram> _factory;

    public PlanIntegrationTests(WebApplicationFactory<PlanApiProgram> factory)
    {
        _factory = factory.WithWebHostBuilder(builder => builder.UseEnvironment("IntegrationTest"));
    }
    
    [Fact]
    public async Task GetTrails_AddTrail_Success()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.PostAsJsonAsync("/api/activity",
            new AddActivityRequest("", "", new Point(5,8),""),
            Default.JsonSerializerOptions);


        var getActivitiesResponse = await client.GetAsync("/api/activity?Page=1&PageSize=15");

        var test = await getActivitiesResponse.Content.ReadAsStringAsync();

        var activities =
            await getActivitiesResponse.Content.ReadFromJsonAsync<IEnumerable<ActivityDTO>>(Default.JsonSerializerOptions);


        // Assert
        response.EnsureSuccessStatusCode();
        getActivitiesResponse.EnsureSuccessStatusCode();
        Assert.NotNull(activities);
        Assert.True(activities.Any());
    }

    // [Fact]
    // public async Task AddTrail_DeleteTrail_GetById_NotFound()
    // {
    //     // Arrange
    //     var client = _factory.CreateClient();
    //
    //     // Act
    //     var response = await client.PostAsJsonAsync("/api/trail",
    //         new AddTrailRequest(new Point(55, 8), new Point(55, 9), 3f,
    //             TrailDifficulty.Beginner, "", "", "", 1L),
    //         Default.JsonSerializerOptions);
    //     var getTrailsResponse = await client.GetAsync("/api/trail?Page=1&PageSize=15");
    //     var trail =
    //         await getTrailsResponse.Content.ReadFromJsonAsync<IEnumerable<TrailDTO>>(Default.JsonSerializerOptions);
    //     Guid id = trail!.First().Id;
    //     var deleteResponse = await client.DeleteAsync($"/api/trail/{id}");
    //     var getTrailResponse = await client.GetAsync($"/api/trail/{id}");
    //
    //     // Assert
    //     response.EnsureSuccessStatusCode();
    //     getTrailsResponse.EnsureSuccessStatusCode();
    //     deleteResponse.EnsureSuccessStatusCode();
    //     Assert.True(getTrailResponse.StatusCode == HttpStatusCode.NotFound);
    // }
}