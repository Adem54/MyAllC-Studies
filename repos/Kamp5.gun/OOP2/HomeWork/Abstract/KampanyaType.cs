using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork.Abstract
{
    public abstract class KampanyaType
    {
        
        public void NoKampanya()
    {
        Console.WriteLine("Satilan urunde kampanya gecerli degildir");//Burasi herkeste ortak....
    }

        public abstract void KampanyaDescribe();//Burayi herkes kendi doldursun
    }
}
