using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    //Burasi Crud islemlerini yapacagimiz yer
    //Veri listelerken Get ve GetAll ile paramtrelerde biz filtreleme islemleri de yapacagiz..
    //Ve biz veritabaninda yapiyoruz islemleri ve veritabani kismini biz NorthwindContext i uzerinden
    //yapiyoruz dolayisi ile bizim bir tane veritabani islemleri icin context e bir de entity
    //nesnesine ihtiyacimiz var.O zaman biz burdaki generic repostory design pattern base inde
    //iki tane degisen generic nesne vardir....
    //Burda nedir en kiritik sey 1.linq sorgulari yazarizz  2.Context ile veritabani CRUD
    public class EfEntityRepostoryBase<TEntity, TContext> : IEntityRepostory<TEntity>
          where TEntity : class, IEntity, new()
          where TContext : DbContext, new()//DbContext EntityFrameworkCore paketinden geliyor
                                           //DbContext abstract nesne old icin o da yazilamamali ve kisit getirmeliyiz ona da...
    {
        public void Add(TEntity entity)
        {
            using (TContext context=new TContext())//context pahali bir nesne old icin
                //contex in isi bittigi gibi using context in silinmesini sagliyor
            {
                var addedEntity = context.Entry(entity);//entity yi context e abone ediyoruz
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context=new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context=new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context=new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() :
                    context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context=new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
