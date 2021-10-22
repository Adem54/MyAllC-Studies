using HomeWork.Abstract;
using HomeWork.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork.Concrete
{////YANLIS BIR CLASS OLUSTURMA SEKLI OYUN TURLERINDEN OPERASYON CLASS I OLUSTURULMAZ OYUN TURLERINI BIR PROPERTY CLASS I OLUSTURUP ORAYA ATMALI IDIK
    //YANI OYUN TURLERINI BIZ PROGRAM.CS DE KENDIMIZ ATAYACAGIZ YANI ONLAR VERITABANINDAN GELECEK GIBI DUSUNLEIMMM
    class SuperRacing : IGameSeller
    {
        public void Sell(Person person)
        {
            Console.WriteLine(person.FirstName+ " oyuncusunun oynadigi SuperRacing oyunu 65 adet satildi");
        }
    }
}
