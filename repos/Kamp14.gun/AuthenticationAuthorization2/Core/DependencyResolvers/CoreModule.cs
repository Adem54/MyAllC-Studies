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
            services.AddMemoryCache();
            //Artik servisimiz hazir sayilir ve AddMemoryCache yi kullanacagimizi bu sekilde
            //.Net e bildiririz ki Cache ile ilgili .Net altyapisini kullanabilelim.Tabi ki bizim 3.parti
            //uygulamalrda kullanmak isteersek o zaman da onu bildiririz biz kullanacagiz diye ve artik
            //onun ozelliklerini kullaniriiz....
            services.AddSingleton<ICacheManager, MemoryCacheManager>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //using Microsoft.AspNetCore.Http;
            services.AddSingleton<Stopwatch>();

        }
    }
}
