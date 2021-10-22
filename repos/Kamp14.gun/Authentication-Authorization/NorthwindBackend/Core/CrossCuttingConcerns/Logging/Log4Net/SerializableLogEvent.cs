using log4net.Core;
using System;
using System.Collections.Generic;
using System.Text;


namespace Core.CrossCuttingConcerns.Logging.Log4Net
{
    [Serializable]
    public  class SerializableLogEvent
    {
        //Bunun serilestirilebilir olmasi gerekiyor

        //Serializable hem Autofac de var hem de .net standartta var o yuzden kafasi karisiyor
        //Bu Autofac ile ilgili bir bug  dir aslinda
        //Bunu cozmek icin Autofac.Extensions.DependencyInjection i nugetpackage den Core katmanina yukleriz

        //SerializableLogEvent aslinda bizim loglayacagimiz datanin kendisini anlatir ve
        //bu sinifin serializable olmasi gerekmektedir

        //LoggingEvent loglanacak datayi anlatiyor
       private LoggingEvent _loggingEvent;//log4net.Core dan gelen LoggingEvent vasitasiyla yapariz

        //Constructor vasitasi ile _loggingEventi geceriz
        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }
        //Ve ek olarak loglama datasinin icerisine ne koymak istiyorsaniz buraya onlari koyuyorsunuz
        //Mesela bu bizim loglama datamizin kendisidir yani LoggerServiceBase de olusturdugumuz 
        //mesaj vardiya bu o iste  public void Info(object logMessage)
        public object Message => _loggingEvent.MessageObject;

        //Biz buraya arzu edersek farkli bilgileri de koyabiliriz mesela UserName gibi yani bu islemi kim yapmis vs gibi...

    
    }
}
