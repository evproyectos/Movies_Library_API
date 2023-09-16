using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Movies_Library_API.Controllers;
using Movies_Library_API.Models.Data;
using Movies_Library_API.Models.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Movies_Library_API.Tests.Controller;

public class Genres_Controller_Test : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly MoviesBDContext _context;
    private readonly WebApplicationFactory<Program> _factory;

    public Genres_Controller_Test(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _context = A.Fake<MoviesBDContext>();
    }

    [Fact]
    public async Task GenresController_GetGenres_ReturnSuccessAsync()
    {
        //Arrange
        var fakeDbSet = A.Fake<DbSet<Genre>>();
        var genres = new List<Genre>
            {
                // Create some fake Genre objects here
            };

        A.CallTo(() => _context.Genres).Returns(fakeDbSet);
        
        var client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddScoped(_ => _context);
                });
            }).CreateClient();
        //Act
        var response = await client.GetAsync("/api/genres/genres");

        //Assert
        response.EnsureSuccessStatusCode();
        var content  = await response.Content.ReadAsStringAsync();
        var genresResponse = JsonConvert.DeserializeObject<IEnumerable<Genre>>(content);
        Assert.NotNull(genresResponse);
    }   

}
