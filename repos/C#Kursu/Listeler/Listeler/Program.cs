using System;
using System.Collections.Generic;

namespace Listeler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<string> sehirler = new List<string> { "Oslo", "Stavenger", "Skien" };
            sehirler.Add("Arendal");
            sehirler.Remove("Oslo");
            sehirler.BinarySearch("Stavenger");
            sehirler.Insert(2, "Trondheim");
            bool result=sehirler.Contains("Oslo");
            string sonuc=sehirler.Find(s => s.Length > 3);//Icinde predicate yaziyor predicate demek bir method var karsilastirma 
            //methodu ve o method bool donecek demektir...liste icinde donecek eleman sayisi 3 ten buyuk buldugu ilk elemmani 
            //getirecek...
            Console.WriteLine("Sonuc: "+ sonuc);
           
           
        }
    }
}
