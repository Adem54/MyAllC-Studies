using MusteriYonetimSistUygTekrar.Entities;
using MusteriYonetimSistUygTekrar.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriYonetimSistUygTekrar.Managers
{
  public  class NeroCustomerManager:BaseCustomerManager
    {
        public override void Add(Customer customer)
        {
            base.Add(customer);
        }
    }
}
