using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Interceptors
{
    //IInterceptor Autofac.Extras.DynamicProxy paketinden geliyor bunu yukleyelim
    //MethodInterceptionBaseAttribute umuz bir Attribute dur attribute olabilmesi icin ise
    //bir attribute u inherit etmesi gerekiyor
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method,
        AllowMultiple =true,Inherited =true)]
    //Inherited=true=>MethodInterceptionBaseAttribute attribute nesnesini inherit eden alt class
    //lar da da attribute olarak kullanilabilsin demektir ondan dolayi zaten 
    //MethodInterceptionBaseAttribute u inherit eden nesne ve onu inherit edeni de inherit edenler
    //bir attributtur yani ondan dolayi zaten MethodInteception da ValidationAspectte bir attribute
    //dur...
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }
        public virtual void Intercept(IInvocation invocation)
        {
           
        }
    }
}
