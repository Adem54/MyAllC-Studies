using System;
using System.Collections.Generic;

namespace DictionaryGenericClassIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> Ogrenci = new Dictionary<int, string>();
            Ogrenci.Add(134, "Tolga Demirer");
            Ogrenci.Add(158, "Ümit Özkan");
            Ogrenci.Add(115, "Kadir Aydemir");
            Ogrenci.Add(174, "Cemal Çiftçi");

            //Dictionary generic class i ile olusturulan Ogrenci nesnesinde biz Ogrenci[key] yaparsak o key a karsilik yazdigimiz
            //value yu aliriz

            Console.WriteLine("Ogrenci[key]: "+ Ogrenci[158]);
            Console.WriteLine("Ogrenci[key]: "+Ogrenci[115]);

            //Ogrenciyi foreach ile donderirsek eger ve sonrasinda donen her degere item.key dersek keyi, item.value dersek de 
            //value ye ulasiriz ama asil vurucu nokta Ogrenci[key] o keye karsilik gelen Value yi bize veriyor
            foreach (var item in Ogrenci)
            {
                Console.WriteLine("itemValue= " +item.Value +"   ItemKey= "+item.Key);
            }
            Console.WriteLine("--------------------------------");
            Console.Write("Öğrenci No Giriniz:");
            int No = int.Parse(Console.ReadLine());

            try
            {
                Console.WriteLine(Ogrenci[No]);//Bize bu key in hangi value ye karsi geldigini verir.
            }
            catch
            {
                Console.WriteLine("Öğrenci Bulunamadı.");
            }

            Console.ReadLine();
        }
    }
}
