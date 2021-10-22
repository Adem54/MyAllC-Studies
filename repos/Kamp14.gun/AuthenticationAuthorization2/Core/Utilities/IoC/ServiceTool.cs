using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
  public static  class ServiceTool
    {
        //IServiceCollection ve ServiceProvider ve IServiceProvider property si olan
        //GetService(nesne tipi) uzerinden kendi servisimizi olusturup servise ulasabilecegiz 
        public static IServiceProvider ServiceProvider { get; set; }

        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
        //IServiceCollection Microsoft.Extension.DependencyInjection dan geliyor
        // //Burdaki yapi da ayni o yuzden .Net Core da altyapisi olan bir yapi old icin
        //enjekte islemini kendisi yapiyor zaten...
    }
}
//Servis islemlerimizde ana kullanacagimiz .Net den gelen IServiceCollection ve
//IServiceProvider