using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
   public class ExceptionMiddleware
    {
        //Bir middleware yazmak icin bir request delegasyonuna ihtiyac vardir
        private RequestDelegate _next;
        //Microsoft.AspNetCore.Http;  RequestDelegate burdan geliyor
        //next bizim siradaki middleware imiz demektir
        //Ve bunu constructor a gecirelim
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        
        //Middleware yazimi ile ilgili dokumantasona bakarsak orda bu sekilde yazildigni borebiliriz
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {//Operasyonu calistir operasyonu calistirdigimiz noktada bir hata olursa
                //burdaki operasyonu calistir

                await HandleExceptionAsync(httpContext,e);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            httpContext.Response.ContentType = "application/json";
            //ASP nin bilmedigi bir sistemi dahil ediyoruz onun icin bunlari girmekte fayda var
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
          //ValidationException icin bir istisna kontrolu yapiyoruz....
            string message = "Internal Server Error";
            if (e.GetType()==typeof(ValidationException))
            {
                message = e.Message;
            }

            //Calistirilmaya calisilan operasyon olurda bir hata verirse
            return httpContext.Response.WriteAsync(new ErrorDetails
            {
                StatusCode=httpContext.Response.StatusCode,
                Message=message
            }.ToString());
            //ToString dedigmizde de malumm o nesneyi serilestiriyordu...
        }
    }
}
