using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{//MAPPING -Veritabani kolon isimleri uygun isimler degilse o zaman biz veritabani class larimizi uygun isimlerle
    //veririrz ve mapping olayi
  public class Personel:IEntity
    {
        public int Id { get; set; }
        public string SurName { get; set; }
        public string Name { get; set; }
    }
}
