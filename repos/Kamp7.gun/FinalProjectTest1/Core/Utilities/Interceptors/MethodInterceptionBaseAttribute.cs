using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Interceptors
{//Burasi Base bir attribute ttur heryerde olacak yani inherit edilecek!!
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)//IInterceptor implement edildigi icin burasi
            //ordan otomatik gelir
        {
            //Icini bos biraktik onu dolduracagiz!!!!
        }
    }

    // //INTERCEPTION NEDIR VE Intercept methodu ne icin vardir?
    //MethodInterceptionBaseAttribute icindeki Intercept in icini biz burda doldururuz!!!!!!
    //Interception zaten is ihtiyacina gore methoda girmeden once,sonra,hata durumunda gibi
    //durumlarda araya girerek istedigimiz mudaheleyi yapmak icin vardi ve bu araya girme islemi
    //Run-time yani calisma aninda yapiliyor bu Run-time de araya girme islemini ise
    //Autofac alt yapisi ile yerine getiriyor
    //Intercept methodu ile biz araya gireriz yani

}
