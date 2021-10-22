using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces4Polimorfism
{
    class OracleServerDal : ICustomerDal
    {
        public void Add()
        {
            Console.WriteLine("OracleServerDal a veri eklendi");
        }

        public void Delete()
        {
            Console.WriteLine("OracleServerDalda  verimiz silindi");
        }

        public void Update()
        {
            Console.WriteLine("OracleServerDal da verimiz guncellendi");
        }
    }
}
