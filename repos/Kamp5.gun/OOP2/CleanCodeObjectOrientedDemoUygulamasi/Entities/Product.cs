using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeObjectOrientedDemoUygulamasi.Entities
{
public  class Product:IEntity
    {
       

     


        public int Id { get; set; }
        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }


    }
}
