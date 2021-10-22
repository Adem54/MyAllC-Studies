using Project4.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje4.DataAccess
{
 public   interface IEntityRepostory<T>where T:class,IEntity,new()
    {
        List<T> GetAll();
        void Add(T entity);

        void Delete(T entity);
        void Update(T entity);

        T GetById(int id);
    }
}
//Generic yapilarda genellikle bir kodun hem asenkron hem de normal versiyojnunu goruruz yani senkron
//Cunku isteyen asenkron yapisini kullansin isteyende senkron versiyonunu kullanmasi icin
//Normalde biz ayni interface icinde metodlarin asenkron halini de yazabiliriz ama onun yerine bir tane 
//daha interface IAsyncEntityRepostory isminde interface olusturup onun icine de methodlarimizin asenkron 
//versiyonlarini yazabiliriz...