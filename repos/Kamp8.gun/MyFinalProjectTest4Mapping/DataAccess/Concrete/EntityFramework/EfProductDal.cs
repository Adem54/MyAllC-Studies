using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                //var addedEntity = context.Entry(entity);
                //addedEntity.State = EntityState.Added;
                //context.SaveChanges();
                context.Products.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                //var deletedEntity = context.Entry(entity);
                //deletedEntity.State = EntityState.Deleted;
                //context.SaveChanges();
                var deletedEntity=context.Products.SingleOrDefault(p => p.ProductId == entity.ProductId);
                context.Products.Remove(deletedEntity);
                context.SaveChanges();
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                return filter == null ? context.Set<Product>().ToList() :
                    context.Set<Product>().Where(filter).ToList();
            }
        }

        public Product GetById(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                //var updatedEntity = context.Entry(entity);
                //updatedEntity.State = EntityState.Modified;
                //context.SaveChanges();
                var updatedEntity = context.Products.SingleOrDefault(p => p.ProductId == entity.ProductId);
                updatedEntity.ProductName = entity.ProductName;
                updatedEntity.CategoryId = entity.CategoryId;
                updatedEntity.UnitPrice = entity.UnitPrice;
                updatedEntity.UnitsInStock = entity.UnitsInStock;
                context.SaveChanges();
            }
        }
    }
}
