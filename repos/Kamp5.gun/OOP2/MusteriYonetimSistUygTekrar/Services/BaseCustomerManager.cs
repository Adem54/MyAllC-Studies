using MusteriYonetimSistUygTekrar.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriYonetimSistUygTekrar.Services
{
    public abstract class BaseCustomerManager : ICustomerService
    {
        public virtual void Add(Customer customer)
        {
            Console.WriteLine($"{customer.FirstName}  added");
        }

        public void Delete(Customer customer)
        {
            
        }

        public void Update(Customer customer)
        {
            
        }
    }
}
