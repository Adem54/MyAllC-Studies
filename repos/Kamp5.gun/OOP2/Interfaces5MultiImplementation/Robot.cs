using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces5MultiImplementation
{
    class Robot : IWorker
    {
        //public void Eat()
        //{
            
        //}

        //public void GetSalary()
        //{
           
        //}

        public void Work()
        {
            Console.WriteLine("Robot calismaya basladi");
        }
    }
}

//Robotumuz yemek yemez ve maas almaz sadece calisir peki biz interface e ama 3 tane ayri imza yazmisiz ama 2 si
//Robot klassina uyymuyor o zaman biz interface tasarimini hatali olusturmusuz cunku interface olusturdugumuz imzalar
//onu implemente eden tum class larda bulunmak zorundadir. Biz burda sunu diyemeyiz Robot classinda biz Eat ve GetSalary
//methodununn icini bos birakiriz kullanmayiz olur biter diyemeyiz bu trik bir yontemdir
//Ama biz onun yerine soyle bir cozum uretebiliriz, IWork interfaceimizden Eat ve GetSalary imzalarini aliriz ve 2 tane daha
//yeni interface olustururuz adlari Eat ve GetSalary seklidne ve Eat imzasini Eat interfacesine Getsalary imzasini da
//GetSalary interface sine atariz, ki biz zaten bir class ta birden fazla interface kullanabiliyoruz
//(Ama bir class ta birden fazl inherit edemeyiz....)
//Biz her method imzamizi bir interface altina yazariz ve hangi class imizin hani methodlara ihtiyaci varsa o interfacleri
//implement ettiririz