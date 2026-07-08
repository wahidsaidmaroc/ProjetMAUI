using System.Net;
using System.Net.Http.Json;
using OrderManagement.Application;

namespace OrderManagement.API.Test;

public class CategoryControllerTests : IClassFixture<OrderManagementApiFactory>
{
    private readonly OrderManagementApiFactory _factory;

    public CategoryControllerTests(OrderManagementApiFactory factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Get_ReturnsOkWithCategories()
    {
        _factory.CategoryServiceMock
            .Setup(service => service.GetCategories())
            .Returns(new List<CategoryDto>
            {
                new()
                {
                    Cle = 10,
                    Name = "Accessories",
                    Description = "Computer accessories"
                }
            });

        using var client = _factory.CreateClient();

        var response = await client.GetAsync("/api/Category");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var categories = await response.Content.ReadFromJsonAsync<List<CategoryDto>>();

        Assert.NotNull(categories);
        Assert.Single(categories!);
        Assert.Equal("Accessories", categories[0].Name);
    }

    [Fact]
    public async Task Post_ReturnsBadRequest_WhenNameIsMissing()
    {
        using var client = _factory.CreateClient();

        var response = await client.PostAsJsonAsync("/api/Category", new CategoryDto { Name = "", Description = "Test" });

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}