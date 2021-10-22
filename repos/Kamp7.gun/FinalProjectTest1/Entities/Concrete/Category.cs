using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
 public class Category:IEntity//isaretleme teknigi kullandik IEntity islevi burda bunu goren bunlarin veri tabani
        //elemani oldugunu anlamis oluyor...
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
