using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Core.Aspects.Autofac.Transaction
{
 public  class TransactionScopeAspect:MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope=new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    transactionScope.Complete();
                    //Eğer kod try bloğunun son satırına kadar başarılı bir şekilde
                    //gelebilirse TransactionScope nesne örneğine ait Complete metodunun
                    //çağırılması ile, yapılan tüm işlemlerin onaylanması sağlanmaktadır.
                    //(Elbette catch bloğuna girilmesi halinde ilgili Transaction
                    //içeriğinin Rollback edilmesi  süreci de otomatik olarak işletilecektir) 
                }
                catch (System.Exception)
                {
                    transactionScope.Dispose();
                    //. Zaten sqlconnection'un Close() metodu var,bu metot bağlantıyı kapatır.
                    // Dispose() metodunun farkı şudur; bu metot örneklediğiniz ve
                    // referans gösterdiğiniz nesneyi bellekten atar... 
                    // Bellekten atmak ile kapatmak farklı şeylerdir,dikkatinizi çekerim..
                    // . Bir nesneyi kapatsanız dahi o,bellekte kalır..
                    // .Bellekten atılan bir şey ise ne kapatılabilir,ne de açılabilir...
                    // sqlconnection üzerinde Dispose()yaptıktan sonra open() veya 
                    // close() metotlarından herhangi birini çağırırsanız program kırılacaktır
                    // ...
                    throw;
                }

            }
        }
    }
}
