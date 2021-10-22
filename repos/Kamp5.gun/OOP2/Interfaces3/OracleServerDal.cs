using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces3
{
    class OracleServerDal : ICustomerDal
    {
        public void Add()
        {
            Console.WriteLine("OracleServerDal eklendi");
        }

        public void Delete()
        {
            Console.WriteLine("OracleServerDal silindi");
        }

        public void Update()
        {
            Console.WriteLine("OracleServerDal guncellendi");
        }
    }
}
