using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using OrderManagement.Application.CategoryService;
using OrderManagement.Application.ProductService;

namespace OrderManagement.API.Test;

public sealed class OrderManagementApiFactory : WebApplicationFactory<Program>
{
    public Mock<IProductService> ProductServiceMock { get; } = new();

    public Mock<ICategoryService> CategoryServiceMock { get; } = new();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.RemoveAll<IProductService>();
            services.RemoveAll<ICategoryService>();

            services.AddSingleton(ProductServiceMock.Object);
            services.AddSingleton(CategoryServiceMock.Object);
        });
    }
}