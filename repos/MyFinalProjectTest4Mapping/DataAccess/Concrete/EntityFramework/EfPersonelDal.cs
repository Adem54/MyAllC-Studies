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
    public class EfPersonelDal : IPersonelDal
    {
        public void Add(Personel entity)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Personel entity)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

        public List<Personel> GetAll(Expression<Func<Personel, bool>> filter = null)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                return filter == null ? context.Set<Personel>().ToList() :
                    context.Set<Personel>().Where(filter).ToList();
            }
        }

        public Personel GetById(Expression<Func<Personel, bool>> filter)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                return context.Set<Personel>().SingleOrDefault(filter);
            }
        }

        public void Update(Personel entity)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
