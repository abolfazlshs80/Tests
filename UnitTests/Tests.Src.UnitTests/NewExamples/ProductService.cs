using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Src.UnitTests.NewExamples;


public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
}


public class ProductService
{
    private readonly List<Product> _products = new();

    public Product AddProduct(string name, decimal price, int stock)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required");

        if (price <= 0)
            throw new ArgumentException("Price must be greater than zero");

        if (stock < 0)
            throw new ArgumentException("Stock cannot be negative");

        var product = new Product
        {
            Id = _products.Count + 1,
            Name = name,
            Price = price,
            Stock = stock
        };

        _products.Add(product);

        return product;
    }

    public Product? GetById(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }

    public bool DeleteProduct(int id)
    {
        var product = GetById(id);

        if (product is null)
            return false;

        _products.Remove(product);
        return true;
    }

    public List<Product> GetAll()
    {
        return _products.ToList();
    }
}