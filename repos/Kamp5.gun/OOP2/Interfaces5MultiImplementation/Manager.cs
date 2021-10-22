using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces5MultiImplementation
{
    class Manager : IWorker,IEat,IGetSalary
    {
        public void Eat()
        {
            Console.WriteLine("Manager yemegini yedi");
        }

        public void GetSalary()
        {
            Console.WriteLine("Manager maasini aldi");
        }

        public void Work()
        {
            Console.WriteLine("Manager calismaya basldi");
        }
    }
}
