
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<Product> Get(int productId);
       IDataResult <List<ProductDetailDto>> GetProductDtos();
        IDataResult<List<Product>> GetAllByCategory(int categoryId);
        IResult Add(Product product);
        IResult Delete(Product product);
        IResult Update(Product product);

        IResult TransactionalOperation(Product product);
        
    }
}
