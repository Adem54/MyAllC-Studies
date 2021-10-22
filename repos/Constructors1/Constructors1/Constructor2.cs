using System;
using System.Collections.Generic;
using System.Text;

namespace Constructors1
{
   public class Constructor2
    {

        public Constructor2(int sayi1,int sayi2,int sayi3)
        {
            Sayi1 = sayi1;
            Sayi2 = sayi2;
            Sayi3 = sayi3;
        }

        public Constructor2()
        {

        }

        public Constructor2(string firstName,string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

        }

        public int Sayi1 { get; set; }
        public int Sayi2 { get; set; }
        public int Sayi3 { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
