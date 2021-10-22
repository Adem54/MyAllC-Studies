using System;
using System.Collections.Generic;

namespace OOP3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Asagida yapilan tum islemleri subedeki gorevlilerin ekranda secebildigi krediler ollarak dusunelim!!!!!
            //Acilir kutuda musteriye soruyor neye basvurmak istiyorsun o da ihtiyac kredisi ise orayi acip onlari getiriyor musteriye

            //GORULDUGU UZEREE INTERFACE LER ONU IMPLEMENT EDEN CLASS LARIN REFERANSINI, ADRESINI TUTABILIYORLAR
            //YANI INTERFACE LERDEN OLUSTURDUGUMUZ BIR DEGISKENE ONU IMPLEMENT EDEN TUM CLASS LARIN REFERANSINI TUTTURABILIYORUZ
            //O CLASS LARDAN OLUSTURDUGUMUZ INSTANCELERI VEYA NESNELERI INTERFACE DEGISKENINE ATANABILIYOR YANI INTERFACE ONLARIN 
            //OLUSTURDUGU REFERANS ADRESINI TUTABILIYOR

            ConsumerCreditManager consumerCreditManager = new ConsumerCreditManager();
            consumerCreditManager.Calculate();
            ICrediManager consumerCreditManager2 = new ConsumerCreditManager();
            consumerCreditManager2.CrediContracted();

            MortgageCreditManager mortgageCreditManager = new MortgageCreditManager();
            mortgageCreditManager.Calculate();
            ICrediManager mortgageCreditManager2 = new MortgageCreditManager();
            mortgageCreditManager2.CrediContracted();


            VehicleCreditManager vehicleCreditManager = new VehicleCreditManager();
            vehicleCreditManager.Calculate();
            ICrediManager vehicleCreditManager2 = new VehicleCreditManager();
            vehicleCreditManager2.CrediContracted();

            Console.WriteLine("/////////////////////////////////////////////////////////////////////////////////");

            //INTERFACE I 2.PARAMETRE OLARAK VERDIK VE ASAGIDA DA 2.PARAMETRE OLARAK HANGI LOGLAMA TURUNU ISTERSEK ONU VERDIK!!!!
            //Yine biz interface de referanslarini tutabildigimiz icin artik biz ApplyManager class imzin ApplyForCretid methodunda
            //parametreye ikinci parametre olarak istedigimiz loglama turunu verebiliyoruz
            ILoggerService databaseLoggerService = new DatabaseLoggerService();
            ILoggerService fileLoggerService = new FileLoggerService();
            //BU YAZILIMDA SURDURULEBILIRLIGI SAGLAR.... BIZ BU SAYEDE DAHA SONRADAN GELEBILECEK YENI DEGISIKLIK TALEPLERINE 
            //KARSILIK VEREBILIRIZ.....
            //YAZILIMLAR YASAYAN BIR ORGANIZMADIR DEGISMEK ZORUNDADIR..... DEGISECEKTIR... BIZ SISTEMIMIZI KURARKEN BUNLARII GOZE
            //ALMALIYIZ YENI BIRSEY EKLEME, HERHANGI BIRSEY CIKARMA BUNLARA HER DAIM HAZIR OLABILMEK ICIN SISTEMIMIZI BASTAN ONA GORE
            //KURMALIYIZ KI SONRADAN GELEN DEGISIKLIK TALEPLERDE YENI EKLEYECEGIMIZ KODLARIMIZI MEVCUT KODLARA HIC DOKUNMADAN
            //SISTEMIMIZE ADAPTE EDELIM...

            //BURAYA DIKKAT SISTEMIMIZE YENI BIR ELEMAN EKLIYORUZ MESELA....
            //ORNEGIN SISTEMIIMIZE BIR ESNAF KREDISI EKLEYELIM VE BIR DE SMSLOGLAMA EKLEYELIM....SONRADAN VE MEVCUT SISTEMIMIZE
            //HIC DOKUNMADAN(SOLID IN "O" SU OPEN CLOSE PRINSIBLE) BUNLARI EKLEYIP SISTEMIMIZE ENTEGRE EDELIM.....

            ICrediManager shopkeeperCreditManager = new ShopkeeperCreditManager();
            ILoggerService smsLoggerService = new SmsLoggerService();

            ///////////////////////////////////////////////////////////////////////////////////////////////////
            ///ISTE BURASI OLAYIN KOPTUGU NOKTA.... BURAYI IYI ANLAMAK COOOOK ONEMLI!!!!
            //ApplyManager class ini olustururken
            //ICreditManager vermemizi istiyor parametreye
            //ICrediManager interface dir new lenemez!!!!!
            //Ama ICrediManager in referanslarin i tutabildigi onu implement eden class lari verebiliriz parametre olarak olay bu kadar!
            ApplyManager applyManager1 = new ApplyManager();
            applyManager1.ApplyForCredit(vehicleCreditManager,fileLoggerService);
            applyManager1.ApplyForCredit(new MortgageCreditManager(),databaseLoggerService);
            applyManager1.ApplyForCredit(new ConsumerCreditManager(), new FileLoggerService());
            //Sonradan ekledigimiz bir degisiklik sisteme kolayca adapte oldu mevcut sisteme hic dokunmadan
            Console.WriteLine("-----------------------------------------------------------------------------");

            Console.WriteLine("Sonradan ekledigimiz bir degisiklik sisteme kolayca adapte oldu mevcut sisteme hic dokunmadan");
            applyManager1.ApplyForCredit(shopkeeperCreditManager, smsLoggerService);

            //////////////////////////////////////////////////////////////////////////////////////////////////////7
            ///
            Console.WriteLine("........................................................................................................");
            //Burda banka memurunun 3 tane kredi cesidini birden sectigni varsayalim ve o kredi turlerinin instancelerini gonderelim
            //3 tane farkli kredi turumuzu ayni anda hesaplattirdik bu sekilde......
            List<ICrediManager> credits = new List<ICrediManager>() {consumerCreditManager,mortgageCreditManager,vehicleCreditManager };
            
            applyManager1.KrediOnBilgilendirmesi(credits);


            Console.ReadLine();
        }
    }
}
