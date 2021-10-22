using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Interceptors
{
 public abstract class MethodInterception:MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation,System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }

        //BU NESNE ARACILIGI ILE TUM CROSSCUTTINGCONCERN LERIMIZ METHOD UN NERESINDE CALISACAKSA
        //KENDI ASPECT INI INTERCEPT METHODUNU OVERRIDE EDEREK OLUSTURUR.....
        public override void Intercept(IInvocation invocation)
        {
            //Bu tum interceptorlerimizin kullanacagi, yani cross cutting concerns lerimiz olan
            //araya girerek method oncesi, sonrasi,hata exception durumu veya success durumunda
            //araya girip calisacak olan tum crosscuttingconcersn lerin kullanaccagi ortak try-catch
            //blogudur...
            var isSuccess = true;
            //Burda bir methodun calismasini nasil yorumlayacagiz nasil, simule ederiz onu yapacagiz
            //Bir methodun nasil ele alinacagini yazmis olduk ve bu tum cross-cutting concerns leri
            //miz icin ortak bir altyapidir....Biz hangisi neye ihtiyaci varsa onu kullandiracagiz
            //Zaten bir virtual method olusturduk istersek bos birakiyoruz, istersek de icini dolduruyoruz

            OnBefore(invocation);
            try
            {
                invocation.Proceed();//Eger hata yoksa methodu calistir
            }
            catch (Exception e)
            {

                isSuccess = false;
                OnException(invocation,e);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }

            OnAfter(invocation);
        }
    }
}
