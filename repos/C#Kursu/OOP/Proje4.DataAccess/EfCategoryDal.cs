using Project4.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Proje4.DataAccess
{
    public class EfCategoryDal : ICategoryDal
    {
        public void Add(Category entity)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();//Transaction-UnitOfWork
            }
        }

        public void Delete(Category entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();//Transaction-UnitOfWork
            }
        }

        public List<Category> GetAll()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return  context.Categories.ToList();
                
            }
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();//Transaction-UnitOfWork
            }
        }
    }
}
