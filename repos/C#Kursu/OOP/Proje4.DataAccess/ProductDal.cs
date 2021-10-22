using Project4.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Proje4.DataAccess
{
    public class ProductDal:IProductDal
    {
        List<Product> _products;
        public ProductDal()
        {
            _products = new List<Product>
            {
                new Product
                {
                    ProductId=1, ProductName="Acer Bilgisayar", QuantityPerUnit="32GB Ram", UnitPrice=10000, UnitsInStock=2
                },
                 new Product
                {
                    ProductId=2, ProductName="Asus Bilgisayar", QuantityPerUnit="16GB Ram", UnitPrice=7000, UnitsInStock=0
                },
                  new Product
                {
                    ProductId=3, ProductName="Acer Bilgisayar", QuantityPerUnit="12GB Ram", UnitPrice=12000, UnitsInStock=4
                },
                    new Product
                {
                    ProductId=4, ProductName="Lenovo Bilgisayar", QuantityPerUnit="64GB Ram", UnitPrice=16000, UnitsInStock=5
                },
                      new Product
                {
                    ProductId=5, ProductName="Mac Bilgisayar", QuantityPerUnit="8GB Ram", UnitPrice=13000, UnitsInStock=9
                }



            };
        }

        public void Add(Product product)
        {
            Console.WriteLine("ADO net ile eklendi!!");
        }

        public Task AddAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public Task<List<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Product GetById(int ProductId)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
