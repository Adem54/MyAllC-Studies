using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{//Kullanici rolleri,rol Id si ve rol ismi
  public  class OperationClaimTest:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
