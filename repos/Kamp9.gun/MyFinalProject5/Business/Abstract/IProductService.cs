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
       IDataResult <List<Product>> GetProducts();
       IDataResult <Product> GetById(int productId);//Urun detayi
        IDataResult<List<Product>> GetByIdCategory(int categoryId);//Kategoryiye gore getir
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);//Fiyat araligi getir!!!

        IDataResult<List<ProductDetailDto>> GetPDetailsDto();

        IResult Add(Product product);
    }
}
