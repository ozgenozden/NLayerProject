using System;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Ninject.Modules;

namespace Business.DependecyResolves;

	public class NinjectBusinessModule: NinjectModule
{
    
        public override void Load()
        {

        this.Bind<IProductService>().To<ProductManager>();
        this.Bind<IProductDal>().To<EfProductDal>();
        this.Bind<ICategoryService>().To<CategoryManager>();
        this.Bind<ICategoryDal>().To<EfCategoryDal>();



    }
    
}

