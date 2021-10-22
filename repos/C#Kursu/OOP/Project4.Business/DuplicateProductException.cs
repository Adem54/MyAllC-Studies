using System;
using System.Collections.Generic;
using System.Text;

namespace Project4.Business
{
    //Ayni isimde iki urun olmaz hatasi
    //Kendi olusturdugum DuplicateProductException a Exception sinifini inherit ettigimiz anda ne yapmis oluyoruz
    //yani Exception i kendi sinifimiza da base olarak verdigimiz anda ne yapmmis olduk kendi Exception sinifimizii 
    //olusturmus olduk burda....

    //Simdi gidelim...ProductManager daki Add islemimmizde hata olarak kendi olusturdugmuz direk 
    //hedefe yonelik hata yakalayan class imizi kullaniriz..
    public class DuplicateProductException : Exception
    {
        public DuplicateProductException(string message):base(message)
            //base class in yani Exception in da constroctor ini calistir...diyoruz burda...
            //Parametre olarak ona ben ne verirsem onu gonder diyoruz.....Biz boyle dedigimizde arka planda
            //Exception in message properties i constructor uzerinden set olmus oluyor aslidna
            //Yani Exception deki Message de sadece getter olark yazilmis yani set edilmesin de sasdece constructor 
            //girilebilsin dye....
            //Kendimiz bir kez daha yazmak yerine base imiz olan Exception constructo ina biz hangi mesaji yazarsak
            //onu oraya gonder orda benim mesajimi kullan diyoruz..Bu cok harika birsey....
        {
           
        }

        //Message bize nerden geldi.bize Exception Base class inda virtual olarak bulunuyor
     
    }
}
