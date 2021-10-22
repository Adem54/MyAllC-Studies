using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //where T:class//bu T referans tip olmali demektir bu T sadece class olabilir demek degildir
    //Yani buraya biz interface de koyabiliriz,abstract da koyabiliriz demektir
    //where T:IEntity=>ayni zamanda IEntity olmali diyoruz.Simdi IEntity nin bosuna olmadigini daha iyi
    //anlariz
    //where T: new() demek ise new lenebilir olsun yani interface olmasin diyoruz aslinda
   public interface IEntityRepostory<T> where T:class,IEntity,new()
    {
        T Get(Expression<Func<T,bool>> filter);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);//Filtre gonderilmezse tumunu listele
        //Tum filtrelenmis listeleme islemlerini burda yapariz

        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
