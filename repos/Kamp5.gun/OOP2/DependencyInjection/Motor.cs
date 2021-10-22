using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    class Motor : ITasit
    {
        public void FrenYap()
        {
            Console.WriteLine("Motor fren yapiyor");
        }

        public void GazVer()
        {
            Console.WriteLine("Motor gaz veriyor");
        }

        public void SagaSinyal()
        {
            Console.WriteLine("Motor saga sinyal veriyor");
        }

        public void SolaSinyal()
        {
            Console.WriteLine("Motor sola sinyal veriyor");
        }
    }
}
