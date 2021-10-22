using System;

namespace TryCatchHataYakalama
{
    class Program
    {
        static void Main(string[] args)
        {
            //Hata Cesitleri
            //Calisma zamaninda alinan hataya dair bizlere bilgi veren-tasiyan parametrelerdir

            //Ozellikle yaptigimiz uygulamalarda kullanicidan girilmesi gerken veri farkli tip de girilmesi veya bos girilmesi durumunda
            //nasil bir hata yonetimi yapacagiz bunlari ayarlamak icin kullandigimiz yontem try-catch dir

            Console.WriteLine("Bir sayi giriniz? ");
            
            //Biz hata vermesini bekledigmiz kodlarin, yani hatanin olusma durumu olan kodlari try bloguna yazariz, hata gerceklesir
            //ise eger calismasini istedigmiz  kodlari da catch bloguna yazariz........
            //Biz hata yonetimini neden kullaniriz bizim  kontrolumuz disinda olasi problemlere karsi programimizi korumak
            //Programimizi olabilecek problemlere karsi patlatmadan hata mesajlari ile vs yonetebilmek
            //Kullanicidan gelebilecek veya baska sebeplerden gelebilecek yazdigimiz programin akisinda sorunlar cikabilecek 
            //durumlari hesab edip ona gore try-catch bloklari ile hatalari yonetmek
            try
            {
                int girilenSayi = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Bravo sayi girdiniz!");
            }
            catch (Exception)
            {

                Console.WriteLine("Malesef sayi disinda bir veri girdiniz!");
            }
            //Try catch  in daha da detayli ogrenirsek hatalari filtrelendirme ve buyuk hatalari kaybetme olaylarina bakacagiz

            Console.ReadLine();

        }
    }
}
