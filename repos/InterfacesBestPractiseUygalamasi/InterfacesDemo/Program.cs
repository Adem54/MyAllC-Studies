using System;

namespace InterfacesBestPractiseUygalamasi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Bir şirket hayal ediyoruz orda çalışanlar,yöneticiler ve robotlar olduğunu varsayalım.
            //Şimdi önce interface leri tasarlarken bu 3 çalışan tipinin ortaknoktası nedir hepside bir worker yani
            //çalışandır yani hepsinde de kullanacağımız özellikleri altına toplayacağımız bir interface oluşturacağız

            IWork[] workers = new IWork[3]//3 elemanlı dizi çünkü work operasyonunu biz 3 tane class ta tanımladık yani worker interface i 3 class ta da implement edildi(inheritance)
            {
                new Worker(),
                new Manager(),
                new Robot(),
            };//Bir dizi oluşturuyoruz ve içerisine tüm class larımızı atıyoruz ve sonra da bu array imizi döndürerek her 3 class ta da ortak olan bir
              //operasyonu sıra ile çalıştırabiliyoruz
            foreach (var worker in workers)
            {
                worker.Work();
            }
            //Eat işlemine izin verelim

            IEat[] Eats = new IEat[2]
            {
                new Manager(),
                new Worker()
            };

            foreach (var eat in Eats)
            {
                eat.Eat();
            }
        }
    }

    // INTERFACE LERİN DOĞRU PLANLANMASI
    interface IWork
    {
        //Interface lere imzamızı bırakıyorduk unutmayalım implement etmeden yani için i doldurmadan
        //Biz 3 tip çalışan grubunun hepsinde yapacağımız operasyonları içini doldurmadan yazarız, imzamızı atarız
        //Peki biz örneğin çalışan gruplarımızda farklı farklı özellikler olurda , biz mesela eat ve getSalary robot
        //classında olmasın sadece worker ve managers larda olmasını istersk o zaman da bir interface içerisine
        //3 farklı operasyon yazmak yerine biz o operasyon adları ile interfaceler oluşturup bir class a birden fazla interface vererek hangi class hanggi interface lere ihtiyacı varsa onu verebiliriz
        void Work();
       
    
    }   //
    interface IEat
    {
        void Eat();
        
    }

    interface IGetSalary
    {
        void GetSalary();
    }
    class Manager : IWork, IEat, IGetSalary
    {
        public void Eat()
        {
           // throw new NotImplementedException();
        }

        public void GetSalary()
        {
            //throw new NotImplementedException();
        }

        public void Work()
        {
          //  throw new NotImplementedException();
        }
    }

    class Worker : IWork,IEat,IGetSalary
    {
        public void Eat()
        {
            //throw new NotImplementedException();
        }

        public void GetSalary()
        {
            //throw new NotImplementedException();
        }

        public void Work()
        {
            //throw new NotImplementedException();
        }
    }

    class Robot : IWork
    {
        public void Work()
        {
            //throw new NotImplementedException();
        }
    }
}
