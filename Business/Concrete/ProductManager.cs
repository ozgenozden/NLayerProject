using System;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete;

public class ProductManager : IProductService
{
    IProductDal _productDal;
    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public IResult Add(Product product)
    {

        if (product.ProductName.Length < 2)
        {
            return new ErrorResult(Messages.ProductNameInvalid);
        }
        _productDal.Add(product);
        return new SuccessResult(Messages.ProductAdded);
    }

    public IDataResult<List<Product>> GetAllByCategoryId(int id)
    {
        return new DataResult<List<Product>>(_productDal.GetAll(p=>p.CategoryId==id),true);
    }

    public IDataResult<List<Product>> GetAlll()
    {
        return new DataResult<List<Product>>(_productDal.GetAll(),true,Messages.ProductHasBeenListed);
    }

    public IDataResult<Product> GetById(int productId)
    {
        return new DataResult<Product>(_productDal.Get(p=>p.ProductId==productId), true);
    }

    public IDataResult<List<Product>> GetByUnitPrice(decimal max, decimal min)
    {
        return new DataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice <= max && p.UnitPrice >= min),true,Messages.ProductHasBeenListed);
    }

    public IDataResult<List<ProductDetailDto>> GetProductDetail()
    {
        if (DateTime.Now.Hour != 22)
        {
            return new ErrorDataResult<List<ProductDetailDto>>(_productDal.GetProductDetail(), Messages.ProductNameInvalid);
        }


        return new DataResult<List<ProductDetailDto>>(_productDal.GetProductDetail(),true,Messages.ProductHasBeenListed);
    }

   
}

