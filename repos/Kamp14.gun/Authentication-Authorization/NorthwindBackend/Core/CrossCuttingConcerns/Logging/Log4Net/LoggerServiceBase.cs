using log4net;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace Core.CrossCuttingConcerns.Logging.Log4Net
{
  public  class LoggerServiceBase
    {//LoggerService bizim log islemimizi yapacak olan sinif olacak dedik
        //Base sinif bir inheritance gorevi gorecek,Base sinif onu belli appender lara gore 
        //implemente ediyor olacagiz

        private ILog _log;//ILog log4net ten geliyor ve log4net paketini yuklemeliyiz
                          //ve kisacasi loglamayi yapacak temel interface leri
        public LoggerServiceBase(string name)
            //string name dedigimiz loglama tipidir yani databaselogger mi, filelogger mi
            //Hatirlayalim su an sistemimizde iki tane logger tipi vardi log4net.config de
            //jsonFileLogger ve DataBaseLogger, bunu verdigimiz zaman onu o log4net.config 
            //icerisinde onu okumamiz gerekiyor.Kisacasi log4net.config dosyasini okumak gerekiyor
            //log4net.config dosyasini XMLDocument vasitasi ile okuyacagiz
            //using System.Xml den gelir
            //File using System.IO dan gelir
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(File.OpenRead(path: "log4net.config"));

            //ILoggerRepostory adi ustunde log4net in repostory si gorevini goruyor olacak
            //Yani artik benim log4Net paketine e ihtiyacim var
            //log4net paketini yukleriz
            //LogManager da log.net den geliyor
            //Bizim icin bir tane repostory olusturacak olusturmak icin bir calisan assembly yi istiyor
            //Birde repostorytype i istiyor
            ILoggerRepository loggerRepository = LogManager.CreateRepository(Assembly.GetEntryAssembly(),
                typeof(log4net.Repository.Hierarchy.Hierarchy));
            log4net.Config.XmlConfigurator.Configure(loggerRepository, xmlDocument["log4net"]);
            //Bu temel bir konfigurasyon yani bir projede kullanacagimiz standart bir konfigurasyondur
          
            _log = LogManager.GetLogger(loggerRepository.Name, name);
            //Kisacasi bizim icin onemli olan bu satir dir.Ilgili konfigurasyonun icerisindeki ilgili isimdeki yani
            //string ile gonderilen isimdeki logger i al biz oraya name yerine ya <logger name="DatabaseLogger"> yada
            // <logger name="JsonFileLogger"> burdaki name deki JsonFileLogger gonderdigimiz zaman bizim icin altyapi tamam oluyor
            //Biz  burda temel anlamda config dosyamizi okumus, ve gonderilen parametreye gore logger in olusmasini saglamis olduk

            //Simdi elimizde bir ILog var logu yapan bu olacak ve biz ILog u GetLogger vasitasi ile 
            //enjekte ediyoruz...
            //Burada log ile yapabilecegimiz cesitli operasyonlar vardir, Debbug gibi , error gibi,fatal,info gibi
            //Yani log turlerine gore calisabilecegimiz bir alt yapi sunuyor bize

        }
        //O zaman biz madem logger servisi uzerinden gidiyoruz o zaman cesitli operasyon lar uzerinden 
        //bu islemi yapabilirim demektir
        

        public bool IsInfoEnabled => _log.IsInfoEnabled;
        //Burda diyorz ki git konfigurasyonuna info acik mi ona bak aciksa dondur...
        //Bu bir methoddur aslinda C#7 ile girdi hayatimiza ve bu sekilde daha hizli operasyonlar 
        //yazabiliyoruz...

        public bool IsDebugEnabled => _log.IsDebugEnabled;
        public bool IsWarnEnabled => _log.IsWarnEnabled;
        public bool IsFatalEnabled => _log.IsFatalEnabled;
        public bool IsErrorEnabled => _log.IsErrorEnabled;


        //Cogunlukla IsInfoEnabled ve IsErrorEnabled kullanilir ama mesela performance icin IsWarnEnabled
        //loglama turu kullanilabilir


        //Info adinda bir method ve parametreye de bana bir tane loglama datasi ver diyorum ve onu tipini object
        //veriyorum cunku turu ne olacak bilmiyorum her tur olabilir...

        public void Info(object logMessage)
        {
            if (IsInfoEnabled)
            {
                _log.Info(logMessage);
            } 
        }
        //Burasi calisacak ama bu direk olarak benim sistemime info islemini gerceklestirecek
        //Ama ben sistemimde konfigurasyon ayarlarindan arzu ettigm zaman info logu alma veya fatal logu alma seklidne konfigurasyonu
        //degistirebilirim.Cunku bazi sistemlerde mesela hepsiburada.com icin blackfriday de loglari azaltmak istiyor sistemi
        //hizlandirmak icin mesela errorloglarini veya fatal loglari vs kapatmak istiyor yani biz istedigimiz zamanda bu sekilde
        //kapatip acacak sekilde ayarlamak istiyoruz yani surekli her halukarda calissin istemiyoruz...
        //Ondan dolayi bizde kendimize basit bir implementasyon yapariz Info methodunun ust tarafina
        public void Debug(object logMessage)
        {
            if (IsDebugEnabled)
            {
                _log.Debug(logMessage);
            }
        }
        public void Warn(object logMessage)
        {
            if (IsWarnEnabled)
            {
                _log.Warn(logMessage);
            }

        }
        public void Fatal(object logMessage)
        {
            if (IsFatalEnabled)
            {
                _log.Fatal(logMessage);
            }

        }
        public void Error(object logMessage)
        {
            if (IsErrorEnabled)
            {
                _log.Error(logMessage);
            }

        }


    }
}

//Bizim butun librariylerimiz webapi de referans edilir dolayisi ile sizin calisan projeniz
//ne ise aslinda proje odur,yani burda dikkat edelim direk log4net.config diyoruz yani
//oncesinde WebApi vs yazmadik cunku proje olarak biz WebAPI den calistirdigimiz icin proje odur
//Ondan dolayi biz boyle yazinca zaten direk WebAPI  de arayacaktir
//  xmlDocument.Load(inStream: File.OpenRead(path: "log4net.config"));
//Tabi burda biraz da log4Net in dokumantasyonu soz konusudur bunu bir kez yazariz ve birdaha
//yazmayiz


