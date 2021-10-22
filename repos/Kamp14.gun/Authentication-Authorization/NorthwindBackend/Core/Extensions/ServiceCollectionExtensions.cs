using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
  public static class ServiceCollectionExtensions
    {
        //public static yazariz extension yazacagimiz icin...
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection services,
            ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(services);//Tum modulleri bu operasyon vasitasiyle .netcore e ekleyecegiz..
            }

            return ServiceTool.Create(services);
            //ServiceTool bizim servislerimiz yapilandiran operasyon utilities idi
        }
      //Bunu kullanarak Api tarafinda butun merkezi konfigurasyonlarimi ekliyor olacagim
      //Merkezi modullerimizi artik burya array olarak verebilecegiz...parametre olarak
      //services.AddDependencyResolvers(modules) yazabilecegiz artik!!!!!!
    }
}
