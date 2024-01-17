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
    public async Task GetActivities_AddActivity_Success()
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

    [Fact]
    public async Task AddActivity_DeleteActivity_GetById_NotFound()
    {
        // Arrange
        var client = _factory.CreateClient();
    
        // Act
        var response = await client.PostAsJsonAsync("/api/activity",
            new AddActivityRequest("", "", new Point(5,8),""),
            Default.JsonSerializerOptions);
        var getActivitiesResponse = await client.GetAsync("/api/activity?Page=1&PageSize=15");
        var activity =
            await getActivitiesResponse.Content.ReadFromJsonAsync<IEnumerable<ActivityDTO>>(Default.JsonSerializerOptions);
        Guid id = activity!.First().Id;
        var deleteResponse = await client.DeleteAsync($"/api/activity/{id}");
        var getActivityResponse = await client.GetAsync($"/api/activity/{id}");
    
        // Assert
        response.EnsureSuccessStatusCode();
        getActivitiesResponse.EnsureSuccessStatusCode();
        deleteResponse.EnsureSuccessStatusCode();
        Assert.True(getActivityResponse.StatusCode == HttpStatusCode.NotFound);
    }
}