using Project4.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project4.Business
{
 public   interface IProductService
    {
        Task<List<Product>> GetAllAsync();
        Task AddAsync(Product product);
        Task DeleteAsync(Product product);
        Task UpdateAsync(Product product);
        Task<Product> GetByIdAsync(int productId);
       
    }
}
