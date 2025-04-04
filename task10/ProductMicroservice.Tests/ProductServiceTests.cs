using ProductMicroservice.Models;
using ProductMicroservice.Services;
using ProductMicroservice.Data;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Threading.Tasks;

public class ProductServiceTests
{
    private ProductService GetService()
    {
        var options = new DbContextOptionsBuilder<ProductContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        var context = new ProductContext(options);

        return new ProductService(context); // ✅ Only pass context
    }

    [Fact]
    public void AddProduct_ShouldAddAndReturnProduct()
    {
        // Arrange
        var service = GetService();
        var product = new Product { Name = "Test Product", Price = 9.99M };

        // Act
        service.AddProduct(product); // ✅ Call the correct method

        // Assert
        var result = service.GetProductById(product.Id);
        Assert.NotNull(result);
        Assert.Equal("Test Product", result?.Name);
    }
}
