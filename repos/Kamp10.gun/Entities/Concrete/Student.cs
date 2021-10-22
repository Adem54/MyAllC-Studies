using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Student : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
    }
}
