using System;
using System.Collections.Generic;
using System.Linq;

namespace Classes2
{
    class Program
    {
        static void Main(string[] args)
        {
         
            ProductManager productManager = new ProductManager();
            Product product = new Product { ProductName = "Kalem", UnitPrice = 100, UnitsInStock = 23 };
            productManager.Add(product);
            Matematik matematik = new Matematik();
            int sonuc=matematik.Topla(4, 5);//Donen degeri return sayesinde aktaririz
            //Parametrelere default olarak veri atayarak da kullanabiliriz...
            int sonuc2 = matematik.Topla(8);

            int sonuc3 = matematik.Topla();
            Console.WriteLine($"   {sonuc} {sonuc2} {sonuc3} ");

            //Parametredeki degerlerin yerini degistirerek de verebiliriz
            int sonuc4 = matematik.Topla(sayi2: 6, sayi1: 14);
            Console.WriteLine("sonuc4= "+ sonuc4);

            int sonuc5 = matematik.Topla(7);
            Console.WriteLine("sonuc5="+ sonuc5);
            int sonuc6 = matematik.Topla(new List<int> { 4, 5, 8, 9 });
            Console.WriteLine("sonuc6= "+ sonuc6);
            //Params ile parametreye yazdiktan sonra artik bu sekilde kullanabiliriz..
            int sonuc7 = matematik.ToplaParams(2,4,5,6,7,7);
            int sonuc8 = matematik.ToplaParams(new int[] { 3, 6, 7, 8, 9 });
        }
    }

    public class Matematik
    {// public int Topla(int sayi1, int sayi2) burasinin adi sablondur veya imzadir...
        public int Topla(int sayi1=2, int sayi2=12)
        {
            return sayi1 + sayi2;
        }

        //methodu overloading ediyoruz burda da--
      
        public int Topla(int sayi1)
        {
            return sayi1 + 2;
        }

       public int Topla(int sayi1, int sayi2,int sayi3)
        {
            return sayi1 + sayi2 + sayi3;
        }

        public int ToplaParams(params int[] sayilar)
        {
            
            //Linq ile gelen Sum Aggregation fonksiyonlari
            return sayilar.Sum();
        }


        public int Topla( List<int> sayilar)
        {
            int toplam=0;
            foreach (var sayi in sayilar)
            {
                toplam += sayi;
            }
            return toplam;
        }
        //Methodun yaptigi islemi bir degiskene aktarip ordan da istedigim yerlerde bu sonucu kullanabilmem icin 
        //return ile bunu dondurmem gerekiyor...
    }
}
//Iste gercek hayatta da biz olusturdugumuz class lari bir kez cagiririz ve kullandigimiz 100 yer bile olsa
//o 1 kere new leme ile heryerde kullanabiliriz....
//C# da ayni dosyada birden fazla class yazabilirz ama bu java da gecerli degildir...