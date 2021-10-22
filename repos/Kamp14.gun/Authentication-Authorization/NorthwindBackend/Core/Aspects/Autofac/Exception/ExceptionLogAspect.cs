using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net;
using Core.Utilities.Interceptors;
using Core.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Aspects.Autofac.Exception
{
    public class ExceptionLogAspect : MethodInterception
    {
        //Burda biz override ederek hata oldugunda calistirmak istiyoruz o yuzden onException i override
        //ederiz ama biz tabi is ithiyacimiza gore burada baska seyleri de ovverride edebiliriz...

        //Bir loggerServiceBase vardi bir tane ve bu LogAspect te Type olarak constructor da veriliyordu
        //loggerServiceBase FileLooger ve DatabaseLogger in referansini tutan base nesne idi
        //Biz de burda constructor da verelim..
        private LoggerServiceBase _loggerServiceBase;
        //Bizim burda yaptigimi hata donusleri ve kullaniciyi yonlendirme cabamiz programciya yoneliktir
        //Yani bunu programci tabi ki test edip de zaten yayina sokmalidir
        public ExceptionLogAspect(Type loggerService)
        {
            if (loggerService.BaseType != typeof(LoggerServiceBase))
            {
                throw new System.Exception(AspectMessages.WronLoggerType);
                //Burda magic string ile donus yapmis olduk zaten magic string in amaci ayni hataya 
                //ayni sekilde mesaj vermek surekli farkli bir string yazmak degil...
            }
            //Burasi compiletime icindir yoksa zaten LoggerServiceBase e bir nesne atanacak.....
            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
        }

        protected override void OnException(IInvocation invocation, System.Exception e)
        {
            LogDetailWithException logDetailWithException = GetLogDetail(invocation);
            //Benim bu operasyonun ortaya cikardigi hatayi yakalamam gerekiyor.Invocation method
            //bilgisi orda exception yok...Invocation dan bize sadece method bilgileri gelir..
            //GetLogDetail ile biz sadece LogParameters ve LogName i alabilirim yani invocation
            //icinde exception bilgisi yok.
            //O zaman ne yapacagiz o zaman ExceptionMessage datasini ayrica set etmem gerekiyor
            logDetailWithException.ExceptionMessage = e.Message;
            //e burda exception dir ve System.Exception dan gelir ve biz burda onu alabilmek icin
            //System.Exception i parametreye ekledik ama bu sefer de override methodu patladi neden
            //geldigi yer olan MethodInterception da tek parametreli olusturuldugu icin o zaman bizde
            //MethodInterception icinde onException parametresine System.Exception ekleriz
            //Bir de bizim elimizde _loggerServiceBase de var ve onu biz burda Error formatini aliyoruz
            //normalde diger formatlarimzda vardir logservicebase in info gibi ama bu error artik
            //Cunku biz burda veritabanina olusan errorlari duzenli bir sekilde yazmak istiyoruz...
            //Ve error formatinda filtreleyebilmek istiyorum bir where kosulu atarak filtreleyebilmek
            //istiyorum..
            _loggerServiceBase.Error(logDetailWithException);

        }

        private LogDetailWithException GetLogDetail(IInvocation invocation)
        {
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

            var logDetailWithException = new LogDetailWithException
            {
                MethodName = invocation.Method.Name,
                LogParameters=logParameters
            };
            return logDetailWithException;
        }
    }
}
