using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net;
using Core.Utilities.Interceptors;
using Core.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Core.Aspects.Autofac.Logging
{
   public class LogAspect:MethodInterception
    {
        //Burda loglamayi nerde yapmak istedigimiz bize kalmis yani bu is ihtiyaclarina gore degiskenlik
        //gosterebilir
        //Genellikle bilgi anlamindaki loglama methoda girildigi anda method cagirildiginda gerceklestirilir
        //Ama bazende ozellikle yapilan islemleri kontrol altina almak icinde metod sonunda bu islem yapilabilir
        //Method icinde ihtiyaca gore degerler degistiriliyor olabilir o zaman method sonunda yapilabilir

        //Veya bir loglama islemi de uygulama hata verdigiinde olabilir
        //Benim burda LoggerServiceBase e ihtiyacim var burasi bizim loglayicilarimizi anlatiyordu
        //Bu sistemde soyle bir teknikle calismak istiyorum 
        
        private LoggerServiceBase _loggerServiceBase;
        //Neden LoggerServiceBase i burda kullaniyoruz cunku LoggerServiceBase bizim DatabaseLogger,
        //FileLogger ve bundan sonra yazacagimiz logger turlerinin referansini tutuyor yani 
        //biz _loggerServiceBase yerine DatabaseLogger veya FileLogger i da atayabiliriz cunku onlar
        //da birer LoggerServiceBase dir ayni zamanda
        //Ornegin ProductManager da herhangi bir method ustune gelip [LogAspect(typeof(FileLogger))] seklinde
        //bir yontem kullanacagim.Bundan dolayi bir constructor olusturacagiz ve constructor dan bir type istiyor
        //olmamiz gerekiyor attribute oldugu icin
        public LogAspect(Type loggerService)
        {
         
            //!typeof(LoggerServiceBase).IsAssignableFrom(loggerService)
            //loggerService.BaseType!=typeof(LoggerServiceBase)
            if (loggerService.BaseType != typeof(LoggerServiceBase))
            {
                throw new System.Exception(AspectMessages.WronLoggerType);
            }

            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
            //Burda serviceTool da kullanabiliriz aslinda fakat biz burda kullanicidan aliyoruz tipi ondan dolayi
            //farkli bir durum var burda ama sunu da diyebiliriz, hayir kullanicidan istemiyorum yani constructorda
            //parametre vermeyiz ve ben direk olarak dependencyinjection da ne atarsam onu alsin ornegin DatabaseLogger
            //veya FileLogger olabilir ona gore de sen yontemini secebilirsin
            //biz _loggerServiceBase yerine DatabaseLogger veya FileLogger i da atayabiliriz cunku onlar
            //da birer LoggerServiceBase dir ayni zamanda

        }
        //Elimizde artik bir _loggerServiceBase var artik nerde kullanacaksan ona gore override icini dolurrabiliriz

        protected override void OnBefore(IInvocation invocation)
        {
            //Burda cagirilan operasyonun ismini,parametrelerini almam gerekiyor.Onun icin hemen altta
            //basit bir method yazacagiz LogDetail adinda
            _loggerServiceBase.Info(GetLogDetail(invocation));
        }
        //GetLogDetail methodu ile log detaylarina ulastigimiza gore artik bunu
        //_loggerServiceBase.Info() parametresine gonderebiliriz

        //LogDetail varlik objesini yani property nesnesini biz CrossCuttingConcers de Loggin klasoru
        //altinda zaten olusturmustuk ve parametreleri MethodName ve LogParameters idi 
        
        //Biz LogDetail methodunu OnBefore icine de yazabilrdik ama disina yazdik cunku daha sonra
        //biz eger OnAfter veya diger interceptor alternatiflerini kullanmak istersek her seferinde
        //gidip onlarin icine bunu yazmaylim burda birkez yazalim ve bundan sonra yazma ihtimalimiz
        //olan OnAfter,OnSuccess de de kullanabilelim diye.Kendimizi tekrar etmemek icin....
        private LogDetail GetLogDetail(IInvocation invocation)
        {
            //Name icin bir problemimiz vardi invocation.Arguments de biz parametre ismini alamiyoruz
            //Yani categoryId yi alamiyoruz onu farkli bir yontemle alabiliyoruz
            //bizde bir tane logParameters adinda liste olusturduk
            //Onu   Name = invocation.GetConcreteMethod().GetParameters()[i].Name bu sekilde alabiliyoruz
            //Gelen parametre obje olursa yani property nesnesi olursa onu da reflection ile icerigini okyabilriz
            //Ve onu da json formati ile yazabiliriz...
            //Bunlardan yola cikarak biz kullanici adini alma,claim leri alma vs herseyi dahil edebilirz buna
            var logParameters = new List<LogParameter>();
            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i].GetType().Name
                });
            }

            var logDetail = new LogDetail
            {
                MethodName = invocation.Method.Name,
                LogParameters = logParameters
            };

            return logDetail;
        }
        //Bunlari new leyiruz bunlar varlik, obje oldugu icin bunlarin new lenmesinde 
        //herhangi bir sakinca yok....
    }
}



