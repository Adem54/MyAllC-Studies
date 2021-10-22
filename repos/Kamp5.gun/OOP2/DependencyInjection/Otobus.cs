using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    class Otobus : ITasit
    {
        public void FrenYap()
        {
            Console.WriteLine("Otobus fren yapiyor");
        }

        public void GazVer()
        {
            Console.WriteLine("Otobus gazveriyor");
        }

        public void SagaSinyal()
        {
            Console.WriteLine("Otobus saga sinyal veriyor");
        }

        public void SolaSinyal()
        {
            Console.WriteLine("Otobus sola sinyal veriyor");
        }
    }
}
