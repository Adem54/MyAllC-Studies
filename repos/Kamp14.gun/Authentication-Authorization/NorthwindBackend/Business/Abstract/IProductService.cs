using Core.Utilities;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{//Biz neden business de repostory design patter yapmiyoruz diye dusunecek olursak
    //Business repostory ye uygun degildir cunku...
    //arayuzden cok farkli veriler gonderilebiliyor ve biz her zaman onlari karsilamayiz
    //Business de saf birsekilde operasyonlarimizi yazariz
   public interface IProductService
    {
        IDataResult<Product> Get(int productId);
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetByAllCategory(int categoryId);
        IResult Add(Product product);
        IResult Update(Product product);
        IResult Delete(Product product);
      //Transaction i test etmek icin yazariz...
        IResult TransactionalOperation(Product product);
        
    }
}
//Is katmanimizin adaptorudur ve servis islevi gorur burasi...
//Yani bir yere veri alinmasi gerektigi zaman biz dependency injection ile yazacagimiz icin
//bu servisi alacagiz..