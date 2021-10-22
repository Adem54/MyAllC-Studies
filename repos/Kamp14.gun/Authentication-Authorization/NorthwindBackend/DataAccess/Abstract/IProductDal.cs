using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{//Bu katmanda ben Core katmanindan ve IEntity katmanindan interface ve property nesneleri ile calismaya
    //calisiyorum o zaman o katmanlari referans olarak vermeliyim
   
    //Interface icin bir tane global interface olusturduk IEntityRepostory adinda
    //IProductDal in somutunda da bir tane somut baseEfRepostory nesnesi olusturacagiz...
    public interface IProductDal:IEntityRepostory<Product>
    {

    }
}
//Bir teknoloji kullaniliyorsa mutlaka klasorlenmelidir