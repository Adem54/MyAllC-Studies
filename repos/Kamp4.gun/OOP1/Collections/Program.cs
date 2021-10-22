using System;
using System.Collections.Generic;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            //CTRL-K-CTRL-C ile sectigimiz tum tekstleri yorum satiri yapabilirz
            //Yorum satiri yapilan satirlari geri almak icin satirlar sectikten sonra CTRL-K-CTRL-U
            ////ARRAYS-NEDEN ARRAYLAR ISIMIZI GORMUYOR-NEDEN ARRAY YERINE COLLECTIONS LAR KULLANIRIZ
            ////Biz array lari istedigimiz gibi genisletemiyoruz ayrica da referns tiplerinden dolayi yeni bir dizi olusturdugumuz
            ////da da yeni bir adres olusturdugu icin heap memory de ondan dolayi eski dizi elemanlari oraya aktarilmamis oluyor
            ////dizi eleman sayimizi arttirmak icin names=new string[5] hareketini yaptgimiz zaman bir once name dizisinde var olan
            ////elemanlari kaybediyoruz referans tip old icin ancak dizi de elimizde olanla calismak zorunda kaliyoruz
            ////Yani ozetle biz 4 elemanli olusturdugumz bir diziyi 4 elemani da muhafaza ederek ekstra 5. eleman ekleeyemiyoruz
            ////Ya 5 elemanli yeni bir dizi olusturuyoruz onda da eski elemnlarii kaybediyoruz referans tip old icin
            ////Biz yeni bir dizi olusturunca yeni bir adres tutuyyor
            //string[] names = new string[] { "Ahmet", "Mehmet", "Kemal", "Mustafa" };
            ////Gercek hayatta bu dizi elemanlari veri kaynagindan gelir ve sonra yeni datalar gelecek biz onlari o
            ////diziye eklemek zorundayiz.Dizilerin kullanimindaki bu sinirlamalardan dolayi biz dizilerle calisamiyoruz
            ////Gercek hayatta C# ve java  da arraylar cok fazla kullanillmaz onun yerine collections lar kullanilir
            //Console.WriteLine(names[0]);
            //Console.WriteLine(names[1]);
            //Console.WriteLine(names[2]);
            //Console.WriteLine(names[3]);

            ////Dizilerde bu sekilde eleman ekleyemiyoruz ve istedigimiz gibi dizileri genisletemiyoruz
            ////     names[4] = "Kazim";
            ////   Console.WriteLine(names[4]);

            ////names degiskenini zaten daha onceden string array olarak tanimladik ondan dolayi dogrudan baska bir array atamasi yapabiliriz
            //names = new string[5];

            //names[4] = "Talip";
            //Console.WriteLine(names[4]);
            //Console.WriteLine($"names dizinin 0.elemani: {names[0]}");//bos gelecektir
            //                                                          //Cunku biz names array degiskenine yeniden new leyip yeni bir adres atadik ve o adresin icindeki dizide de
            //                                                          //sadece 4.elemana deger gonderdik dolayisi ile onun disindaki index teki elemanlari gormek istersek bos gelecektir

            ////COLLECTIONS
            ////Bazi siniflar otomatik gelir kendisi C# da console , int gibi ama bazilari ise import etmemiz gerekir List gibi
            ////Ama biz List yazinca zaten ampul gelir uyari ampulu orda using System.Collections.Generic; tikarsak en yukari 
            ////bu class i sistemimize dahil edecektir ve artik List lerle calisabiliriz
            ///Biz list ile dizi olusturdugumuz zaman Add ile eski verileri kaybetmeden yenii bir eleman ekleyebiliyoruz
            /// Listelerin bir cok isimizi kolaylastiran methodu vardir.Bu methodlari ogrenmeye calisalim
            /// List eler bir class tir zaten yazinca class lar gibi yesil renkli oluyor
            /// Listeleri bir string le tanimlarken <> icerisine yazacagimiz veri turunu kucuktur ve buyuktur isaretinin 
            /// icerisine koyariz bu yapiya biz generic yapi diyoruz

            List<string> cities = new List<string>();
            cities.Add("Oslo");
            cities.Add("Skien");
            cities.Add("Porsgrunn");
            cities.Add("Kristiansent");
            cities.Add("Stavenger");
            foreach (var city in cities)
            {
                Console.WriteLine(city);
            }

            List<int> numbers = new List<int>() { 12, 21, 6, 56, 37 };
            numbers.Add(85);

            for (int i = 0; i < numbers.Count; i++)
            {
                int number = numbers[i];
                Console.WriteLine(number);
            }

            Console.WriteLine("-------------------------------------------");

            if (cities.Contains("Oslo"))
            {
                Console.WriteLine("Oslo bu sehirler arasindsa bulunmaktadir");
            }
          //  cities.Clear();

            Console.WriteLine(cities.Count);

            List<string> isimler = new List<string>();
            isimler.Add("Adem");
            isimler.Add("Zeynep");

            foreach (var isim in isimler)
            {
                Console.WriteLine(isim);
            }
            Console.WriteLine("//////////////////////////////////////////7");
            cities.AddRange(isimler);

            foreach (var item in cities)
            {
                Console.WriteLine(item);
            }

            cities.Insert(0, "Ulsteinvik");
            Console.WriteLine(cities[0]);
            Console.WriteLine("*******************************************************");
            cities.Remove("Adem");
            cities.RemoveAt(0);
            cities.InsertRange(0,new List<string> { "Tromsø", "Sandvik" });
            cities.Sort();
            foreach (var item in cities)
            {
                Console.WriteLine(item);
            }

            int index=cities.IndexOf("Zeynep");
            Console.WriteLine(index);
            Console.ReadLine();
        }
    }
}
