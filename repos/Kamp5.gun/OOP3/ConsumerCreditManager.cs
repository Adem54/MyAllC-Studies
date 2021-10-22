using System;
using System.Collections.Generic;
using System.Text;

namespace OOP3
{
    class ConsumerCreditManager : ICrediManager//Eger bir sinif interface implement ediyorsa(base class i inherite etmeye interface
                                              //de biz implement etme deriz) o zaman o class implement ettigi interfacein imzalarini kullanmak zorundadir
                                              //Imza da bir methodu susluu paranatez haric geri kalan baslik kismidir
    {
        public void Calculate()
        {
            Console.WriteLine("Ihtiyac kredisi odeme plani hesaplandi");
        }

        public void CrediContracted()
        {
            Console.WriteLine("Ihtiyac kredisi alindi!!!");
        }
    }
}
