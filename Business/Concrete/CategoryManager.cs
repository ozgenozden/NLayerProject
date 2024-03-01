using System;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class CategoryManager:ICategoryService
{
    ICategoryDal _categoryDal;
	public CategoryManager(ICategoryDal categoryDal)
	{
        _categoryDal = categoryDal;
	}

    public IDataResult<Category> Get(int categoryId)
    {
        return new DataResult<Category>(_categoryDal.Get(c=>c.CategoryId==categoryId),true,"İstenilen ürün getirildi.");
    }

    public IDataResult<List<Category>> GetAll()
    {
        return new DataResult<List<Category>>( _categoryDal.GetAll(),true,"Ürünler getirildi.");
    }
}

