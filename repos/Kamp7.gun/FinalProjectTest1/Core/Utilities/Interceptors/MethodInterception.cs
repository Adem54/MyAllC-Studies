using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;

namespace Core.CrossCuttingConcerns.Validation
{//Burasi cok onemli bir nokta
    //MethodInterception yani araya girecek kodu yazdigimiz nesne demektir 
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
       //IInvocation bizim methodumuzu temsil ediyor
       
        //Onu tam olarak nerde calistirmak istiyorsak orayi calistiracagiz
        //Kendimize temel bir try-catch yazdik burda zaten
        //Tum methodlarim bu IInvocation turundedir biz nereyi doldurursak o calisacak
        //Validation i yazdigimizda sadece OnBefore un icini dolduracagiz digerlerinin icini bos
        //birakacagiz ve OnBefore calisacak
        //Genellikle %90 OnBefore ve Exception calistirilir
        //Burasi tum methodlarin catisidir.Methodlarin hepsi bu kurallardan gececek
        //Aspectte hangisinin icini doldurursan o calisacak
        //Biz bu class imizi gidip ValidationAspect tarafindan inherit ettirecegiz ve orda 
        //asagidakilerden hangisinin icini doldurursa o calisacak
      
       //INTERCEPTION NEDIR VE Intercept methodu ne icin vardir?
        //MethodInterceptionBaseAttribute icindeki Intercept in icini biz burda doldururuz!!!!!!
        //Interception zaten is ihtiyacina gore methoda girmeden once,sonra,hata durumunda gibi
        //durumlarda araya girerek istedigimiz mudaheleyi yapmak icin vardi ve bu araya girme islemi
        //Run-time yani calisma aninda yapiliyor bu Run-time de araya girme islemini ise
        //Autofac alt yapisi ile yerine getiriyor
        //Intercept methodu ile biz araya gireriz yani
        public override void Intercept(IInvocation invocation)//MethodInterceptionBaseAttribute
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
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

