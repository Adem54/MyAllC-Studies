using CleanCodeObjectOrientedDemoUygulamasi.Entities;
using CleanCodeObjectOrientedDemoUygulamasi.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeObjectOrientedDemoUygulamasi.Managers
{
    public abstract class SaleManagerBase : ISaleService
    {
     

        //Burasi hic indirim yapilmamis hali biz de 
        public virtual void SaleTL(Customer customer,Product product)
        {
          
            Console.WriteLine($"{customer.FirstName} musterisi  {product.ProductName } urunu icin" +
                $" {product.UnitPrice} TL odedi");
            
        }

        public virtual void SaleWithOtherCurrency(Customer customer, Product product,CurrencyRateDto currencyRateDto)
        {
           

        }
    }
}
