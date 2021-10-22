using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces2
{
    class Customer : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
