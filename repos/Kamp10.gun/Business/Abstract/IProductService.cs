using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IProductService
    {
        void Sell(Product product,Customer customer);
    }
}
