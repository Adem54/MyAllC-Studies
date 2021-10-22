using MusteriYonetimSistUygTekrar.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriYonetimSistUygTekrar.Services
{
public  interface IVerifyCustomerService
    {
        public bool CheckCustomerInfo(Customer customer);
    }
}
