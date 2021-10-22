using Project4.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace Proje4.DataAccess
{
  public  interface IProductDal:IEntityRepostory<Product>,IAsyncEntityRepostory<Product>
    {
        
    }
}
