using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
  public  class AutofacBusinessModule:Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            //Bu blok uygulama hayata gectigi zaman,yayinlandigi zaman calisacak olan bloktur
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();
            //Buralar kayit ettigimiz siniflar

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            //Implemente edilmis interface leri bul diyor
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {//Onlar icin AspectInterceptorSelector u cagir diyor
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
