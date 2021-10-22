using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
  public static  class ExceptionMiddlewareExtensions
    {
        //Microsoft.AspNetCore.Builder dan geliyor IApplicationBuilder
        //Startup.cs de middleware lere bakarsak orda da .NetCore dan gelen bu 
        //interface kullaniliyor...burda biz bu interface i extend ettigimiz icin artik
        //Startup.cs de app. deyince ConfigureCustomExceptionMiddleware icinde bir method
        //olarak gelecektir
        //Direk .NetCore dokumantasyonunda bu sekilde oldugu icin onu takip ediyoruz
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            //Normalde direk burayi gidip de Startup.cs ye yazabilirdik ama bu sekilde
            //kodun okunabilirligi acisindan daha sagliklidir
            //Ne is yaptigimiz acikca belli olmus oluyor...
        }
    }
}
