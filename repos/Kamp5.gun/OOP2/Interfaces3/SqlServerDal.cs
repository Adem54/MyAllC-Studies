using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces3
{
    class SqlServerDal : ICustomerDal
    {
        public void Add()
        {
            Console.WriteLine("SqlServerDal eklendi");
        }

        public void Delete()
        {
            Console.WriteLine("SqlServerDal silindi");
        }

        public void Update()
        {
            Console.WriteLine("SqlServerDal guncellendi");
        }
    }
}
