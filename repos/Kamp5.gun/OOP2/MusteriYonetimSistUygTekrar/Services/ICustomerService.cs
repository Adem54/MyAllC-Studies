using MusteriYonetimSistUygTekrar.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriYonetimSistUygTekrar.Services
{
  public interface ICustomerService
    {
        void Add(Customer customer);
        void Delete(Customer customer);
        void Update(Customer customer);
    }
}
