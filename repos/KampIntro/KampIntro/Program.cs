using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            //Typa Safety
            //C# programlama da metinsel ifadeler çift tırnak la yazılır tek tırnakla değil, tek tırnak ve çift tırnak C# da farklıdır
            string katetgoriEtiketi = "Kategori Etiketi";
            byte a1 = 12;
            sbyte a2= -12;
            short sayi1 = 123;
            int sayi2 = 121222;
            long sayi3 = 353535353535;

            //Object eBütün veri tiplerinin türediği temel sınıftır. object olarak tanımladığımız bir değişkene
            //herşeyi atayabiliriz.Örneğin: sayısal ifadeler, string ifadeleri, sınıf gb.
            Object value = "Kemal";
            value = 244;
            value = 23.5;
            //Kullanımı Object türü gibidir.  var anahtar kelimesiyle değişken tanımlaması yapabiliriz.
            //Var anahtar kelimesinde değişken türü derleme aşamasında değişkene atanan değerin türünden belirlenir.
            //Örneğin var number = 5; şeklinde bir tanımlama yaptığımızda number değişkeni derleme aşamasında
            //int değeri olarak belirlenmiştir.
            var number = 5;
            bool sistemeGirisYapma = true;//Login girişleri vs orda kayıt ol yazınca anlıyoruz ki sisteme giriş yapılmamış ve 
            //Çok önemli!!!!! Gerçek hayatta sistemeGirisYapılıp yapılmadığının true mu false mu olduğu bir veri kaynağından gelir
            //yani eğer bir web uygulaması ise o zaman localstorage veya cashe bakar, bir mobil uygulama ise bellekte o değere
            //bakar veya bambaşka birşey ise bile bir veri kaynağından gelecektir 
            //Yani aslında bu gelen true veya false bir veri kaynağından fonksiyon olarak gelecektir

//            sistemeGirisYapma = false;

            if (sistemeGirisYapma)
            {
                Console.WriteLine("Sisteme giriş yapılmış");
            }
            else
            {
                Console.WriteLine("Sisteme giriş yapılmamış");
            }

            double dolarDun = 7.4;
            double dolarBugun = 7.6;

            if (dolarBugun>dolarDun)
            {
                Console.WriteLine("Dolar Yükselişte");
            }
            else if (dolarBugun<dolarDun)
            {
                Console.WriteLine("Dolar Düşüşte");
            }
            else
            {
                Console.WriteLine("Dolar da değişme ollmamış");
            }

            Console.ReadLine();
        }
    }
}
//Console da biz kod yazarız ilk önce çünkü verileri görmek istediimiz için