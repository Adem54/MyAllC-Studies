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
            //Buralar kayit ettigimiz siniflar
            //.Net mimarisinde de IOC container vardi ama Autofac bize interceptors yapma imkani da veriyor
            //AOP mimarisini Autofac altyapisini kullanarak yapiyoruz
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

            
           
            //ALTTARAF INTERCEPTORLARIMIZI DEVREYE GIRMESI ICIN YAZDIGIMIZ KODLAR
            //Kaynak kodlari ve metadata bilgilerinin bulundugu birimdir assembly yani derlenmis her
            //bir birimdir aslinda bunlar exe ve dll dir
            //Uygulamanin calisma esnasindaki asembly bilgisine ulasir
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            //Implemente edilmis interface leri bul diyor
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {//Onlar icin AspectInterceptorSelector u cagir diyor
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
            //Bizim tum interceptorlarimizi oncelik sirasina gore siralayarak bir liste halinde 
            //tutan yer AspectInterceptorSelector dur yani Validation,Authorisation,Loglama,Cache
            //Transiction,Performance gibi
            //BU KODLARI AUTOFAC BIZIM ICIN BIZIM KURDUGUMUZ ASPECTINTERCEPTORSELECTOR I SISTEME DAHIL EDIYOR
            //EKLEME YAPARKEN INTERCEPTORLARIN DEVREYE GIRECEGINI BIZ BURDA SOYLUYORUZ ISTE

        }
    }
}
//Autofac bizim icin burda bulunan tum siniflarimiz icin mesela IProductService,IProductDal 
//Diyor ki git bak bunlarin Aspecti var mi yani attribute yani koseli parantezle yazdigimiz
//Aspect dedgimiz zaman aklimza Reflection-Attributes ve Autofac uclusu ve .net in biraraya gelip de
// ortaya cikardigi Validation,Log,Authorisation,Exception,Transiction,Performance,Cache gibi islemlerin
//yapilmasina yarayan attribute lerdir koseli parantez ile yazilan

//BURASI BIZIM AYARLARIMIZI KAYDETTIGIMIZ YERDIR!!!