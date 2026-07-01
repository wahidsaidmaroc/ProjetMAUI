using AutoMapper;
using Moq;
using OrderManagement.Application;
using OrderManagement.Application.ProductService;
using OrderManagement.Domain.Entities;
using OrderManagement.Infra;

namespace OrderManagement.Application.Test;

public class ProductServicesTests
{
    [Fact]
    public void GetProduct_ReturnsNull_WhenProductDoesNotExist()
    {
        var productRepositoryMock = new Mock<IProductRepository>();
        var mapperMock = new Mock<IMapper>();
        productRepositoryMock.Setup(repository => repository.Get(10)).Returns((Product?)null);

        var service = new InvoiceServices(productRepositoryMock.Object, mapperMock.Object);

        var result = service.GetProduct(10);

        Assert.Null(result);
        mapperMock.Verify(mapper => mapper.Map<ProductDto>(It.IsAny<Product>()), Times.Never);
    }

    [Fact]
    public void GetProduct_ReturnsMappedDto_WhenProductExists()
    {
        var product = new Product
        {
            Id = 5,
            ProdName = "Keyboard",
            ProdDescription = "Mechanical keyboard",
            UnitPrice = 99.5m
        };

        var expectedDto = new ProductDto
        {
            Cle = 5,
            Name = "Keyboard",
            Description = "Mechanical keyboard",
            Prix = 99.5m
        };

        var productRepositoryMock = new Mock<IProductRepository>();
        var mapperMock = new Mock<IMapper>();
        productRepositoryMock.Setup(repository => repository.Get(5)).Returns(product);
        mapperMock.Setup(mapper => mapper.Map<ProductDto>(product)).Returns(expectedDto);

        var service = new InvoiceServices(productRepositoryMock.Object, mapperMock.Object);

        var result = service.GetProduct(5);

        Assert.NotNull(result);
        Assert.Equal(expectedDto.Cle, result!.Cle);
        Assert.Equal(expectedDto.Name, result.Name);
        Assert.Equal(expectedDto.Description, result.Description);
        Assert.Equal(expectedDto.Prix, result.Prix);
        mapperMock.Verify(mapper => mapper.Map<ProductDto>(product), Times.Once);
    }
}