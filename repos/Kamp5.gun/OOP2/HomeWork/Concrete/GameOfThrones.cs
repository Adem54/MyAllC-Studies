using HomeWork.Abstract;
using HomeWork.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork.Concrete
{//YANLIS BIR CLASS OLUSTURMA SEKLI OYUN TURLERINDEN OPERASYON CLASS I OLUSTURULMAZ OYUN TURLERINI BIR PROPERTY CLASS I OLUSTURUP ORAYA ATMALI IDIK
    class GameOfThrones : IGameSeller
    {
        public  void Sell(Person person)
        {
            Console.WriteLine(person.FirstName+ " oyuncusunun oynadigi GameOfThrones oyunu 23 adet satildi");
        }
    }
}
