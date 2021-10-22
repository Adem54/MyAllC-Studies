using Project4.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Proje4.DataAccess
{
    public interface IAsyncEntityRepostory<T> where T : class, IEntity, new()
    {
       Task<List<T>> GetAllAsync();
       Task AddAsync(T entity);

        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);

        Task<T> GetByIdAsync(int id);
    }
}
//Burasi interfaceimiziin async methodlari olan versiyonu oldugundan dolayi methodlarin sonuna Async ile bitiririz