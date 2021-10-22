using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Officer : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
    }
}
