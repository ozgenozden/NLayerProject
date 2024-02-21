using System;
using Entities.Concrete;

namespace Business.Abstract;

public interface ICategoryService
{
    List<Category> GetAll();
    Category Get(int categoryId);
}

