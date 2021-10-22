using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
  public  class Customer:IEntity
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public bool IsStudent { get; set; }
        public bool IsOfficer { get; set; }
        
    }
}
