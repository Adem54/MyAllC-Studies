using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces4Polimorfism
{
    class MysqlServerDal : ICustomerDal
    {
        public void Add()
        {
            Console.WriteLine("MysqlServerDal a veriler eklendi");
        }

        public void Delete()
        {
            Console.WriteLine("MysqlServerDal dan veriler silindi");
        }

        public void Update()
        {
            Console.WriteLine("MysqlServerDal daki veriler guncellendi");
        }
    }
}
