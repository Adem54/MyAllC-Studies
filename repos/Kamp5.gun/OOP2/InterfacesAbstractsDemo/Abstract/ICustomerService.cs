using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriYonetimSistUygulamasi.Abstract
{
    //Bu interface ise method tutan class larin implemente ettigi interface olacak
   public interface ICustomerService
    {//Musteriler veritabanina kaydedilecegi icin bir tane Save methodu olmali
        void Save(Customer customer);
    }
}

//Interface ler abstract oldugu icin onu abstract klasorunde tutariz
//Save operasyonu her iki musteri de istemisti bu tarz durumlarda her iki musteri de bizden ayni operasyonu istemis
//O zaman bu tarz durumlarda soyutlama yapmaliyiz yani interface kullanmaliyiz
//Daha sonra gelecek olan baska bir sirke ti de projemize ekleyince de onu da rahatca sistemimize entegre
//Interface i impmente eden tum class lar onun operasyonlarini kullanmak zorundadir