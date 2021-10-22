using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces2
{
    //Ornegin bunu sonradan sistemimize entegre ettgimizi dusunursek
    class Student : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
