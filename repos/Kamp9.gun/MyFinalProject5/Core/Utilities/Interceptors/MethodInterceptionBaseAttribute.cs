using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public  class MethodInterceptionBaseAttribute:Attribute, IInterceptor
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)//IInterceptor implement edildigi icin burasi
                                                             //ordan otomatik gelir
        {
            //Icini bos biraktik onu dolduracagiz!!!!
        }
    }
}
