using System;
using System.Collections.Generic;
using System.Text;

namespace OOP3
{
    //Interface leri artik service diye adlandiriyoruz buna alisalim
    interface ILoggerService
    {
        //Sadece imza, sablonu muzu yazariz, public yazilmaz defaultta zaten publictir o.
        //Sablonumuz loglama yapmaktir
        //Ornegin biz veritabanimiza loglama yapmak isteyelim.Bir tane DatabaseLoggerService class i olustururuz
        //Biz interface de bir sablon olustururuz, sadecde imzalari yazariz ve interfacimizi implement eden class lar bu sablonlari
        //kullanmak zorundadir
        void Log();
    }
}
