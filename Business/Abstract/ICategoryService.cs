using System;
using Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract;

public interface ICategoryService
{
    IDataResult<List<Category>> GetAll();
    IDataResult<Category> Get(int categoryId);
}

