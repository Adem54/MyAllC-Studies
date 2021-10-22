using HomeWork.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork.Concrete
{///BURDA KAMPANYA TURLERINDEN OPERASYON CLASS I OLUSTURULMAZ...KAMPANYA TURLERI SABIT VERILERDIR BIZ ONLARI BIR CLASSS ICINDE PROPERTY OLARAK 
    //KAMMPANYANIN HANGI BILGILERI OLACAKSA EKLERIZ VE SONRA KAMPANYA TURLERINI BIZ KENDIMIZ PROGRAM.CS DE OLUSTURURUZ YANI VERIYI ASLINDA VERITABANINDAN ALIRIZ
    class Kampayna2 : KampanyaType
    {
      

        public override void KampanyaDescribe()
        {
            Console.WriteLine("20% kampanya hakki kazandiniz..");
        }
    }
}
