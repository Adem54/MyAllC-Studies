using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
   public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection services,
            ICoreModule[] modules)//ICoreModule[] modules=new ICoreModule[]{new CoreModule(),new CoreModule2()}
        {//modules burda CoreModule gibi ICoreModule u implement etmis CoreMOdullerin new lenmis halini
            //yani instancelerini temsil ediyor dolayisi ile bu extentsion i calstirirken
            // paramtreye CoreModule gibi nesnelerden olusan bir ICoreModule tipinde dizi verecegiz
            foreach (var module in modules)
                //Bu moduller ICoreModule u implement edecek moduller olacaklar...
            {
                module.Load(services);//Tum modullerimizi bu operasyon vasitasi ile .NetCore a ekleyecegiz 
            }
            return ServiceTool.Create(services);//Servise baglanma yapilandirmamizi gerceklestiriyoruz
        }
    }
}
//Bunu kullanarak Api tarafinda butun merkezi konfigurasyonlarimi ekliyor olacagim
//Merkezi modullerimizi artik burya array olarak verebilecegiz...parametre olarak
//services.AddDependencyResolvers(modules) yazabilecegiz artik!!!!!!