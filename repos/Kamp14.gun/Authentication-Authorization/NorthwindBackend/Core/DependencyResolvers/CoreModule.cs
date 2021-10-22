using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            //Iste burda artik Startup.cs de services.AddControllers dedigimiz ama merkezi
            //olanlari artik biz buraya yazariz..
            services.AddMemoryCache();//sekkinde ekleyebiliriz artik!!!!
            //Bizim cache islemlerimizi .Net yardimiyla yapabilmemiz icin servise aynen Startup.cs de
            //MemoryCache teknolisinden faydalanacagimizi soyluyoruz burda bu teknolji Micorosofttan 
            //geliyor
            //

            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            //Yarin oburgun biz yeni bir teknolojiye gecersek ornegin Redis e gecersek MemoryCacheManager
            //yerine baska o teknoloji ile olusturulmus bir nesneyi yazacagiz oraya dolayisi ile sistemimiz
            //aynen devam etmis olacak...
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<Stopwatch>();
        }
    }
    //Yani bizim normalde Startup.cs ce Businessdeki DependencyResolvers daki AutofacBusinessModule.cs 
    //da yaptigimiz IoC container gorevini bu sayfada hallediyuoruz...

    //Genel Configurasyonlarimizi yaptigmiz Core altindaki DependencyResolver daki
    //CoreModule da biz genel konfigurasyonlarimizi yapiyorduk….CoreModule de
    //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); ekleriz
    //Bu IHttpContextAccessMicrosoft. AspNetCore. HttpContext den gelir bunu biz hem
    //Core hem de Business da kullanacagimiz icin her ikisine de bu paketi yuklemeliyiz...
}
