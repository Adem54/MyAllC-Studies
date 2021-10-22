using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{//Burda kullanilacak olna teknolojii ne ise veriye ulasmak icin kullanilan teknoloji ne ise onun Dal ini yazariz
    public class InMemoryProductDal : IProductDal
    {

        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product>
         {
             new Product(){ProductId=1, CategoryId=1, ProductName="Bardak",UnitPrice=5, UnitsInStock=14},
             new Product(){ProductId=2, CategoryId=1, ProductName="Tabak",UnitPrice=7, UnitsInStock=9},
             new Product(){ProductId=3, CategoryId=2, ProductName="Ekran",UnitPrice=50, UnitsInStock=17},
             new Product(){ProductId=4, CategoryId=2, ProductName="Klavye",UnitPrice=25, UnitsInStock=11},
             new Product(){ProductId=5, CategoryId=2, ProductName="Mause",UnitPrice=35, UnitsInStock=24}
         };
        }

      

        public void Add(Product product)
        {
            _products.Add(product);
        }

  

        public void Delete(Product product)
        {//SingleOrDefault calismasi icin Linq i using.system de eklememiz gerekir
            
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);

            _products.Remove(productToDelete);

        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public ProductDetailDto GetById(int productDetailID)
        {
            throw new NotImplementedException();
        }

      

        public List<ProductDetailDto> GetProductsDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.FirstOrDefault(p => p.ProductId == product.ProductId);

            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            product.UnitsInStock = product.UnitsInStock;
        }
    }
}
