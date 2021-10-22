using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassIntro
{
    class Program
    {
        static void Main(string[] args)
        {

            string myKurs = "C# kursu";
            int age = 34;
            //Class da bir veri tipidir string, int gibi ve Class tipinde bir değişken tanımlarken
            //o class ın ismi yazılır önce daha sonra da new ile tekrar o class ismi yazılır yani buna instance
            //oluşturma diyoruz veya obje,nesne oluşturma
            Kurs kurs1 = new Kurs();//kurses objesini oluşturmuş olduk
            kurs1.KursAdi = "Java Kursu";
            kurs1.Egitmen = "Engin Demiroğ";
            kurs1.IzlenmeOrani = 35.6;
            //Aslında kurs1 değişkeni üzerinden biz 3 tane ayrı özelliği yönetiyorum yani 1 değişkenle
            //birçok farklı tip özelliği yönetebiliyoruz

            //Aslında bizim yazdığımız instanceler ve onların üzerinden atadığmız değerler mesela kurs1
            //instancesi ve onun özelliklerine atadığımız değerlere paket olarak da değişken gibi düşünebiliiriz

            Kurs kurs2 = new Kurs();
            kurs2.KursAdi = "C#";
            kurs2.Egitmen = "Murat Yayla";
            kurs2.IzlenmeOrani = 56.5;

            Kurs kurs3 = new Kurs();
            kurs3.KursAdi = "React Kursu";
            kurs3.Egitmen = "Sadık Turan";
            kurs3.IzlenmeOrani = 67.6;

            //Örnek yeni bir kurs ekleyelim ve doğrudan sisteme dahil edelim
            //Bir objeye eleman ekleme de bu şekilde de olur yukarda yaptıklarımızın yanı sıra
            Kurs kurs4 = new Kurs() {KursAdi="Angular Kursu", Egitmen= "Necati Kaya", IzlenmeOrani=78.7 };


            //Bu kurs Class ından oluşturduğmuz kurs1,kurs2,kurs3,kurs4 verileri gerçekte bir veri kaynağından gelecek

            //Biz bu kurs nesnelerini barındıran bir Kurs array tanımlamamız gerekiyor ki bu nesnelerimizi
            //array a atalım ve listeleyebilelim yani Kurs array diyoruz çünkü Kurs bir veri tipidir, string gibi ,
            //integer gibi aynen biz nasıl ki int,string array tanımlıyorsak bur da da tipimiz Class olduğu için
            //class array tanımlıyoruz ki objelerimizi listeleyip o objenin özelliklerini de isteğimiz gibi kullanabilelim


            //Peki biz class üzerinden oluşturduğumuz 3 ayrı kurs bilgilerini nasıl array a atıp da
            //listelyeceğiz ona baklım şimdide!!!!!

         //İçinde kurs nesnesini barındıran bir array tipi belirlemiş oluyoruz aslında
         //KURS ARRAY I OLUŞTURMA-OLUŞTURDUĞUMUZ CLASS TIPIMIZI TUTAN ARRAY OLUŞTURMA!!!!!!!!!!!!!!!
            Kurs[] kurslar = new Kurs[] {kurs1,kurs2,kurs3,kurs4 } ;

            //Ne yapıyoruz instance leri listeliyoruz ki her döngü de biz o instancalere ait özellikleri
            //yazdırabiliriz biz Kurs classımızdan bir Kurs arrayi oluşturmuş olduk ve o array içerisinde obje,
            //instance veya nesnelerimizi döndereiyoruz ve o nesneler üzerinden de rahatlıkla her döngüde özelliklere ulaşıyoruz

            foreach (var kurs in kurslar)
            {
                Console.WriteLine(kurs.KursAdi + kurs.Egitmen + kurs.IzlenmeOrani);
            }
            //Biraz daha ilerleyince gerçek projelerde biz foreach ile web yani html kodunu döndereceğiz ekran da görebilmek için
            //Burda şuna dikkat edelim şu an bu şekilde class yaparak biz ne yapmış olduk sürdürülebilir bir kod yazmış olduk yani
            //örneğin biz yeni kurs açmak istersek ne yaparız elimizdeki Kurs class ımızdan bir tane daha instance oluştururuz foreach
            //ile otomatik dönüyor zaten Kurs class arrayi onun için sadece bizim yeni bir kurs instance si eklemem yeterli olacaktır
            //onu otomatiktmen sisteme dahil edecektir yani ben 1 kere tek merkezden böyle bir şey yapıyorum ve bu şekilde sisteme
            //dahil oluyor hiçbiryeri bozmadan, ayrıca eğer yeni özellikler eklemek istersek de ekleyebiliriz diğer kodlar aynen
            //devam edecek şekilde ve hiç bir yeri bozmadan
            //Yani gidip de bir daha html yazmaya uğraşmayız html foreach arasında dönecek şekilde bir kere ayarlarız sonradan
            //ekleyeceğimz kısımlar doğrudan sisteme dahil olurlar

            //BURDA DA STRING ARRAY TUTUYORUZ VE ICERISINE ELEMAN EKLIYORUZ
            string[] dersler = new string[] { "Matematik", "Fizik", "Kimya", "Biyoloji" };

            
         
            foreach (var ders in dersler)
            {
                Console.WriteLine(ders);
            }

            string[] students = { "Kristian", "Eino", "Barbara", "Linn" };

            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
           //BURDA DA INT ARRAY TUTUYORUZ VE ICERISINE ELEMAN EKLIYORUZ
            int[] notlar = new int[3];
            notlar[0] = 78;
            notlar[1] = 67;
            notlar[2] = 56;

            for (int i = 0; i < notlar.Length; i++)
            {
                Console.WriteLine(notlar[i]);
            }

            Console.ReadLine();


        }
    }
    //Biz class oluştururken aslında yeni bir tip tanımlıyoruz peki bu tip neye göre tanımlanıyor tamamen ihtiyaca
    //göre tanımlanıyor. Mesela kurslar tek tek listeleniyor ve neler görüyoruz biz kursun resmini, kursu veren ismi,
    //kursun izlenme oranı vs gibi temel verilerin hepsini bir yerde tutacak bir tip olutşruyoruz yani tutup da mesela
    //ayrı ayrı string, int lar ile ayrı ayrı verileri yazmak gibi düşün yada o verilerin hepsini
    //ortak bir çatıda toplayabildğiniz düşün ve o topladığın ile de yeni bir tip oluşturdğunu düşün
    //İşte temel verileri tuttuğumuz class larda property class ları deniyor
    //Gerçek hayatta listelenen ürünller, mesela e-ticaret sitesindeki ürünler de bir class tır. Biz kurslar derken
    //kurslarda hangi özellikler olacaksa belli edilir ve bir class oluşturduktan sonra ne kadar kursumuz olacaksa ,
    //örneğin Kurs adi, kurs eğitmeni, kursizlenme orani,kursimajı vs ayrıca bizim birde görmedğmiz arka plan da tutulması
    //gereken verileri var onları kullanıcılar göremiyor ve hassas veriler olabilir onlarda tutuluyor class das dolayısı
    //ile bir sürü veriyi tutmamız gerektiğini düşünürsek bunları tabi ki de tek tek string vs tanımlayarak yapılacak
    //değil tabi ki
    //doğrudan o class üzernden çok hızlı birşekilde ürünleri listeleriz
    //Sonradan eklenen ürünler de çok kolay birşekilde sisteme adapte olabilirler
    class Kurs
    {
        public string KursAdi { get; set; }
        public string Egitmen { get; set; }
        public double IzlenmeOrani { get; set; }
    }


}
