using BankaKrediUygulamasi.Credits.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankaKrediUygulamasi.Credits.Concrete
{
    public class MortgageCredit : ICrediService
    {
        public void Calculate()
        {
            Console.WriteLine("MortgageCredit hesaplandi");
        }

        public void CrediContract()
        {
            Console.WriteLine("Konut kredisi CrediContracti yapilmistir");
        }
    }
}
