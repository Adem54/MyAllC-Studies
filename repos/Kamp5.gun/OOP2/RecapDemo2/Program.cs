using System;

namespace RecapDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
           

            CustomerManager customerManager = new CustomerManager();
         
            //Database de loglamayi yaptirmak istiyorsak
            customerManager.Logger = new DatabaseLogger();
            customerManager.Add();
            //File ile loglama yapmak istersek
            //customerManager.Logger = new FileLogger();
            //customerManager.Add();
            //Sms ile loglamayi sonradan talepe gore ekledigmizi dusunelim
            customerManager.Logger = new SmsLogger();
            customerManager.Add();


            Console.ReadLine();
        }
    }
    //Amacimiz su ben bir musteriyi ekledigim zaman, yani benim kullanicilarimdan biri, bunu hangi kullanici, hangi datayi
    //ne zaman logladi diye loglama yapmak istiyorum.Loglamayi biz bu amacla kullaniriz
    //Loglama-Bir kullanici Add methodunu cagirdigi zaman deriz ki su isimli kullanici su methodu su parametrelerle
    //calistirdi.
   class  CustomerManager
    {//
        public ILogger Logger { get; set; }//Bir tane Logger adinda ILogger tipinde bir ozellik yazdik
       
        public void Add()
        {
            //YANLIS KULLANIM CUNKU SADECE DATABASE ILE ISLEM YAPABILIYORUZ
            //DatabaseLogger logger = new DatabaseLogger();
            //logger.Log();
            //-----------------------------------
            Logger.Log();//yukarda olusturdugumuz property ile interface icindeki imzayi cagirdik
            Console.WriteLine("Customer Added!");
        }
    }

    //CUSTOMERMANAGER DA INTERFACE PROPERTSI OLUSTURUP ISLEMLERINI ONUN USTUNDEN GOTURME.......................................
    //BU KULLANIMI ILK DEFA GORDUM BIZ CUSTOMERMANAGER DA BIR INTERFACE TIPINDE PROP OLLUSTURDUK VE SONRA METHODUN
    //ICERISINDE O PROPERTY ADI ILE INTERFACE ICINDEKI IMZA YI CAGIRABILDIK VE BIZ NORMAL PROGRAM.CS MIZDE CUSTOMERMANAGER
    //DAN BIR INSTANCE OLSTURDUKTAN SONRA CUSTOMER MANAGER ICINDE INTERFACE ILE OLUSTURDUGUMUZ OZELLIGE BIZ HANGI LOGGER IN
    //CALISMASINI ISTERSEK ONU NEW LYEREK O NEWLEDIGIMIZ DE OLUSAN INSTANCEYI YANI REFERANSINI, CUSTOMER MANAGER I INSTANCE
    //SINI OLUSTURUP ATADIGIMIZ DEGISKENLE ONUN ICERISINDE OLUSTURDUGUMUZ INTERFACE PRPERTYSINI CAGIRIRIZ VE ONA HANGI 
    //LOGLAMA YAPILMASINI ISTIYORSAK O LOGLAMAYI NEWLEYIP O PROPERTYE ATAMIZ OLURUZ VE SON OLARAK CUSTOMERMANAGER
    //ADD METHODUNU CALISTIRIRIZ
    //BURDA EN ONEMLI SEY INTERFACE PROPERTY SININ HANGI CLASS ILE CALISMAK ISTERSEK ONA SET EDILMESI ONUN REFERANSINI 
    //TUTMASIDIR
    //



    class DatabaseLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to Database");
        }
    }

    class FileLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to File");
        }
    }

    //Ornegin sonradan Sms ile de loglamak istersek SmsLogger adinda bir class ekleyelim

    class SmsLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to SMS"); ;
        }
    }
    interface ILogger
    {
        void Log();
    }

}


//Eger ki bir class i bu sekilde ciplak gorurseniz yani herhangi bir interface veya base i yani inheritance si yoksa 
//ona cok dikkat etmeliyiz...Cunku biz interface i olmayan ya da inheritance si olmayan bir class i ancak new leyip de 
//kullanabilirsin.Bir class in ciplak durmasi tehlikeli bir olay bu tarz durumlarda sunu dusunmelisin bunlarin bir base
//class i olmali yani bir class in mutlaka bir base i olmali... Ayrica tutupda tekbasina ciplak olan class i gidip de baska
//bir classi n icinde o hali ile new leyip kullanmak cok acemice bir sey olur cunku bizden degisiklik talebi  gelirse herseyi 
//bastan dusunmek gerekecek.Biz sadece o anin problemlerini cozup gelecekte gelebilecek degisikllik taleplerini gozardi 
//edemeyiz..................................
//Diyelim ki bir musteri database baska bir musteri metin dosyasinda istiyor ornegin. Yani birbirinin alternatifi durumlar
//var o zaman ne yapiyoruz hemen bir tane interface olustururuz ve icerisine tasarim desenlerimizi yani imzalarimizi yazariz
//Bu imzalar bu interface i implement edecek olan class lard olmasi zorunlu olan method isimleridir

//NEDEN INTERFACE KULLANDIK BURDA???
//Burda interface sectik cunku database,sms ve file sistemlerinin hepsinde de Log adinda bir method ve ama mehtodlarin icleri
//farkli oldgundan dolayi yani kullanan herkesin farkli bir kod yazdigi icin, 
//Normalde biz bu olayi property injection deniyor bu olaya normalde property injection ile degilde constructor ile 
//yapacagiz.......
//NORMALDE CONSTRUCTOR ILE YAPILACAK ASLINDA...................
//NEDEN VIRTUAL METHODS KULLANABILIRDIK?
//Ama eger ki bizim icerdeki methodlar in implementasyonu yani ici  2 sinde ayni diger 1 inde farkli olsa idi o zaman biz
//virtual methods lari tercih ederdik-virtual
//NEDEN ABSTRACT CLASS KULLANABILIRDIK?
//Bir tane operasyonu herkes degistirecek ama 1 tane operasyon ayni o zaman ben onu absract classes yapardim