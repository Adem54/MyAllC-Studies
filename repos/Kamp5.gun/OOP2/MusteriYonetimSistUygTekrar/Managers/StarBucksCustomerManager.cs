using MusteriYonetimSistUygTekrar.Entities;
using MusteriYonetimSistUygTekrar.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriYonetimSistUygTekrar.Managers
{
   public class StarBucksCustomerManager:BaseCustomerManager
    {
        IVerifyCustomerService _verifyCustomerService;
        public StarBucksCustomerManager(IVerifyCustomerService verifyCustomerService)
        {
            _verifyCustomerService = verifyCustomerService;
        }
        public override void Add(Customer customer)
        {
            if (_verifyCustomerService.CheckCustomerInfo(customer))
            {
                base.Add(customer);
            }
            else
            {
                throw new Exception("Not valid person");
            }
            
        }
    }
}
