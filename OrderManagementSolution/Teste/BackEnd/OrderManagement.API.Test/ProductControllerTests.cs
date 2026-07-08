using System.Net;
using System.Net.Http.Json;
using OrderManagement.Application;

namespace OrderManagement.API.Test;

public class ProductControllerTests : IClassFixture<OrderManagementApiFactory>
{
    private readonly OrderManagementApiFactory _factory;

    public ProductControllerTests(OrderManagementApiFactory factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Get_ReturnsOkWithProducts()
    {
        _factory.ProductServiceMock
            .Setup(service => service.GetProducts())
            .Returns(new List<ProductDto>
            {
                new()
                {
                    Cle = 1,
                    Name = "Keyboard",
                    Description = "Mechanical keyboard",
                    Prix = 99.5m
                }
            });

        using var client = _factory.CreateClient();

        var response = await client.GetAsync("/api/Product");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var products = await response.Content.ReadFromJsonAsync<List<ProductDto>>();

        Assert.NotNull(products);
        Assert.Single(products!);
        Assert.Equal("Keyboard", products[0].Name);
    }

    [Fact]
    public async Task GetById_ReturnsBadRequest_ForInvalidId()
    {
        using var client = _factory.CreateClient();

        var response = await client.GetAsync("/api/Product/0");

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}