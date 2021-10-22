using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions;
using Business.Constants;

namespace Business.BusinessAspect.Autofac
{
   public class SecuredOperation:MethodInterception
    {
        private string[] _roles;//Bu bizim ProductManager da methodun ustune yazacagimiz
        //SeucuredOperationAspectimizin icindeki string yetki....
        private IHttpContextAccessor _httpContextAccessor;
        //[SecuredOperation("Product.List,Admin")] Tirnak icindeki tek bir stringdir aralarinda
        //virgul olsa bile onlar tek bir stringgdir biz onlari virgulle ayri ayri stringler haline
        //getirip bir diziye atiyoruz..._roles adindaki sonra da bunlar kullanicinin rolleri
        //arasinda var mi diye sorgulayacagiz asagida....

        public SecuredOperation(string roles)//1 tane string bu 

        {
            _roles = roles.Split(',');//Bunlari virgulle ayir ve rol arrayine at diyoruz...
           _httpContextAccessor=ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }
        //Kullanicinin claimleri var ve operasyonun talep ettigi yetkiler var yani
        //[SecuredOperation("Product.List,Admin")]
        //Bunu operasyon talep ediyor ve diyorki benimle calisacaksan senin "Product.List,Admin"
        //yetkilerin olmali diyor
        //Bu yetkiler operasyonun talep ettigi yetkiler
        //Birde kullanicinin rolleri var
        //Birde elimizde IHttpContextAccessor vardi ona nasil erisecegiz burda...
        //Burda biz IHttpContexAccessor i dependency injection ile constructor injection ile buraya
        //verip kullanmak  isteyebiliriz ama dependencyinjection olayi burda IHttpContextAccessor
        //icin islemiyor yani sistem bunu cozemiyor dependeny injection da biz gidip de
        //bunun  interface i ile somutunu yazdigimiz zaman sistem HttpContextAccessor u cozemiyor
        //Neden cozemiyor cunku cozumlemenin basladigi yer controller dir cunku controller geliyor
        //Once ordaki IProductService yi ve ProductManageri cagiriyor sonra ProductManager a gelip orda 
        //IProductDal ve EfProductDal i cagiriyor yani orda bir tane chain-zincir var dependency zinciri
        //bagimlilik ziniciri var bir tane ve tamamen olay controller dan gittigi icin
        //Ve SecuredOperation dosyamizin icindeki IHttpContextContext in hicbirsekilde bagimlilik cozme
        //sistemi ile alakasi yok.Ama biz de zaten bunu cozmek icin bir arac yazmistik zaten
        //Bu aracimizin adi da ServiceTool du zaten biz bunu cozmek icin yazmistik... 
        //Yani bizim yazdigimiz arac uzerinden bizim icin IHttpContextAccessor u bana coz dememiz gerekiyor
        // ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        //using Microsoft.Extensions.DependencyInjection; bunu unutmayalimm....
        //Artik elimizde kisinin claimlerine erisebilecegim bir yapi var....

        //Operasyon baslamadan calismasini istiyoruz
        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            //Rollere ulastigimiza gore , simdi kullanicinin talep ettgi roller bende var mi
            //onu cek etmem gerekiyor
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))//roleClaims eger kullanicinin verdigi rollerden
                    //bir tanesi varsa direk return et
                {
                    return;//Buraya gelirse demekki rollerden biri var
                }
                throw new Exception(Messages.AuthorizationDenied);
            }
        }
    }
}
//Artik biz bunu kullanabilir durumdayiz...