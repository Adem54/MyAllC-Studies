using Proje4.DataAccess;
using Project4.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project4.Business
{
  public  class ProductManager:IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        //HATA YONETIMINI KATMANLI MIMARI DE NASIL YAPARIZ ONU BURDA UYGULAYACAGIZ
        public void Add(Product product)
            //ornegin urun ismi Laptop ise eklemeye izin vermek istemiyoruz...
            //Bu tur durumlarda throw ile hata firlatiriz...
        {
            //BU ARADA DIKKAT EDELIMMM-BURDA DIREK IF-ELSE ICINDE SADECE THROW FIRLATIYORUZ...
            if (product.ProductName=="Laptop")
            {//Urun ismi laptop girilirse o zaman uygulama burda kirilacak ve bir throw firlatacagiz bir hata firlatacagiz
             //Kendi exception imizi yazmadan once Exception ile karsiladik bu hatayi ama bu dogru bir yaklasim degil
             //Console uygulamasindan detaylica nedenini acikladik!!!
                // throw new Exception("Laptop ekleyemezsiniz!!");
                throw new DuplicateProductException("Ayni isimde urun ekleyemezzsiniz");
                //Burda biz DuplicateProductException...firlatiriz.Sonrasinda bizim bunu arayuzde,Console da yakalamamiz
                //gerekiyor ama yakalarken de ne firlatildi ise onun uzerinden yakalamaliyiz...
                //Gercek hayat uygulamalarinda da biz boyle hatalari firlatiriz gelistirici olarak.Cunku arayuzde olusan
                //hatanin ne oldugunu bizim bilmemiz gerekiyor...
            }
            //Urun ismi latop  girilmezse product ekleme islemi calisacak!!!!
            _productDal.Add(product);
        }

        public Task AddAsync(Product product)
        {
            throw new NotImplementedException();
        }

    

        public async  Task<List<Product>> GetAllAsync()
        {
            return await  _productDal.GetAllAsync();
            //Bunu artil consolde calistirabiliriz ama suna dikkat edelim
            //Task tipinde donecegi icin taskin altindaki Result properties inden product verilerine ulasiriz....
        }

      

        public async Task<Product> GetByIdAsync(int productId)
        {
            return await _productDal.GetByIdAsync(productId);
        }

     

       

       async Task IProductService.DeleteAsync(Product product)
        {
            await _productDal.DeleteAsync(product);
        }

       async Task IProductService.UpdateAsync(Product product)
        {
           await _productDal.UpdateAsync(product);
        }
    }
}
