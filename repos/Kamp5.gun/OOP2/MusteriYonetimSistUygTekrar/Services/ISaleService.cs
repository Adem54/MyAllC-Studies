using MusteriYonetimSistUygTekrar.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriYonetimSistUygTekrar.Services
{
 public   interface ISaleService
    {
        void Sale(Customer customer, Product product);
    }
}
