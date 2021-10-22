using System;

namespace Constructor4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Result result1 = new Result(true, "Veri basari ile eklendi!");//Bu bir versiyondur

            Console.WriteLine(result1.Success);
            Console.WriteLine(result1.Message);
            //Burda her iki veriyi de alabiliyoruz hem mesaj hem sonuc dondurmek istersek

            //Ama sadece Success dondermek istersek
            Result result2 = new Result(false);
            Console.WriteLine(result2.Success);

            //Bizim burda amacimiz costructor lar uzerinde class in farkli versiyonlarda newlemekti
            //Bizim kullanciya veya yazilimciya alternatifler sunmak ve onu yaparken de kendimizi
            //tekrar etmemektir




            Console.ReadLine();
        }
    }

   public class Result
    {//Sonucunda hem mesaj hem de basari sonucunu donderir 
     //Biz Success=success; her iki constructor da da yazarak kendimizi tekrar etmemek icin
     //bool ve string tipinde 2 paramtreli constructor a :this(success) yazarak 2 parametreli construc
     //tor imiz calisinca parametresi success olan tek parametreli constructor imizda calissin diyoruz!!
     //Ve bu yontemle Success=success; i 2 kez yazmaktan ve kendimizi tekrar etmekten kurtularak
     //SOLID-DON'T REPEAT YOUR SELF KURALINA UYUYORUZ!!!
        public Result(bool success,string message):this(success)
        {
            Message = message;
            //Success = success; don't repeat your self
        }

        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get;}
        public string Message { get; }
    }


  
}
