using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
  public static  class ServiceTool
        //Uygulamamizin servicecollection nesnesine ve onun da arkasinda olan
        //ServiceProvider ina erismeye calisacagiz..
       //Sistemin servislerini bu tool vasitasiyla kontrol ediyor olacagiz
    {
        //Ayni zamanda bize bir IoC resolver gorevi gorecek bir altyapi olacak
        public static IServiceProvider ServiceProvider { get; set; }
        //ServiceProvider bizim icin merkezi servis yonetim nesnesi olacak
        public static IServiceCollection Create(IServiceCollection services)
        {//kolleksiyon dedigine gore demekki cogul
            ServiceProvider = services.BuildServiceProvider();
          
            return services;
         //Kisacasi ben ServiceTool vasitasi ile .NetCore un kendi servislerine
        //erisebiliyorum ve bu yapilandirma sayesinde MemoryCacheManager.cs de cache e ulasiyorum 
        }
        //IServiceCollection Microsoft.Extension.DependencyInjection dan geliyor
        //Parametrede bana bir tane IServiceCollection ver deriz
        //Aslinda IServiceCollection .NetCore icerisinde default olarak gelen IServiceCollection
        //i, her ne kadar interface olsa bile .net core da bunun karsiligi oldugu icin
        //alt yapida IServiceCollection in ne oldugu belli oldugu icin yani aynen
        //Startup.cs de ConfigurationService parametresindeki 
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddControllers();
        //    services.AddCors(options =>
        //services.AddControllers denildiginde .Net Core un kendi servis collection inin
        //enjekte ediyor
        //Burdaki yapi da ayni o yuzden .Net Core da altyapisi olan bir yapi old icin
        //enjekte islemini kendisi yapiyor zaten...
    }
}
