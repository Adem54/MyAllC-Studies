using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.jwt;
using DataAccess.Abstract;
using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
  public  class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

           
            //Iste bu kod ile Autofac in Autofac.Extras.DynamicProxy si sayesinde
            //Aspect lerimiz Interceptorlerimiz yani attribute lerimiz methodumuzun arasina girip
            //orda 
            //var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            //builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().
            //    EnableInterfaceInterceptors(new ProxyGenerationOptions()
            //    {
            //        Selector = new AspectInterceptorSelector()
            //    }).SingleInstance();


            //---

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
           
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
             .EnableInterfaceInterceptors(new ProxyGenerationOptions()
             {
                 Selector = new AspectInterceptorSelector()
             }).SingleInstance();

            //--



        }
    }
}
