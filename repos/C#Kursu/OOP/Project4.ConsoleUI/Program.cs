using Proje4.DataAccess;
using Project4.Business;
using Project4.Entities;
using System;

namespace Project4.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            ProductManager productManager = new ProductManager(new EfProductDal());

            
            foreach (var item in productManager.GetAllAsync().Result)
            {
                Console.WriteLine("Async ile urun ismi geliyor  "+item.ProductName);
            }
            
            PersonelManager personelManager = new PersonelManager(new EfPersonelDal());



            //productManager.Update(new Product()
            //{
            //    ProductId=78,
            //    ProductName = "OURLaptop",
            //    CategoryId = 6,
            //    QuantityPerUnit = "16GB Ram",
            //    UnitPrice = 1600,
            //    UnitsInStock = 12
            //});

            foreach (var personel in personelManager.GetAll())
            {  
                Console.WriteLine("{0} / {1}/ {2}" , personel.Id, personel.Name, personel.Surname);
            }

            //EXCEPTION YONETIMIMIZI TEST EDIYORUZ BURDA!!!
            Console.WriteLine("---------------------------------------------------------");
         

            //Biz bir de try-cathc blogunu bir de  bizim bu projedeki arayuzumuz olan su an icinde bulundugmuz
            //Console da calistiralim biz burayi yani su anki console api gibi dusunelim
            //Ve burda hata detayimizi,hata mesajimizi alalim,eriselim
            //Burda suna dikkat edelim bizim uygulamamiz hicbiryerde kirilmadan direk arayuzumuzde bize hata detayini
            //gosteriyor!!!!
            try
            {
                productManager.Add(new Product()
                {
                    ProductId = 6,
                    ProductName = "Laptop",
                    QuantityPerUnit = "16GB Ram",
                    UnitPrice = 1600,
                    UnitsInStock = 12
                });
            }
            //ProductManager dan DuplicateProductException firlatildigi icin bizim bu hatayi yakalayabilmemiz icin
            //tabi ki catch de de DuplicateProductException kullanmamiz gerekecek....
            catch (DuplicateProductException exception)
            //Dikkat edelim biz burda Exception kullandik,yani hata turu ne olursa olsun o hatanin mesajini yazacak
            //Exception yazarak her turlu excepiton u kontrol etttik.
            //Mesela diyelim ki bu cathc de aslinda bizim yazdigimiz hata degil de bambask bir hata cikti yani biz 
            //ProductName e Laptop disinda bir veri girdik ama catch bloguna gelince bizimde hic ongormeyecegimiz
            //ornegin veritabanina baglanma hatasi gibi bir hata olustu o zaman ne olacak o zaman o hataya ait bilgileri
            //gidip kullaniciya, gosterecegiz, veritabani bizim icin cok hassastir hacklenmemesi icin veritabanina ait
            //herhangi bir veri kullaniciya gosterilememelidir....ISTE BU BUYUK BIR GUVENLIK ACIGIDIR.....
            //Biz Laptop isminde bir urun girmememize ragmen arayuze geldi ve bizim EfProductdal da Add icine simule etmek
            //icin yazdigimiz veritabani hatasi mesajini gonderdi arayuze
            //Neden boyle bir guvenlik acigi var cunku biz her turlu Exception i yakaliyoruz burda onun icin biz
            //ongorebileceklerimizi Exception altindaki nesneleri kullanarak dogrudan amaca uygun nesneleri
            //catch() parametresine yazarak kullanmamiz gerekiuyor ,ongoremediklerimizi ise Exception ile handle etmemiz
            //gerekecek.....
            //O zaman biz de catch(Exception exception) yazmak yerine catch blogunda hakikaten ne tur bir hata oldugunu
            //cozmemiz gerkiyor...Biz exception ile ilgili calisirken de aslinda bunu ogrenmistik..
            //Iste Exception altindaki hata nesnelerinin siniflarindirilmasinin sebebi iste tam olarak da budur
            //Bundan dolayi biz ne yapacagiz Business de yeni bir class olustururuz DuplicedProductException adinda
            //bir class olusturyoruz aynen DivideByZeroException gibi
            {
                Console.WriteLine(exception.Message);
               // throw;
            }
        }
    }
}
