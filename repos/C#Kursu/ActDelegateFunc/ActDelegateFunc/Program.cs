using System;
using System.Collections.Generic;
using System.Linq;

namespace ActDelegateFunc
{
    //Delegeler icin bu kaynak incelenebilir
    class Program
    {
        delegate void TestDelegate(string s);
        //Delegate-Temsilci
        //Delegate tanimlayalim
        //Hangi tipleri referans etmesini istiyorsak onlari sablonunda,ayni imza da bu delegeyi tanimlamiz gerekiyor
        //Yani tipi ayni tip ve parametre de ayni  mantikta parametresi olmalidir ve delegate ismi ile tanimlariz
        delegate double Dikdortgen(double a, double b);
        //Delegeler referans tipler old icin onlar uzerinden instance olusturabiliriz

        static void Main(string[] args)
        {
            //Delege den instance olustururken constructor kismina da hangi methodu referans etmsini istersek onu yazacagiz
            //Ama referans etmesini istediggimiz methodun sadece ismini yazariz parametrelerini degil
            //Biz o methodu cagirmiyoruz sadece ismini referans veriyoruz ondan dolayi ismini yazmamiz yeterlidir
            Dikdortgen test = new Dikdortgen(Cevre); 
            
            test(4, 6);//dedigimiz zaman Cevre methodunu cagirmis oluyoruz....
            Console.WriteLine(test(4, 6));

            test += Alan;//Buz delegelerimiz ile birden fazla methodu tutabilyoruz ve bu sekilde Alan methodunu da tutacak
            Console.WriteLine("Hello World!");
            Console.WriteLine(test(4, 6));//Burda tum metholdar calistiriliyor ama hepsi return dondugu icin burda da en
                                          //son tuttugu methodu donduruyor.Ama eger tum methodlardan donecek
            //degerleri gormek istersek o zaman once gidip mehtodlarin tipini double dan void e cekeriz sonra da 
            //tabi ki delegenin imzasi da methodlara uymalidir onun icin delegeyi de void yapariz...O zaman delegemiz kactane
            //methdo tutuyorsa hepsinin sonucunu bir ekranda gorebilriz...

            test -= Alan;//test delegesinden icindeki methodlardan Alan methodunu cikariyoruz bur da da 

            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine(test(4, 6));//Artik sadece Cevreyi referans ediyor burdas...

            //Delege tanimlamasini su sekilde de verebiliriz

            Dikdortgen test1 = Alan;//Alani referans aldi...
            test1 += Cevre;//Cevreyi de referans aldi burda artik....
            Console.WriteLine(test1(6,8));
            Console.WriteLine("/////////////////////////////////////////////////////7");
            //Boyle de cagirabiliriz....
            //Ozellikle null donme ihtimali olan mehtodlar cagiracaksak Invoke ile cagirmak mantikli olacaktir thernary ile cek
            //edebilecegimiz icin
           
            Console.WriteLine(test1.Invoke(12, 5));

            test1?.Invoke(2, 8);
            Console.WriteLine("*************************************************************");
            //Icerisinde method referansi tutan delegeleri de bir delege de toplayabiliyoruz
            Dikdortgen del = test1 + test;//test1 ve test2 delegelerini biz del delegesinde toparliyoruz...
            Console.WriteLine(del.Invoke(10,12));
            //Delegate tipleri methodlari daha iyi yonetmek icin kullaniliriz...
            static double Cevre(double sayi1, double sayi2)
            {
                return 2 * (sayi1 + sayi2);
            }

            static double Alan(double sayi1, double sayi2)
            {
                return sayi1 * sayi2;
            }


            Console.WriteLine("Anonim fonksiyonlar");
            Func<int,bool> myFunc = x => x == 5;//2.deger bool dur bu demektir ki ok isaretinden once olan x int olmalidir
            //=> ok isaretinden sonra olan donecek deger de bool olmalidir...
            bool result = myFunc(4);
            Console.WriteLine("result: "+ result);
            Func<int,int> myNumber = x => x + 5;
            int sonucNo=myNumber(10);
            Console.WriteLine(sonucNo);
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            int oddNumbers = numbers.Count(n => n % 2 == 1);
            //Yukarıda dikkat edileceği üzere giriş parametresinin tipi verilmemiştir, tip belirtmediğinde compiler
            //tipi kendisi çözümleyecektir yada direk(explicit) olarak parametrenin tipini tanımlayabiliriz.Yukarıdaki
            //lambda ifadesine baktığımızda 2 ye bölünebilen sayıları sayacaktır.


            // String argüman alan ve anonim olan metod tanımı.
            // Aşağıdaki satıra dikkat edildiğinde referans edilen herhangi bir metod yoktur. 
            // Metod varmış gibi kod yazılıp daha sonra bu metoda erişim sağlanmıştır.
            TestDelegate testDelB = delegate (string s) { Console.WriteLine(s); };
            testDelB("Merhaba bende anonim metodum.");
            
            //Burda da delegate ye direk isimsiz bir method u veriyoruz....
            TestDelegate myDel = n => {
                string s = n + " " + " Dünya";
                Console.WriteLine(s);
            };
           
            myDel("Merhaba");



            //C# – Func(Önceden Tanımlanmış Delege Türü)
            //Func<string, string, bool> Burda ilk 2 string degeri parametre degeri iken en sagdaki bool ise donus degeridir
            //

            Console.WriteLine("Func Onceden tanimlanmis delege turu");
       


            Func<int, int> Toplam = ToplamMetodu;
            Console.Write(Toplam(5));
            Console.Read();
          
            
            static int ToplamMetodu(int sayi)
            {
                int Toplam = 0;
                for (int i = 0; i <= sayi; i++)
                {
                    Toplam += i;
                }
                return Toplam;
            }

            Func<int, int> Toplam1 = sayi =>
            {
                int ToplamDeger = 0;
                for (int i = 0; i <= sayi; i++)
                {
                    ToplamDeger += i;
                }
                return ToplamDeger;
            };

            Console.Write(Toplam1(5));


            int Deger = Convert.ToInt32(Console.ReadLine());
            Func<bool> SinyalVarmi = () =>
            {
                if (Deger == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            };

            Console.Write(SinyalVarmi());


            Console.WriteLine("-------------------------------------");

            List<int> Sayilar = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            List<int> GelenSayilar = Sayilar.Where(sayi => sayi == 1).ToList();
            foreach (var item in GelenSayilar)
            {
                Console.Write(item);
            }


            Console.WriteLine("****************************");

            List<int> BenimSayilar = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            List<int> BenimGelenSayilar = Sayilar.Where(SayilariGetir).ToList();
            foreach (var item in BenimGelenSayilar)
            {
                Console.Write(item);
            }

           
        }

        static bool SayilariGetir(int Sayi)//parametre int donus ddeegeri bool o yuzden yukariya uyuyor
        {
            return Sayi == 2;
        }

        
        public void X() => Console.WriteLine("Merhaba ben x methoduyum");
      
        

    }
    }
   

//Biz delegeler sayesinde birden fazla methodu ayni anda bir delege mizde tutaabiliriz.. ve onlari ayni anda calismasini 
//saglayabiliriz...Sonradan aymi sablonda bir method ekleyebiliyoruz ve ayni sekilde icindeki methodlardan istedikelrimizi de
//cikarabiliyoruz....
//Delegate bir fonksiyon pointer idir.Fonksiyon tutucu gibi ya da bir fonksiyona isaret gosterir,
//fonksiyon icinde fonksiyon kullanmak gibi
//Func,Action,Predicate in icerisinde delegate vardir
//Bircok fonksiyonu ayni anda tek bir seferde cagirmamizi saglar
//Delegeler methodlarla ayni sekilde tanimlaniyorlar
//Bir yada daha fazla methodu hafizasinda saklayan methodlardir delegeler.....

//Func-Lambda Expression-Anonim Fonksiyonlar bir delegedir...Ama sonunda bir deger dondurmk zorundadir..

//Neden delegate kullanmalıyız?

//Eğer delegeleri ilk defa öğreniyorsanız, basitçe bir metod çağırmak varken neden delegeler ile uğraşayım bana ne gibi faydaları var diyebilirsiniz.

//Buna yanıt olarak yazdığımız component’lerde belirli metodların belirli durumlarda ne zaman çağıracağını bilmememizdendir.

//Önemli bir nokta ise delegeler.NET component’lerinin yazmış olduğunuz kodları çağırmasını sağlar, .Net component’leri metod signature (dönüş tipi ve aldığı argümanlar) dışında yazdığınız kod ile ilgili bişey bilmezler.

//Örneğin .Net Framework component’lerinden biri olan Timer component’i çalışmak için yazmış olduğunuz koda ihtiyaç duyar. 
//    Çünkü Timer component’inin hangi metodu çağıracağını bilmesi imkansızdır, bu invoke edilecek delege tipine register
//    olan metod ve signature’u ile belirlenmiş olur. Sonrasında Timer component’i çalıştırıldığında delegesinin instance’ına
//    register olan signature’una uygun olan metodunuzu çalıştırmış(invoke) olur.

//Yine bu aşamada Timer componenti sizin yazdığınız metod ile ilgili bir şey bilmemektedir.

//Timer component’inin tüm bildigi delegedir. Delege metodunuzla ilgili detayları (dönüş tipi ve argümanları) bilmekte
//    ve delegeye register olan metodları çalıştırmaktadır(invoke).

//Sonuç itibarı ile Timer component’i yazmış olduğunuz metod ile ilgili birşey bilmemesine rağmen metodunuzu çalıştırmış oldu.

//Bahsetttiğimiz Timer componenti örneği gibi yazdığımız kod içerisinde belirli bir noktada hangi metodun çağırılmasını 
//    istiyorsak delege kullanabiliriz. Belirdeğimiz bu noktada direk olarak metod çağrımı yapmak yerine delege instance’ı 
//    nı çalıştırarak (invoke) bu delege instance’ına register olmuş hangi metodlar varsa onları çalıştırabiliriz. Böylece 
//    kodumuzun içerisine direk olarak metod yazmak yerine başka bir yerdeki uyumlu metodları kullanma esnekliği sağlar.

//Bu anlattıklarımıza ek olarak .Net içerisinde bize hazır olarak sunulan delegelerde bulunmaktadır ;

//Predicate delegesi System.Predicate. Bu delege object tipinde tek argüman almakta ve boolean tipinde değer döndürmektedir.

//Predicate delegesini bir örnek üzerinde kullanalım:

//static void Main()
//{
//    int[] primes = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 21 };
//    int[] smallPrimes = Array.FindAll(primes, IsSingleDigit);   // { 2, 3, 5, 7 }
//}

//static bool IsSingleDigit(int value)
//{
//    return 0 <= value & amp; &amp; value <= 9;
//}
//Func delegesi Func. Bu delegede maximum generic 16 argüman almakta ve generic bir değer geri döndürmektedir.

//Func<> generic delegesini bir örnek üzerinde kullanalım:

//Func<int, int, double> divide = (x, y) => (double)x / (double)y;
//Console.WriteLine(divide(2, 3));
//Yukarıdaki delege tanımına baktığımızda iki tane integer tipinde argüman alıp double tipinde bölme sonucunu 
//    geri döndürdüğünü gözlemleyebiliriz. Func<> kullanımında son argüman her zaman dönüş tipini belirmektedir. 
//    Action<> ile Func<> arasındaki tek fark ise Action<> delegesinin dönüş tipi tipinin olmamasıdır.

//Action delegesi Action. Bu delegede maximum generic 16 argüman almakta ve herhangi bir dönüş değeri bulunmamaktadır.

//Action<double> write=(aDouble)=>Console.WriteLine(aDouble);
//write(divide(2, 3));
//BU KAYNAK OKUNMALI
//http://www.kazimcesur.com/delegates-anonymous-methods-lambda-expressions-delegeler-anonimisimsiz-metodlar-lambda-ifadeleri/