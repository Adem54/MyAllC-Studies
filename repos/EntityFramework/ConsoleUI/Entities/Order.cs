using System;
using System.Collections.Generic;
using System.Text;

namespace NortwindEfCodeFirst.Entities
{
   public class Order
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }//urunun gonderilecegi adres anlamina geliyor..
        public string ShipCountry { get; set; }
        public DateTime OrderDate { get; set; }
        public Customer Customer { get; set; }
    }
}
