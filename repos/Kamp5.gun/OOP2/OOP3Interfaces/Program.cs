using System;
using System.Collections.Generic;

namespace OOP3Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            //Interface ler newlenemez
           

           ICreditManager aracKredi1=new AracKredisi();
           ICreditManager ihtiyacKredi1 = new IhtiyacKredisi();
           ICreditManager konutKredisi1 = new KonutKredisi();
            EsnafKredisi esnafKredisi1 = new EsnafKredisi(); 

            //aracKredi1.Hesapla();
            //ihtiyacKredi1.Hesapla();
            //konutKredisi1.Hesapla();

            Console.WriteLine("---------------------------------");

            ILoggerService emailLoggerService = new EmailLoggerService();
            ILoggerService fileLoggerService = new FileLoggerService();
            ILoggerService databaseLoggerService = new DatabaseLoggerService();
            SmsLoggerService smsLoggerService = new SmsLoggerService();

            List<ILoggerService> loggerServices = new List<ILoggerService> {emailLoggerService,fileLoggerService , databaseLoggerService};

            List<ILoggerService> loggerServices2 = new List<ILoggerService> {smsLoggerService ,
                databaseLoggerService };

            List<ILoggerService> loggerServices3 = new List<ILoggerService> {smsLoggerService ,
                emailLoggerService };



            KrediBasvuru krediBasvuru1 = new KrediBasvuru();
            krediBasvuru1.KrediyeBasvur(aracKredi1, loggerServices2);
            krediBasvuru1.KrediyeBasvur(ihtiyacKredi1, loggerServices3);
            //krediBasvuru1.KrediyeBasvur(konutKredisi1,databaseLoggerService);

            krediBasvuru1.KrediyeBasvur(esnafKredisi1, loggerServices);

            Console.WriteLine("-----------------------------------------------");
            List<ICreditManager> creditManagers = new List<ICreditManager>()
            { aracKredi1, ihtiyacKredi1, konutKredisi1,esnafKredisi1 };

            krediBasvuru1.KrediBilgileriniGetir(creditManagers);
            Console.ReadLine();
        }
    }
}
