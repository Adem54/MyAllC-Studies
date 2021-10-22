using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
  
    public class Product:IEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int  CategoryId { get; set; }
        public string  QuantityPerUnit { get; set; }//Bir pakette kac tane var
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }


    }
}
//bir property clas inin default u internal dir
//bir field in default hali private dir
//protected inherit ettigi yerde o ozelligi kullanabilirsiniz
//Ciplak class kalmamali-Base in yoksa bile o tur property nesnelerini gruplandiran bir imzalama
//yontemi yapiyoruz bir de kodlamayi da kisitlamamiz gereken yerlerde de cok isimize yarayacak
//baska bir katmandaki bir interface veya nesneyi kullanacaksak o katmani referans olarak vermeliyiz