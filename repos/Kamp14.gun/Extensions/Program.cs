using System;

namespace Extensions
{
    class Program
    {
        static void Main(string[] args)
        {
            string StringSayi = "25";
            int Sayi = StringSayi.IntCevir();//Biz bir string ifadeye yeni extensions lar ile
            //yeni bir method ekledikk ve artik StringSayi. dersek IntCevir in geldigini gorebiliriz
            //Ama bu sadece string sinifi icin gecerlidir
            Console.WriteLine(Sayi.GetType());
            Console.WriteLine("----------------------------------");
            string StringSayi2 = "25";
            int Sayi2 = StringSayi2.IntCevir(3);
            Console.WriteLine(Sayi2);
            Console.ReadLine();
        }
    }

  
    //Parametresiz Extension Eklemek 
    public static class ExtensionClass
    {
        //this bunun bir extension mehtodu oldugunu belirtir
        //sadece string ifadelerde gecerli oldugunu gosterir
        //Diyorsun ki burda herhangi bir string degere gelip . dersen IntCevir methodu da gelecektir
        //Ve sen burda IntCevir icine ne yazdi isen onu verecektir....
        public static int IntCevir(this string Deger)
        {
            return Int32.Parse(Deger);
        }
    }
    //Parametreli Extension Eklemek
    //Extension metodlara parametrede ekleyebilirsiniz.İlk örnek üzerinden gidelim.
    //    String bir ifadeyi int türüne dönüştürelim.Fakat dönüştürme aşamasında bizden 
    //    birde çarpım adeti için parametre değeri istesin.
    public static class ExtensionClass2
    {
        //this bu bir extension demek
        //string Deger ise bu extension hangi tip icin gecerlidir
        //int Sayi ise gecerli oldugu tipe verilen parametredir
        public static int IntCevir(this string Deger, int Sayi)
        {
            return Convert.ToInt32(Deger) * Sayi;
        }
    }
}
