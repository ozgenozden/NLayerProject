// See https://aka.ms/new-console-template for more information


using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;



//foreach (var item in productManager.GetAlll())
//{
//    Console.WriteLine("Product name : " + item.ProductName + " product Price : " + item.UnitPrice);
//}


//CategoryManager();

//ProductManager();

ProductDetailManager();

static void ProductManager()
{
    ProductManager productManager = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));
    foreach (var item in productManager.GetByUnitPrice(7, 6).Data)
    {
        Console.WriteLine("Product name : " + item.ProductName + " product Price : " + item.UnitPrice);
    }
}


static void ProductDetailManager()
{
    ProductManager productManager = new ProductManager(new EfProductDal(),new CategoryManager(new EfCategoryDal()));
    foreach (var item in productManager.GetProductDetail().Data)
    {
        Console.WriteLine("Product name : " + item.ProductName + "------ Category Name : " + item.CategoryName);
    }

    Console.WriteLine("Mesaj = " + productManager.GetProductDetail().Message);
}


static void CategoryManager()
{
    CategoryManager categoryManager= new CategoryManager(new EfCategoryDal());
    foreach (var item in categoryManager.GetAll().Data)
    {
        Console.WriteLine("Category name : " + item.CategoryName + " Category Id : " + item.CategoryId);
    }
}