using System;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract;

public interface IProductService
{
    IDataResult<List<Product>> GetAlll();
    IDataResult<List<Product>> GetAllByCategoryId(int id);
    IDataResult<List<Product>> GetByUnitPrice(decimal max, decimal min);
    IDataResult<List<ProductDetailDto>> GetProductDetail();
    IDataResult<Product> GetById(int productId);
    IResult Add(Product product);
    IResult AddTransactionTest(Product product);

}

