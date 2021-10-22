using System;
using System.Collections.Generic;
using System.Text;

namespace Classes2
{
   public class ProductManager
    {
        public void Add(Product product)
        {
            Console.WriteLine($"{product.ProductName}   verisi eklendi");
        }
    }
}
