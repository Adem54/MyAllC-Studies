using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TernaryOperator
{
    class Program
    {
        static void Main(string[] args)
        {

            int sayi1 = 213;
            int sayi2 = 353;

            Console.WriteLine(tek_Mi_cift_Mi(sayi1));   
            

            //Duruma göre farklı değerleri mesaj değişkenine atayabilmek için if ile bir sürü kod yazmak yerine ternary ile tek satırda atabiliriz
            //Ternary şartı kendi kalıbında kolayca kontrol  edip tek satırda kodu döndürüyor
            //Ternary operatöründe geriye dönülecek değer aynı türde bir veri olmalıdır



            bool medeniHal = true;
            //Medeni halin durumunda göre biz mesaj değişkenine değer atayacağız
            string mesaj = medeniHal == true ? "Evlilere Kampanya.." : "Bekarlara Kampanya.....";
            //Satır bazlı şarta göre değişken atama işlemi ternary ile çok daha az maliyetle yapabiliriz
            Console.WriteLine(mesaj);

            //Ternary ile bir uygulama yapalım!
            //Kullanıcı tarafından girilen sayının aşağıdaki şartlara göre hesabı gerçekleştiren kodu ternary ile geliştirin

            //sayi 3 ten küçük se 5 ile çarp
            //sayi 3 ten büyük ve 9 dan küçükse 3 ile çarp
            //sayi 9 dan büyük eşitse ve 2 ye bölünürse 10 ile çarp
            //Sayi tek ise  sayi yi yazdır
            //Hiçbiri değilse sonuç -1 gelsin

            //Console.ReadLine() ile biz ekrandan değer döndürürüz ama bu default olarak stringdir bunu integer e
            //çevirmemiz gerekiyor işlem yapabilmek için

            int sayi = int.Parse(Console.ReadLine());//Kullanıcınn bir değer girmesini bekliyor yani değer girip entere basmayı bekliyor
            //int _sayi = int.Parse(sayi); böyle de tip dönüşümü yapabilirdik
            int result = sayi > 3 ? sayi * 5 :
                        (sayi > 3 && sayi < 9 ? sayi * 3 : 
                        (sayi>=9 && sayi%2==0?sayi*10:
                        (sayi%2==1?sayi:-1)));
                        
                        Console.WriteLine("Result: "+ result);//Burda int değerimizii stringe döndürüp de ekrana yazdırır

            Console.ReadLine();
           
        }

        //Ana Program class ında method yazarken orda çalışması için static yazmalıyz
        public static string tek_Mi_cift_Mi(int sayi)
        {
            //Ternary=>Şarta bağlı değer döndüren bir operatördür
            //Bir değişkene,methoda, propertye değer atarken bu değer şarta göre fark ediyorsa tek satırda bu şart
            //kontrolünü yaparak duruma göre değeri döndürmemizi sağlayan kalıpsal operatördür
            return sayi % 2 == 0 ? "Çift" : "Tek";
        }
    }
}
