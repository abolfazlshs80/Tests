
using FluentAssertions;
using Tests.Src.UnitTests.NewExamples;
using Xunit;

namespace Tests.UnitTests.NewExamples;

public class ProductServiceTests
{
    private readonly ProductService _sut;

    public ProductServiceTests()
    {
        _sut = new ProductService();
    }

    [Fact]
    public void AddProduct_ValidData_ShouldAddProduct()
    {
        // Act
        var result = _sut.AddProduct("Laptop", 50000000, 5);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(1);
        result.Name.Should().Be("Laptop");
        result.Price.Should().Be(50000000);
        result.Stock.Should().Be(5);
    }

    [Fact]
    public void AddProduct_EmptyName_ShouldThrowException()
    {
        // Act
        var act = () => _sut.AddProduct("", 1000, 5);

        // Assert
        act.Should()
            .Throw<ArgumentException>()
            .WithMessage("Name is required");
    }

    [Fact]
    public void AddProduct_ZeroPrice_ShouldThrowException()
    {
        // Act
        var act = () => _sut.AddProduct("Laptop", 0, 5);

        // Assert
        act.Should()
            .Throw<ArgumentException>()
            .WithMessage("Price must be greater than zero");
    }

    [Fact]
    public void AddProduct_NegativePrice_ShouldThrowException()
    {
        // Act
        var act = () => _sut.AddProduct("Laptop", -100, 5);

        // Assert
        act.Should()
            .Throw<ArgumentException>()
            .WithMessage("Price must be greater than zero");
    }

    [Fact]
    public void AddProduct_NegativeStock_ShouldThrowException()
    {
        // Act
        var act = () => _sut.AddProduct("Laptop", 1000, -1);

        // Assert
        act.Should()
            .Throw<ArgumentException>()
            .WithMessage("Stock cannot be negative");
    }

    [Fact]
    public void GetById_ExistingProduct_ShouldReturnProduct()
    {
        // Arrange
        var addedProduct = _sut.AddProduct("Mouse", 500, 10);

        // Act
        var result = _sut.GetById(addedProduct.Id);

        // Assert
        result.Should().NotBeNull();
        result!.Name.Should().Be("Mouse");
        result.Price.Should().Be(500);
    }

    [Fact]
    public void GetById_NonExistingProduct_ShouldReturnNull()
    {
        // Act
        var result = _sut.GetById(999);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public void DeleteProduct_ExistingProduct_ShouldReturnTrue()
    {
        // Arrange
        var product = _sut.AddProduct("Keyboard", 2000, 3);

        // Act
        var result = _sut.DeleteProduct(product.Id);

        // Assert
        result.Should().BeTrue();
        _sut.GetById(product.Id).Should().BeNull();
    }

    [Fact]
    public void DeleteProduct_NonExistingProduct_ShouldReturnFalse()
    {
        // Act
        var result = _sut.DeleteProduct(999);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void GetAll_AfterAddingTwoProducts_ShouldReturnTwoProducts()
    {
        // Arrange
        _sut.AddProduct("Laptop", 50000, 2);
        _sut.AddProduct("Mouse", 500, 10);

        // Act
        var result = _sut.GetAll();

        // Assert
        result.Should().HaveCount(2);
        result.Should().Contain(p => p.Name == "Laptop");
        result.Should().Contain(p => p.Name == "Mouse");
    }
}

