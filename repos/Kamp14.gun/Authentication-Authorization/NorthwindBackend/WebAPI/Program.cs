using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)


            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            //birde container ekleyecegiz icinde hangi modulleri kullanacagiz
            .ConfigureContainer<ContainerBuilder>(builder =>
            {//.net core ile gelen bir operasyon
             //Sen hangi serviceprovider factory sini kullanacaksin demektir
             //Bizde kendi yapisini degilde Autofac i kullan deriz
             //using Autofac.Extensions.DependencyInjection; den gelir
                builder.RegisterModule(new AutofacBusinessModule());
            })


                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
//Biz Business tarafinda Autofac ile yaptigmiz IoC container islemi ni WebApi ye bildirme islemini
//WebAPI icinde CreateHostBuilder icesinde yapmamiz gerekiyor
//Bizim bir pakete ihtiaycimiz var adi Autofac.Extensions.DependencyInjection
//Autofac.Extensions.DependencyInjection=>Micorosoft icindeki mevcut dependency injection yapisinin
//implementasyonu demektir.Biz Autofac.Extensions.Dependency.Injection yukleyince projemizin icine
//otomatikmen Autofac i de getirecektir