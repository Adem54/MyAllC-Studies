using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces3
{
    class CustomerManager
    {
        //Burada parametreye biz interfacei vererek bizim bu class in bu operasyonunu bu interface i implemente eden tum
        //class lar icin kullanilabilir hale geliyor ve biz bu operasyonun parametresine ister SqlServerDal istersek de 
        //OracleServerDal dan olusturulan instanceler verebiliyoruz ve ihtiyacimiza gore bir veritabani ile calisma firsati
        //ni yakalamis oluyoruz ayrica, daha sonradan yeni bir veritabani ile calismak durumunda olursak mevcut kodlarimiza
        //hic dokunmadan onu da sistemimize dahil etme firsatinida yakalamis oluyoruz ki bu bize cok sey kazandiriyor
        //Bu bize yazilimda devamlilik ve surdurulebilirligi kazandiriyor
        public void Add(ICustomerDal customerDal)
        {
            customerDal.Add();
            customerDal.Delete();
            customerDal.Update();
        }
    }
}


//Biz interface sayesinde bagimliliklarimizdan kurtuluyoruz yani biz ornegin veritabaninlarinda hangisinde istersek
//onda yazdirmak icin bir operasyon daha yazariz CustomerManager ve orada hangi veritabanindan istersek o veritabaninda
//eklemek istiyoruz....Yani eger interface olmasa idi biz veritabanlarindan birini kullanmak zorunda kalacak ve ona bagimli
//olacaktik ama interface sayesinde biz bagimliliklarimizdan kurtulmus oluyoruz.....