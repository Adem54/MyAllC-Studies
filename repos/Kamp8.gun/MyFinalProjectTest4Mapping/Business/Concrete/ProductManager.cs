using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
public  class ProductManager:IProductService
    {
        IProductDal _productDal;
        

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
           
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }

       
    }
}
