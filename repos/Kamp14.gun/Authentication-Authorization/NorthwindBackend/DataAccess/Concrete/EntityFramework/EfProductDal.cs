using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //EfEntityRepostoryBase<Product,NorthwindContext> zaten IEntityRepostory yi implement ettigi icin
    
    //Artik Crud islemlerimiz hazir..
    //Bu sekilde yapmamiz sayesinde tamamen mesela Product a ozel join operasyonlarinda
    //gidip IProductDal a yazabiliriz..diye...
    public class EfProductDal :EfEntityRepostoryBase<Product,NorthwindContext>, IProductDal
    {

    
           
    }
}
