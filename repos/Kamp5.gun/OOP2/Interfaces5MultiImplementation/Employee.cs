using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces5MultiImplementation
{
    class Employee : IWorker,IEat,IGetSalary
    {
        public void Eat()
        {
            Console.WriteLine("Employee yemegini yedi");
        }

        public void GetSalary()
        {
            Console.WriteLine("Employee maasini aldi");
        }

        public void Work()
        {
            Console.WriteLine("Employee calismaya basladi");
        }
    }
}
