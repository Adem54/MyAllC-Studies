using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemoryProductDal
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product {ProductId=1, CategoryId=1, ProductName="Elma", UnitPrice=30, UnitsInStock=24},
                new Product {ProductId=2, CategoryId=1, ProductName="Armut", UnitPrice=35, UnitsInStock=34},
                new Product {ProductId=3, CategoryId=1, ProductName="Ayva", UnitPrice=22, UnitsInStock=14},
                new Product {ProductId=4, CategoryId=2, ProductName="Marol", UnitPrice=18, UnitsInStock=54},
                new Product {ProductId=5, CategoryId=2, ProductName="Domates", UnitPrice=25, UnitsInStock=64},
            };
        }



        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //Direk _products.Remove(product)--yok oyle birsey gelen product kullanici girdikten sonra new lenerek 
            //bize gelir dolayisi ile bellek te heap te yeni bir adres tutar bizim listeden veritabanindan silmemizie
            //istedigi product nesnesi ise bambaska bir adrestedir kullanicinn gonderdigii veriler herseyi ile 
            //ayni olsa bile referans adresler farklidir dolayisi ile once kullanicnin gonderdigi verilerden 
            //ProductId yi kullarnarak veritabanindaki o product nesnesini bul ve onu sil.....

            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
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

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.FirstOrDefault(p => p.ProductId == product.ProductId);

            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            product.UnitsInStock = product.UnitsInStock;
        }
    }
}
