using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces4Polimorfism
{
    class SqlServerDal : ICustomerDal
    {
        public void Add()
        {
            Console.WriteLine("SqlServerdala verilerimiz eklendi");
        }

        public void Delete()
        {
            Console.WriteLine("SqlServerdaldaki verileri silindi");
        }

        public void Update()
        {
            Console.WriteLine("SqlServerdalda verilen guncellendi");
        }
    }
}
