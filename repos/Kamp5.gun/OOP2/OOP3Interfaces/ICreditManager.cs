using System;
using System.Collections.Generic;
using System.Text;

namespace OOP3Interfaces
{
    //Interface leri genellikle biz operasyonlarda kullaniriz ve ayrica ayni method u bir cok alternatifin class in 
    //kullanacagi durumlarda ozelliklede ayni method ismini tum class larin kullanacagi ama o method isminin detaylarinda
    //kendi kurallarinin oldugu durumlar yani method isimleri ayni ama icerikleri farkli olacak sekilde
    interface ICreditManager
    {
        //Sadece imzalar blunmak zorundadir.Interface i implement edecek olan class larda bulunmasi zorunlu olan imajlardir
        void Hesapla();

        void KredilerileriYazdir();
    }
}
