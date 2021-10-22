using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{//IoC container larda modul kavrami cok kullanilir
    //Modul bu interface in karsiligi budur, su interface in modul karsiligi budur seklinde yazdigmiz
    //yerdir
    //Biz AutofacBusinessModule de de Module nesnesni inherit ederiz Autofac paketinden!!!
    //Module Autofac paketinden geliyor
  public  class AutofacBusinessModule:Module
    {//Module bize override imkani veriyor ordaki Load i kullaniriz..
        protected override void Load(ContainerBuilder builder)
        {
            //Load operasyonu yukleme islmeini yapiyor.Kisacasi bizim IoC container konfigurasyonu
            //yaptigimiz yerdir
            builder.RegisterType<ProductManager>().As<IProductService>();
            //Eger birisi IProductService ile dependency injection yaparsa ona git ProductManager
            //dan bir instance olustur ve onu ver bu yolla binlerce kullaniciya bir kere olusturdugu
            //ProductManager i verir
            builder.RegisterType<EfProductDal>().As<IProductDal>();
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            //Assembly yi olusturduk
            //Olusturdugumuz assembly deki tum tipleri kaydet diyoruz . 
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
             .EnableInterfaceInterceptors(new ProxyGenerationOptions()
             {//ProxyGenerationOptions bir obje old icin onun ozelliklerini verecegiz
                 //Araya girecek olan nesneyi soyle dememiz gerekiyor
                 //Bir tane kendimiz nesne yazacagiz proxy icerisine
                 //Biz birda gidip bir tane AspectInterceptorSelector olusturmamiz gerekiyor
                 //Bu interceptor lerimizin Priority uzerinden hangi siraya gore calisacagini belirler
                 Selector =new AspectInterceptorSelector()
             }).SingleInstance();//SingleInstance() tek bir instance olustursun her seferinde
            //bir suru AspectInstancesi olusmasin
            //new ProxyGenerationException Castle Dynamic Proxy den geliyor
            //Business e de CastleDynamicProxy yi nuget package den ekleriz
            //    
            //Autofac icin Autofac.Extras.DynamicProxy ye ihtiyacimiz var biz bunu kuruyoruz CastleDynamicProxy yerine 
            //O zaman Autofac kendi iicnde Proxyi yi de kuruyor.Cunku CastleDynamicProxy de versiyon sorunu yasiyoruz...
            //Autofac.Extras.DynamicProxy yi hem Core hem de Business e kurariz ve Castle.DynmaicProxyi de her ikisinden de 
            //kaldiririz.Autofac kendi CastleDynamicProxy si ile halleder
            //Proxy o internetten bildgimiz o aglarda kullandigimiz araya girmedir

        }
    }
}
//Projemiz icinde yapacagimiz tum dependency injection lar icin biz bu sayfada onun karsiligini
//veririz
//Bu sayfadaki islemleri yaptiktan sonra bir de Api ye haber vermeliyiz...