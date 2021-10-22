using MusteriYonetimSistUygTekrar.Entities;
using MusteriYonetimSistUygTekrar.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriYonetimSistUygTekrar.Managers
{
    public class VerifyCustomerManager : IVerifyCustomerService
    {
        public bool CheckCustomerInfo(Customer customer)
        {
            if (customer.FirstName=="Adem"&& customer.LastName=="Erbas"&& customer.PassportNo==12345)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
