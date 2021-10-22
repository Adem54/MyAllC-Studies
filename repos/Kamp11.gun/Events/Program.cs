using System;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            //Simdi olusturdugumuz eventi Console da kullanalim
            Product harddisk = new Product(50);
            harddisk.ProductName = "Hard Disk";

            Product gsm = new Product(50);
            gsm.ProductName = "GSM";
            //Bir evente kaydolma islemi veya abone olma islemi
            gsm.StockControlEvent += Gsm_StockControlEvent;

            for (int i = 0; i < 10; i++)
            {
                harddisk.Sell(10);
                gsm.Sell(10);
                Console.ReadLine();
            }


            Console.ReadLine();
        }

        //Gsm icin stockconstrol eventi olusturyoruz.Bunu biz mesela 2 tane urunumuz var hangisinde olusturmak istersek
        //daha dogrusu daha once olusturdugumuz bir eventi o product nesnesinden urettigmiz gsm adli instance de bu eventa
        //abone olsun istersek eger o zaman instanceyi atadigimiz gsm adli degiskene gsm.StockControl+= deyip 2kez ust uste
        //tab a basarsak o zaman gsm icin stockcontrol eventi otomatik olusacaktir
        private static void Gsm_StockControlEvent()
        {
            Console.WriteLine("Gsm about to finish!!!");//urun sayisi 15 in altina dusunce bu mesaji veriyor
            //Biz 15 in altina dustugunde kontrolunu direk Stock propertysi icinde yaptik
        }
    }

    public delegate void StockControl();//Bir stockcontrol turunde delege olusturuyoruz ve eventi de 
    //bu turde tanimliyoruz ve icinde calismasini istedigimiz class a geliriz ve public event in delege turunu
    //yazariz daha sonra ise event adini yazariz ve sonuna event eklemeliyiz
    public class Product
    {//Bir parametre gondermek istiyorum ve bu parametre vasitasi ile satis yapacak degerleri kontrol
     //etmek adina bir deger girecegim normalde o degeri veritabanindan cekeriz ama burda property vasitasi
     //ile almaya calisiriz Stok sayisini constructor vasitasi ile alalim
        int _stock;
        public Product(int stock)
        {
            _stock = stock;
        }
        //Stock propertyimize deger olarak atyacagiz disardan gelen stock degerini
        public event StockControl StockControlEvent;
        public string ProductName { get; set; }
        
        //Biz bir eventten strock propertisinde yararlanmak istersek o zaman property nin
        //get ve set inden yararlaniriz
        public int Stock
        {
            get { return _stock; }
            set { _stock = value;
                if (value<=15 && StockControlEvent!=null)
                {//bu propertynin bu evente abone olup olmadigini icinde degerden anlariz
                    //icinde deger varsa abone olmustur yoksa abone olmamistir
                    //StockControlEvent!=null=>abone olmussa demek o zaman eventi tetiklememiz gerekkiyor
                    StockControlEvent();

                }


            }
        }


        public void Sell(int amount)
        {
            Stock -= amount;//amount cok tane satildi ise o miktari verecek bize
            Console.WriteLine("{1}Stock amount :{0} ", Stock, ProductName);
        }
    }
}
//Eventler bir delegedir delegelerin kullanimi ile eventlerde faydalaniyoruz
//Magazada urunlerimiz var mesela bir tane akilli telefon ve harici disk satiyoruz
//Harici diskler onemini yitirdi insanlar cloud kullaniyorlar ve bizde elimizdeki harici diskleri bitirmek 
//istiyoruz ama telefon icin ise surekli elimizde bulundurmak istiyoruz ve surekli elimizde var olmasini
//istiyoruz
//Bir urunun elimizden cikarmak istersek diger bir urunu elimizde tutmak istiyoruz ki yok demeyelim yani
//surekli siparis verip surekli satmak istiyoruz
//Telefonun bittigini anlamk icin bu yazilimlara ihtiyaci var isletmecinin iste telefon bitmeye yakim bir
//kural koyuyorsunuz magazada elimde 20 telfon kaldiginda bana haber ver beni uyar deki telefona 20 tane kaldi
//Uygulamada bir hareket oldugunda yapmak istedigini bir islem varsa bunu event ile yapiyorsunuz
//Bunun disinda ama ayni eventi harici disk icin istemiyoruz bir urun nesnesi icin urun turune gore
//bir event e abone olursaniz o sizin icin calisir ama diger bir urunu harici diski de abone etmezse o urun
//icin calismaz
//Programcilar bunu yapmak icin if ile cok ugrasiyor mesela bugun icin bunu telefon icin yaptin yarin
//bunu gelip mause icinde yapmak isteddin ona da yaz ayni ifi boyle surekli if yaz bu dogru degil
//Eventleri tam olarak bu amac icin kullaniriz

//Mesela biz bir ekrana buton koyduk ve butona event eklemedik. Butonun click eventi, mausun
//uzerine gelince eventi veya mausa cift tiklama eventi biz o eventlere kaydolursak geliyor
//Eventlere kayit olma islemi de += ile olmaktadir zaten bunlari formlarda da bu sekilde oldugnu gorebiliriz
