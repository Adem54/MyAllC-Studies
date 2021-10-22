//using Entities.Concrete;
using Business.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Workaround
{
    class Program
    {
        //kodlarımızı main methodunun içerisinde çalıştırırrız
        static void Main(string[] args)
        {
            //Variables();
            //tc no yu string de tutabiliriz cunku kendisi sayidir ama tc ile matematiksel islem yapmiyoruz
            // Elimizde bircok farkli veri turu var biz bu kadar veriyi surdurulebilir bir sekilde yonetmek icin mantiksal
            // Verileri mantiksal gruplara alip bir objenin veya nesnenin yani class in icine atip sonra
            // ordaki elemanlarimizi mesela atiyorum class ismimiz Person ise ondan  bir person adinnda
            // nesne uretir ve artik elemanlarimizi daha dogrusu ozellik diyoruz bunlara ozelliklerimizi
            // person.ad,person.soyad seklinde cagirabilirir 
            // gruplara ayiririz bunlara da nesne(obje) denir nesne yonelimli programlama denmesinin sebebi budur


            //bool uygulamalarimizii dallandirmak icin kullaniriz ozellikle log in yaptiysa veya yapmadiysa diye de
            //kullaniriz
            Citizen citizen = new Citizen();//Class tan bir instance oluşturuyoruz yani bir nesne yani bir obje oluşturyoruz

            // Console.WriteLine(citizen.name);
            //Bu sekilde class in icersindeki ozelliklere erisebiliriz iste class larla heryerde
            // ayri ayri degisken tanimlaamak yerine ortak degiskenleri biryerde
            // tanimlayip onlari public olarak tanimlayip heryerde kullanabiliriz
            Console.ReadLine();
            SelamVer("Ahmet");
            SelamVer("Mehmet");
            SelamVer();
            Topla(3,5);
            Topla();

            //Diziler-Array
            //Biz birden fazla string elemanımız var ve onu daha kolay yönetmek istersek o zaman string dizi oluştururuz
            string[] students = new string[3];//4 elemanlı bir string dizi değişkeni üretmiş olduk ve
                                              //artık 4 tane stringimi bu değişken içinde tutabilirim
            //bu yontemlede string referans tipli dizimizin icerisine eleman ekliyoruz
            students[0] = "Kerem";
            students[1] = "Marek";
            students[2] = "Bjørn";
            students = new string[4];//Yukarda da students değişken isimde 3 elemanlı bir string dizisi oluşturup
                                    //3 eleman ekledikten sonra tekrar aynı students değişken ismi ile 4 elemanlı
                                     //bir dizi daha oluşturuyoruz ve hemen ardından da bu diziye bir eleman daha
                                     //ekliyoruz şimdi ne olacak hemen inceleyelim
           // REFERANS TİPLERİ İYİ ANLAMAK BİR YAZILIMCIYI AYIRT EDECEK OLAN ÖZELLİKLERDENDİR.......

           //Her yeni dizi oluştuğunda bellekte yeni bir adres te tutulacaktır dolayısı ile de değişken artık yeni
           //bir dizi yi yani farklı adreste 4 elamanlı boş bir diziyi tutacaktır ondan dolayı ilk oluşturdğumuz
           //dizinin değişken ismi de yeni oluşturdğumuz dizi de old için 3 elemanlı olarak oluştrduğumuz ilk
           //dizi boşta kalacaktır 
           //Değişken isimleri ve değerleri Stack kısmında referans tipler den olan diziler gibi elemanlar
           //ise Heap denilen kısımda tutulur ve Heap kısmı referans kısmıdır ve orada tutulan herşeyin kendine özel bir 
           //adresi vardır. Biz aynı değişken ismi ile tekrarden 4 elemanlı bir dizi oluşturunca bir önce
           //oluşturduğumuz 3 elemanlı dizi stack kısında isimiz ve başıboş kalıyor ve bunlar belli zaman
           //sonra garbage collect tarafından silincektir
           //
           //

            students[3] = "Ivar";

            //for döngüsü ile dizimizin içerisindeki elemanlarımız yazdırabiliriz
            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine(students[i]);
            }
            //Aynı işlemleri defalarca yapmak zorunda kaldığımız durumlarda
            //o elemanları dizi içerisine yazıp o diziyi döngü ile döndürmeye çalışırız
            //Diziye Yeni eleman ekleme
            //String dizi oluşturmanın 2 farklı yöntemi 
            string[] cities1 = new string[3];
            cities1[0] = "Bursa";
            cities1[1] = "Izmir";
            cities1[2] = "Adana";
            string[] cities2 = new [] { "Ankara", "Istanbul", "Kayseri" };

            cities2 = cities1;//cities2 değişkenine cities1 dizisinin değerini atıyor diye düşünmeyelim burdan şunu anlayalım
            //cities2 dizisinin referansı cities1 dizisinin adresini tutmaya başlıyor yani onun referansını alıyor.
            //Artık cities2 de cities1 dizisinin adresini tutuyor ve cities2 nin ilk önce tuttğu dizi boşa çıkmış oluyor
            //cities2 değişkeni cities1 in adresini tutmaya başlıyor ve cities 1 dizisinde ki her
                              //türlü değişilik artık cities2 değişşkeninede yansımış oluyor
            cities1[0] = "Kocaeli";

            Console.WriteLine(cities2[0]);
            //foreach döngüsü ile biz dizi formatındaki yapıları döneriz
            //Doğrudan dizi içindeki elemanları sıra ile getirir
            foreach (string city in cities1)
            {
                Console.WriteLine("Cities1i foreach döngüsü ile göster");
                Console.WriteLine(city);
            }

            //Generic Collection- Diziler yerine kullanılan listeler
            //Dizilere göre daha efektif kullanılabiliyor 

            List<string> NewCities = new List<string> { "Ankara1", "İstanbul1", "Adana1" };
            NewCities.Add("Izmir1");

            foreach (string city in NewCities)
            {
                Console.WriteLine(city);
            }

            Person person4 = new Person();
            person4.FirstName = "Serdar";

            PttManager pttManager = new PttManager(new PersonManager()); //Bu satırda alttaki satırda kullanılabilirdi
            //PttManager pttManager = new PttManager(new ForeignerManager());
            pttManager.GiveMask(person4); //Burda pttManager dan bir anda eczaneye döndü bunların olmaması için Business altında bir tane daha abstrackt klasörü altında interface class oluştururuz

            //int,double,float,bool tipleri değer tipleridir ve doğrudan değerler baz alınır
            //Değer tiplerde bir değişkene başka bir değikenin değerini atadıktan sonra o değişken sadece diğer
            //değişkenin değerini alır ve ondan sonra değerini aldığı değişkende olacak değişikliklerle ilgilenmez
            int number1 = 24;
            int number2 = 32;
            number2 = number1;
            number1 = 45;
            Console.WriteLine(number2);


            Person person1 = new Person();//Bir class ile yeni bir nesne oluşturmuş olduk ya da bir class ile yeni
                                          //bir obje oluşturmuş olduk ve o objenin propertiesleri belli biz bu propertieslere değer atayabiliriz
            person1.FirstName = "Mehmet";

            Person person3 = new Person { FirstName = "Kemal" };//Bu şekilde de bir class tan obje veya nesne oluşturup nesnenin propertisine veri atayabiliriz
            Person person2 = new Person();
            person2.FirstName = "Engin";
        }

        //string ler çalışma şekli itibari ile değer tipidir ama arka tarafta bir referans tiptir çünkü string
        //tipler charArraydir yani her harfinn elemandan olştuğu bir dizidir
        //static le baslatmak zorundayiz methodu cunku main class i icerisinde kullanacagiz
        //void ise herhangi birsey dondurmeyecek sadece isi yapacak demektir
        //Void methodlar sadece is yapar ve herhangi bir bilgi donmez
        //Git kaydet, guncelle,sil gibi islem yapar sadece
        static void SelamVer(string name= "#noname")//C# da method olustururken parametre veritipi ile beraber verilir
                                                    //ayrica da default olarak da bir veri verebiliri "noname" seklinde
            //Burda SelamVer adinda bir method olusturuyoruz olustururken static ile baslariz
                              //cunku main static bir yapiya sahip ver bu class i biz mainde kullanacagiz
        {                        
            Console.WriteLine("Merhaba: "+ name);

        }

     
        //Sonuc donduren yani ihtiyacimmiz olan bir hesaplama sonucunu donduren methodlar da bu sekildderi
       //Return method veya fonksiyonlari isimlendirilirken de veri tipi yazilarak isimlendirilir ve biz return donus tipini isminden anlariz
        static int Topla(int sayi1=10, int sayi2=15)//parametrelere default degerlerde verebiliriz
            //sayi1 ve sayi2 defaultu verip methodu kullanırken 1 tane parametre verirsek onu sayi1 için kullanır(sıra ile)
            //sayi1 e default vermeyip sayi2 ye default vermek mümkündür ama tam tersi mümkün değildir yani sayi1 e verip sayi2 ye vermezsek bu doğru olmaz
        {
            int result = sayi1 + sayi2;
            //Bir degisken tanimlandigi blok ta gecerlidir bunu unutma
            //{ } iki suslu parantez icinde kalan kisma blok deriz 
            Console.WriteLine("Toplam: " + result.ToString());//sayi ile teksti birlikte yazarken sayiyi tekste ceviririz
            return result;
        }

        private static void Variables()
        {
            Console.WriteLine("Hello World!");
            string mesaj = "Selam";
            Console.WriteLine(mesaj);
            Console.WriteLine(mesaj);
            Console.WriteLine(mesaj);
            Console.WriteLine(mesaj);
            Console.WriteLine(mesaj);
            double tutar = 1000000.4;
            Console.WriteLine(tutar);
            // Kendimizi yenilememiz gerekiyor programlamada bu onemli
            int sayi = 100;
            bool girisYapmisMi = true;

            string adi = "Mehmet";
            string soyad = "Demirog";
            int dYili = 1982;
            long tcno = 12345678912;

            //Person person = new Person();//Biz Person class ini baska biryerden buraya aktarip kullaniyoruz ama onun icin herseyden once biz o Person class ini olustururken
                                         //public olarak olusturursask baska sayfalarda da kullanabiliriz, biz person in uzerine gelip saga tiklayinca ad deyip import islemini using entity.concreate i en basa otomatik ekleyerek import islemi gerceklesmis olur
        }
    }
    //Class lar, property ler ve methodlar Pascal case yontemi ile yazilmalidir yani basharfleri buyuk olmalidir
    public class Citizen
    {
        //Değişkenlerimiz normal şartlar altında sadecde kendi class ı içerisinde kullanılabilir ama biz bunları heryerde kullanılması için yani
        //global yapmak için değişkenlerin başına public koyarız ki dışardan da erişilebilir yapmak için
        // public string name="Adem";
        // public string lastname = "Erbas";
        // public int bornYear = 1988;
        // public long idNo = 12345678901;
        //Biz degiskenlerle degil class in kendisi ile ugrasacagiz, class odakli calisarak daha az kod daha cok mantik ve surdurulebilirlik
        //Biz Name,Lastname, BornYear ve Tcno da degisiklik yapmak istedigimiz zaman kolayca yapabilelim diye get ve set ile property olarak tutariz
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int BornYear { get; set; }
        public long TcNo { get; set; }

    }
}
