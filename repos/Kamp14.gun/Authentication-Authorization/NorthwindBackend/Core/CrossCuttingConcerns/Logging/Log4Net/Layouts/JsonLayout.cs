using log4net.Core;
using log4net.Layout;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.CrossCuttingConcerns.Logging.Log4Net.Layouts
{
    //Bunun bir layout olmasi icin log4net te LayoutSkeleton denilen bir tane base abstract sinif var
    //onu inherit etmesi gerekir ve ayni zamanda implement ederiz...
    public class JsonLayout : LayoutSkeleton
    {
        public override void ActivateOptions()
        {
           //Bunun ici bos kalacak bizim buna ihtiyacimiz yok
           //Opsiyon aktivasyonu daha farkli teknikler icin
        }

        public override void Format(TextWriter writer, LoggingEvent loggingEvent)
        {
            var logEvent = new SerializableLogEvent(loggingEvent);
            //Bu bizim yazdigimiz nesnedir ve constructor parantezindeki loggingEvent loglanacak datayi anlatiyor
            var json = JsonConvert.SerializeObject(logEvent, Formatting.Indented);
            //logEventini serilestir
            //Formatting.Indented demektir ki logu actigimiz zaman tab li yani girintilerinin
            //oldugu yapiyi kastediyoruz
            writer.WriteLine(json);
            //Sonra da altina yaziyoruz
            //Artik elimizde hangi formatta ve neyin nasil yazilacagina dair bir layout mevcuttur
        }
    }
}
