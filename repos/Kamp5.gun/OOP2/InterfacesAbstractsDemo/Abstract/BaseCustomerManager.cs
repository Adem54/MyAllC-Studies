using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriYonetimSistUygulamasi.Abstract
{
    public abstract class BaseCustomerManager : ICustomerService
    {
        public virtual void Save(Customer customer)
        {
            Console.WriteLine("Saved to db!"+ customer.FirstName);
        }
    }
}
//Burda hem Starbacks in hem de Nero nun veritabaninda yapacaklasi islemler tamamen ayni yani kodlar da ayni 
//Dolayisi ile biz o operasyonu bir abstract classs icinde yazip bu class i hem Starbacks hem de Nero implement edecekler


//NEDEN SAVE METHODUNU VIRTUAL YAPIYORUZ BURDA????????
//MERNIS DOGRULAMAYI NASIL PLANLARIZ...
//Starbacks bizden mernis dogrulamasi istiyor veritabanina kaydetmeden once ama Nero istemiyor evet burda farkli bir
//durumla karsi karsiyayiz yani biz Save islemine hem Nero hem de Starbacks da yapiyoruz ama Starbacks Nero dan farkli
//olarak bir mernis dogrulamasi istiyor bizden o zaman mernis dogrulama islemini yapabilmek icin ne kullanabiliriz...
//Burda interface kullanamayiz cunku interface icindeki imzalari onu implement eden tum classlar kullanmak zorundadir
//Abstract class da kullanamayiz abstrac da yazarsak Nero problemi ortaya cikacak
//Bu isi cozebilmek icin biz BaseCustomerManager daki Save methodumuza(bu method BaseCustomerClass i ICustomerService inter
//face inin implement ettigi icin ordan gelen bir method) virtual yaparsak eger o zaman biz artik BaseCustomerManager 
//abstrackt class ini implement eden class lar eger isterlerse bu methodu override edebilirler yani ezebilirler.Yani
//bu methodun icini kendi istedikleri gibi doldurabilirler...