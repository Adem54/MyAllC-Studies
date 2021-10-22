using System;
using System.Collections.Generic;
using System.Text;

namespace OOP3Interfaces
{
    class KrediBasvuru //Bu class birbirinin alternatifi olan bircok class turunde bulunan bir operasyonun sonucunu
        //bir basvuru isleminde gormek icin yapariz....

    {
        public void KrediyeBasvur(ICreditManager customerManager, List<ILoggerService> loggerServices)
        {
            customerManager.Hesapla();

            foreach (var loggerService in loggerServices)
            {
                loggerService.Log();
            }
        }

        //Burda bir musterinin sartlari birden fazla krediye uyuyorsa ayni anda birden fazla kredi bilgilerini getirmemiz 
        //gerekebilir dolayisi ile biz parametreye interface i List olarak gondermemliyiz
        public void KrediBilgileriniGetir(List<ICreditManager> creditManagers)
        {
            foreach (var crediManager in creditManagers)
            {
                crediManager.KredilerileriYazdir();
            }
        }
    }
}
