using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
  public  class CustomerTest:IEntity
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public int CustomerTypeId { get; set; }
    }
}
