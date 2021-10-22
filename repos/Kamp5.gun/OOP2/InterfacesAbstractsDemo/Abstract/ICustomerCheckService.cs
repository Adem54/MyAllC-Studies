using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriYonetimSistUygulamasi.Abstract
{
   public interface ICustomerCheckService
    {
        bool CheckIfRealPerson(Customer customer);//Imzamizi birakiriz sadece
    }
}

