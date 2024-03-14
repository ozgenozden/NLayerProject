using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
//using Business.ValidationRules.FluentValidation;
//using Core.Aspects.Autofac.Validation;
//using Core.Business;
//using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using static Core.Aspect.Autofac.Caching.EmptyClass;

namespace Business.Concrete;

public class ProductManager : IProductService
{
    IProductDal _productDal;
    ICategoryService _categoryService;

    public ProductManager(IProductDal productDal, ICategoryService categoryService)
    {
        _productDal = productDal;
        _categoryService = categoryService;
    }

    [SecuredOperation("product.add,admin")]
    [ValidationAspect(typeof(ProductValidator))]
    [CacheRemoveAspect("IProductService.Get")]
    public IResult Add(Product product)
    {
   
        //ValidationTool.Validate(new ProductValidator(), product);

        IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId ),
           CheckIfProductNameExists(product.ProductName), CheckIfCategoryCount(_categoryService));


        if (result != null)
        {
            return result;
        }

        _productDal.Add(product);
        return new SuccessResult(Messages.ProductAdded);
       
    }

    public IDataResult<List<Product>> GetAllByCategoryId(int id)
    {
        return new DataResult<List<Product>>(_productDal.GetAll(p=>p.CategoryId==id),true);
    }
 
    [CacheAspect]
    public IDataResult<List<Product>> GetAlll()
    {
        //if (DateTime.Now.Hour != 22)
        //{
        //    return new ErrorDataResult<List<Product>>(Messages.ProductNameInvalid);
        //}

            return new DataResult<List<Product>>(_productDal.GetAll(),true,Messages.ProductHasBeenListed);
    }

    [CacheAspect]
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


    private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
    {
        var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count();
        if(result>=10)
        {

            return new ErrorResult(Messages.ProductOfCategoryError);
        }
        return new SuccessResult();
    }

    private IResult CheckIfProductNameExists(string productName) {
        var result = _productDal.GetAll(p => p.ProductName == productName).Any();
        if (result )
        {
            return new ErrorResult(Messages.ProductNameAlreadyExists);
        }
        return new SuccessResult();
    }

    private IResult CheckIfCategoryCount(ICategoryService categoryService)
    {
        var result = _categoryService.GetAll().Data.Count();
        if (result>=15)
        {
            return new ErrorResult(Messages.ProductOfCategoryError);
        }
        return new SuccessResult();
    }

    public IResult AddTransactionTest(Product product)
    {
        throw new NotImplementedException();
    }
}

