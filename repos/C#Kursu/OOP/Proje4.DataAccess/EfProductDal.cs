using Project4.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Proje4.DataAccess
{
    public class EfProductDal : IProductDal
    {
        List<Product> _products;
        public EfProductDal()
        {



        }

        public void Add(Product product)
        {
            //Biz bunu simule ediyoruz normalde sistem gonderiri bunu
            //Biz bu throw u ornek vermek icin mesela veritabnina baglanma hatasi cikarsa
            //biz bunu anlayamayabiliriz onun icin biz hata yonetimini sadece catch(Exception)
            //ile yapmayalim demistik....
            //  throw new Exception("Veritabanina baglanma hatasi....xxxx sifresi dogru degil!!");
            using (NorthwindContext context = new NorthwindContext())
            {
                context.Products.Add(product);
                context.SaveChanges();//Bu transiction dir yani eger
                                      //biz Add eklme den once baska ekleme vs de yaparsam tum 
                                      //veritabani islemleri basari ile biterse kaydederek islemleri
                                      //gerceklestirecek yoksa diyelim en son asamada bir sorun yasandi
                                      //o zaman digerlerini de geri alacak...
                                      //Yani mesela ben birisine para yatirdim ama arkadasima da 
                                      //ulasmadi para o zaaman benden para silindi ama ona para 
                                      //eklenmedi o zaman ne yapiyor transiction benim para yatirma
                                      //islemini de geri alarak benim paramin geri gelmesini sagliyor
                                      //UnitOfWork islemi Entity kendi icinde yapiyor...

            }

        }

        //Biz burda Task donduruyoruz...Ama Task vermeden once ne donuyorsa onu Task araciligi ile donderiyoru
        //Biz ayni bizim onceden Result islemlerinde yaptiggimiz gibi donus tipimizi Task yaptik...
        public async Task AddAsync(Product product)
        {
            NorthwindContext context = new NorthwindContext();
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
        }

        public void Delete(Product product)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //context.Remove(product)=>HATALI,YANLISTIR...
                context.Remove(context.Products.SingleOrDefault
                    (p => p.ProductId == product.ProductId));
                context.SaveChanges();
            }
        }

        //IDisposable using ile Asenkron Yapilarin Calismasi
        //Bu tip asenkro yapilarda using IDisposabel yapilar noroalde nasil calisiyordu context cok maliyetli
        //oldugu icin bellekte onlarin fazla yer kaplamamasi icin isini bitirir bitirmez hemen onu bellekte silme
        //silme egilimine giriyordu iste bu yapi asenkron yapilarda icerdeki kodlarin calismasii daha bitmeden
        //silip belltekten atilma riski tasiyor , cunku once context i olusturur ve ondan sonra hizli bir sekild
        //silip bellkten atma egilimine girer, biz senkron yapilarda using islemlerinde context olusturduk
        //tan sonra icerdeki operasyonlari n calisacagini garanti ederiz cunku single thread yani sira ile calisir
        //ama asenkron yapilarda bunu garanti edemeyiz ondann dolayi bizim asenkron yapilarda disposabel yapilari
        //bir kenara birakmamiz gerekiyor
        //Bizim asenkron yapilari calistirmamizin nedeni thread leri verimli kullanmak iste o verimli kullanmayi
        //gerceklestirmek icin context olusur olusmaz onu aninda bellekten atmaya calisiyoruz normalde using de
        //Ama zaten asenkron yapiya gectigimiz icin using e ihtiyacimiz yok


        public async Task DeleteAsync(Product product)
        {

            NorthwindContext context = new NorthwindContext();
                //context.Remove(product)=>HATALI,YANLISTIR...
                //Remove isleminde Remove  un basina Async gelmiyor ama zaten Remove parametresi icindeki methoda 
                //biz asenkron olaarak o isi yapmis oluyoruz...ayni sey 
                context.Products.Remove(await context.Products.SingleOrDefaultAsync
                    ( p => p.ProductId == product.ProductId));
               await context.SaveChangesAsync();
           
        }

        public List<Product> GetAll()
        {
      
            NorthwindContext northwindContext = new NorthwindContext();
            _products = northwindContext.Products.ToList();
            return _products;
        }

        public Task<List<Product>> GetAllAsync()
        {
            NorthwindContext northwindContext = new NorthwindContext();
            
            return northwindContext.Products.ToListAsync();
        }

        public Product GetById(int productId)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Products.SingleOrDefault(p => p.ProductId == productId);
            }
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            NorthwindContext context = new NorthwindContext();
            return await context.Products.SingleOrDefaultAsync(p => p.ProductId == id);
        }

        ////Find liste doner ama sen Product don diyorsun orda sorun yasaniyor..
        //Single or Default eger 1 den fazla data bulursa o zaman hata veriyor
        //Ama hic bulamazsa null doner...
        //FirstOrDefault kullanirsak ise eger birden fazla ayni id den bulursa
        //o zaaman ilk buldugunu getirir
        //Ama biz veritabani tablosundan id uzerinden arama yaptigmiz icin orda
        //ayni id den birden fazla gibi bir durum soz konusu olmayacaktir

        public void Update(Product product)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                Product productToUpdate = context.Products.SingleOrDefault
                     (p => p.ProductId == product.ProductId);
                productToUpdate.ProductName = product.ProductName;

                productToUpdate.QuantityPerUnit = product.QuantityPerUnit;
                productToUpdate.UnitPrice = product.UnitPrice;
                productToUpdate.UnitsInStock = product.UnitsInStock;
                context.SaveChanges();
   }
        }

        public async Task UpdateAsync(Product product)
        {
            NorthwindContext context = new NorthwindContext();
            Product productToUpdate = await context.Products.SingleOrDefaultAsync
                        (p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;

            productToUpdate.QuantityPerUnit = product.QuantityPerUnit;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
           await context.SaveChangesAsync();
        }
    }
}
