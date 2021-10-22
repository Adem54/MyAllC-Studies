using BankaKrediUygulamasi.Business;
using BankaKrediUygulamasi.Credits.Abstract;
using BankaKrediUygulamasi.Credits.Concrete;
using BankaKrediUygulamasi.Logs.Abstract;
using BankaKrediUygulamasi.Logs.Concrete;
using System;
using System.Collections.Generic;

namespace BankaKrediUygulamasi
{
    class Program
    {
        static void Main(string[] args)
        {
            ILoggerService fileLogger = new FileLogger();
            ILoggerService databaseLogger = new DatabaseLogger();
            ICrediService mortgageCredit = new MortgageCredit();
            ICrediService vehicleCredit = new VehicleCredit();
            ApplyManager applyManager = new ApplyManager();

            applyManager.ApplyForCredit(vehicleCredit, fileLogger);
            applyManager.KrediOnBilgilendirme(new List<ICrediService>() {vehicleCredit,mortgageCredit });

            //Konut kredisi hesapla ve database e logla simdide
            Console.WriteLine("Konut kredisi hesapla ve database e logla simdide");
            applyManager.ApplyForCredit(mortgageCredit, databaseLogger);
        }
    }
}



//BankaKredi Uygulamasi
//Burda biz bir bankada kredi musterilere Kredi hesaplama, ve hesaplanaan krediyi loglama islemi yapan
//Ve ayrica da bir musteriye birden fazla kredi bilgisini sunabilme...ozeilliklerini barindiran
//programi yaziniz....