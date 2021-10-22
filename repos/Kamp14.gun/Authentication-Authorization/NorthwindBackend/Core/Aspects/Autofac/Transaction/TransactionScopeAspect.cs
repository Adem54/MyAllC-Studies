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
        //Bu bir transaction oldugu icin ben onunn yasam dongusunu yontmem gerekiyor ondan
        //dolayi intercept methodunu eziyor olacagim
        //Cunku transaction basinda sonunda degil de tam olarak bir dongu,methodun yasam dongusunde
        //benim kontrol altina almam gerekiuyor..
        public override void Intercept(IInvocation invocation)
        {//Transaction yazmak icin oncelikle TransactionScope u devreye sokmam gerekiyor o
         //System.Transaction dan gelir
         //disposable pattern uyguluyor.. kullanabiliyoruz...
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {//Aslinda bizim Intercept operasyonumuz calisiyor ama o operasyon icinde calistiril
                    //maya calisian method devreye girer...
                    //Methodu bir calistirmaya calis
                    
                    invocation.Proceed();
                    //Buraya gelirse demekki islem calismis
                    //O zaman transaction  i kabul et ve calistir...
                    transactionScope.Complete();
      
                }
                catch (System.Exception)
                {
                    //Hata alirsan da yapilan islemleri geri al ve hata firlat demis oluyoruz...
                    transactionScope.Dispose();
                    throw;
                }
            }
        }
    }
}
