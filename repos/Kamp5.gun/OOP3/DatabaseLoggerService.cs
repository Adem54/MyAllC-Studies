using System;
using System.Collections.Generic;
using System.Text;

namespace OOP3
{
    class DatabaseLoggerService : ILoggerService//bu class ILoggerService i implement ediyor burda
        //Bu class a sen bir ILoggerService alternatifisin diyoruz
    {
        public void Log()
        {
            Console.WriteLine("Veritabanina loglandi");
        }
    }
}

//Bir kisa yontem=>Burdaki class imizi kopyalayip alta yapistirirz sonra class ismini degistiririz ardindan class isminin uzerine
//bir kere dokunup imleci birakinriz ve ampul gelir ampulu acip move type file diye bir secenek var onu seceriz kopyaladigimiz
//class imizi farkli dosyay tasir tekrar tekrar kendimiz class olusturmakla ugrasmamiz oluruz
