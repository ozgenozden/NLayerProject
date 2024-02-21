using System;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory;

public class InMemoryProductDal : IProductDal 
{

    List<Product> _products;
    public InMemoryProductDal()
    {
        _products = new List<Product>
        {
            new Product{ProductId=1,CategoryId=1, ProductName="Glass", UnitPrice=15, UnitsInStock=15},
            new Product{ProductId=2,CategoryId=1, ProductName="Camera ", UnitPrice=1500, UnitsInStock=45},
            new Product{ProductId=3,CategoryId=2, ProductName="Phone", UnitPrice=2345, UnitsInStock=98},
            new Product{ProductId=4,CategoryId=2, ProductName="Keyboard", UnitPrice=5435, UnitsInStock=96}, 
            new Product{ProductId=5,CategoryId=2, ProductName="Mouse", UnitPrice=345, UnitsInStock=87}
        };

         
    } 
    public void Add(Product product)
    {
        _products.Add(product);

    }

    public void Delete(Product product)
    {

       Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
        _products.Remove(productToDelete);
    }

    public Product Get(Expression<Func<Product, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public List<Product> GetAll()
    {
        return _products;
    }

    public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
    {
        throw new NotImplementedException();
    }

    public List<Product> GetByCategory(int categoryId)
    {
        List<Product> productToGetByCategory = _products.Where(p => p.CategoryId==categoryId).ToList();
        return productToGetByCategory; 

    }

    public List<ProductDetailDto> GetProductDetail()
    {
        throw new NotImplementedException();
    }

    public void Update(Product product)
    {
        Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

        product.ProductName = productToDelete.ProductName;
        product.CategoryId = productToDelete.CategoryId;
        product.UnitPrice = productToDelete.UnitPrice;
        product.UnitsInStock = productToDelete.UnitsInStock;
    }
}

