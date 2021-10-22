using MusteriYonetimSistUygulamasi.Abstract;
using MusteriYonetimSistUygulamasi.Concret;
using System;

namespace MusteriYonetimSistUygulamasi
{
    class Program
    {
        static void Main(string[] args)
        {
            //BURDA GORDUGUMUZ GIBI BIZ NEROCUSTMANAGR DAN SAVE METHDUNA ERISEBILDIK.....
            //NeroCustomerManager neroCustomerManager = new NeroCustomerManager();
            //neroCustomerManager.Save();

            Customer customer = new Customer() {DateOfBirth=new DateTime(1985,1,6),FirstName="Engin",LastName="Demirog",
                NatioanalityId= "28861499108" };
            //BASECUSTOMERMANAGER ABSTRACT CLASS OLD ICIN NEW LENEMEZ.......
            BaseCustomerManager customerManager = new StarbucksCustomerManager();
            customerManager.Save(customer);


            Console.ReadLine();
        }
    }
}
//SOMUT SINIFLAR CIPLAK KALMAMALI....
//Somut siniflar eger ciplak kalirsa ilerde nesnellik zafiyeti yasariz onun icin somut siniflar ciplak kalmamali
//Mutlaka somut siniflar ya interface i implemente etmeli ya da bir classi inherit etmeli ya da bir abstract class i
//implemente etmelidr ciplak kalmamalidir


//SENARYO
//Biz bir yazilim gelistirme firmasiyiz ve kahve dukkanlari icin musteri yonetimi yapan bir sistem yazmak istiyoruz
//Sisteme musterilerin kaydedilmesini saglayan ve devamindaki islemleri yapan bir sistem
//Musteri Yonetim Sistemi yazmak isiyoruz
//Starbacks ve Nero firmasi icin calisiyoruz
//Iki firmada musterilerini veritabanina kaydetmek istiyor
//Starbucks musterileri kaydederken mutlaka mernis dogrulamasi istiyor.Nero musterileri kaydederken boyle birsey istemmiyor
//Mernis temel ad soyad ve tc si girilen bir kisnin dogru kisi olup olmadigini kontrol eden bir servistir.
//Starbucks musteriler icin her kahve aliminda yildiz kazandirmak istiyor

