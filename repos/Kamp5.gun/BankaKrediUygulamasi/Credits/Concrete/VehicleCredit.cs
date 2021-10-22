using BankaKrediUygulamasi.Credits.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankaKrediUygulamasi.Credits.Concrete
{
    public class VehicleCredit : ICrediService
    {
        public void Calculate()
        {
            Console.WriteLine("Arac kredisi hesaplandi");
        }

        public void CrediContract()
        {
            Console.WriteLine("Arac Kredisi kontrati hesaplandi");
        }
    }
}
