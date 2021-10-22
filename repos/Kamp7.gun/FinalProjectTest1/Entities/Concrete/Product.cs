using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{//Hemen class i public yaplim
   public class Product:IEntity//Isaretleme teknigi kullandik IEntity gorenler bu class in bir veritabani nesnesi
                               //oldugunu anlarlar
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
       public short UnitsInStock { get; set; }
    }
}

