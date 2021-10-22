using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriYonetimSistUygTekrar.Entities
{
   public class Customer:IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string  LastName { get; set; }
        public int PassportNo { get; set; }

    }
}
