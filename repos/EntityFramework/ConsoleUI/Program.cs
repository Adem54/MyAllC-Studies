using NortwindEfCodeFirst.Context;
using NortwindEfCodeFirst.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
namespace NortwindEfCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            //EntityframeworkCodeFirst ile veritabani ve Tablolari olusturma
            //   EntityframeworkCodeFirst();
            //EntityFrameworkCodeFirst ile Customer ekleme
            //  EntityFrameworkCodeFirstAdd();
            //EntityframeworkCodeFirst ile Musteriye Siparis Ekleme
            //  EntityFrameworkCodeFirstSiparisEkleme();

            //  EntityframeworkSiparisleriSilme();

            //   EfCodeFirstUpdate();
            //IQueryable i biz veritabaninda buyuk datalar cekmek icin kullaniriz..
            //Ama daha sonra bunu biz liste turunde dondurmek istersek de sonuna ToList yapariz
            // IQueryable<Customer> result
            // List<Customer> result
            //IQueryable olarak da dondurebilirim...IEnumerable i implement eden bir interface yani 
            //aslinda bir IEnumerable ama IEnumerable dah performans olarak daha kullanislidir

            //var result = (from c in context.Customers
            //              select c.City).ToList();//Boyle dersek bir stirng dizisi gibi
            //                                      //geliyor
            //      AnonimNesneCagirma(); 
            //Anonim bir tip cagiriyoruz ve calisma aninda olusturulan bir tip oluyor

            // EfCodeFirstDTO();
            // EfCodeFirstWhereSorgusu();
            //  EfCodeFirstUlkeyeGoreGruplama();

            // EfCodeFirstUlkeSehirGruplandirma();
            //  EfCodeFirstUlkeSehirAdetAnonimTipeAtama();
            // EfCodeFirstOrderBy();
            // EfCodeFirstJoinAnonim();
            //  EfCodeFirstJoinWith2Colons();
            //  EfCodeFirstJoinLeft();
            //     EfCodeFirstSengleRowQuery();
            // EfCodeFirstGroupBy();
            // EfCodeFirstListByCustomersOrder();
           // EfCodeFirstListByCustomerDetailsOrder();
            Console.ReadLine();

            static void EfCodeFirstJoinLeft()
            {

                //LEFT JOIN YAPMA!!!!
                //Left join yapisi-elimizde 2 tablo var sol da mesela musteri tablosu, sagda ise siparis tablosu var ama musterilerden bazilarinin
                //siparisi var ama bazilarinin siparisi yok mesela ve biz siparisi olan musterileri zaten normal join la alabiliyoruz ama ya musterinin
                //siparisi yoksa ve biz siparisi olmayan musterilere ozel bir kampanya planlarsak iste o zaman nasil bir sorgu yazmamiz gerekiyor
                //O zaman sol da yani customer tablosunda var olan ama sagda yani order tablosunda olmayan diye soruyu iste left-join ile yapacagiz...
                //LEFT JOIN=>SOLDA OLUP SAGDA OLMAYAN
                //Customer ve Order tablosunu join ile birlestir sonra da where kosulu ile Order id si null olan bos olani getir derse tablonun birles
                //mis halini OrderId karsiligi null olanlari secip getirir....
                using (NorthwindContext context = new NorthwindContext())
                {
                    var result = from c in context.Customers
                                 join o in context.Orders
                                on c.CustomerID equals o.CustomerID into temp
                                 from co in temp.DefaultIfEmpty()//Musterinin kayit karsiligi yok ise onu bos birsekilde getir
                                 where temp.Count() == 0//grup icinde hicbir eleman yoksa , karsiligi yoksa
                                 select new { c.CustomerID, c.ContactName, c.CompanyName, temp };
                    foreach (var item in result)
                    {
                        Console.WriteLine("{0},{1},{2}", item.CustomerID, item.ContactName, item.CompanyName);

                    }
                    Console.WriteLine("{0} adet kayit vardir", result.Count());
                }
            }
        }

        private static void EfCodeFirstListByCustomerDetailsOrder()
        {
            using (var context = new NorthwindContext())
            {

                var result = context.Customers.Where(c => c.CustomerID == "ANATR").Include("Orders");

                foreach (var item in result)
                {
                    Console.WriteLine(item.ContactName + " |" + item.Orders.Count);
                }
            }
        }

        private static void EfCodeFirstListByCustomersOrder()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //var result = context.Customers;
                //foreach (var item in result)
                //{
                //    Console.WriteLine(item.Orders.Count);
                //}
                //Burda entityframework performans kaybi olmamasi icin tum siparsleri getirmiyor bu olaya Lazy Loading diyoruz
                //BU DURUMU COZEBILMEK ICIN...gelmesini istedigimiz proper yi include methodunun icerisine yazarak belirtiriz
                //BU SEKILDE CALISMAYA DA EAGER LOADING DIYORUZ...
                var result = context.Customers.Include("Orders");
                foreach (var item in result)
                {
                    Console.WriteLine(item.ContactName + " |" + item.Orders.Count);
                }
            }
        }

        private static void EfCodeFirstGroupBy()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = context.Customers.Where(c => c.Country == "UK" && c.City == "London").
                    OrderBy(c => c.ContactName).GroupBy(customer => customer.ContactName).
                    Select(c => new { c.Key });

                foreach (var item in result)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }

        private static void EfCodeFirstSengleRowQuery()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = context.Customers.Where(c => c.Country == "UK" && c.City == "London").
                    OrderBy(c => c.ContactName).
                    Select(c => new { c.CustomerID, c.ContactName });

                foreach (var item in result)
                {
                    Console.WriteLine(item.CustomerID + "|" + item.ContactName);
                }
            }
        }

        private static void EfCodeFirstJoinWith2Colons()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = (from c in context.Customers
                              join o in context.Orders
                              on new { c.CustomerID, Sehir = c.City }
                              equals
                              new { o.CustomerID, Sehir = o.ShipCity }
                              select new { c.CustomerID, c.City, c.ContactName, o.OrderDate, o.ShipCity }).ToList();
                foreach (var item in result)
                {
                    Console.WriteLine(item.ContactName + " | " + " | " + "City: " + item.City + "Ship City: " + item.ShipCity);
                }
            }
        }

        private static void EfCodeFirstJoinAnonim()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = (from c in context.Customers
                              join o in context.Orders
                              on c.CustomerID equals o.CustomerID
                              select new { c.ContactName, c.CompanyName, o.OrderDate, o.ShipCity }).ToList();
                foreach (var item in result)
                {
                    Console.WriteLine(item.ContactName + " | " + item.OrderDate + " | " + item.CompanyName + " | " + item.ShipCity);
                }
            }
        }

        private static void EfCodeFirstOrderBy()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = (from c in context.Customers
                              orderby c.Country.Length descending, c.ContactName ascending  //ContactName i default olarak A dan Z ye siralar
                              select c
                                 ).ToList();
                foreach (var item in result)
                {
                    Console.WriteLine("{0},{1}", item.Country, item.ContactName);
                }
            }
        }

        private static void EfCodeFirstUlkeSehirAdetAnonimTipeAtama()
        {
            using (NorthwindContext context = new NorthwindContext())
            {

                var result = (from c in context.Customers
                                  //Yine anonim bir nesne olarak cagiriyoruz istersek tabi bu anonim nesneyi
                                  //class olarak olusturup yani DTO olusturup ona da atayabilriz.
                              group c by new { c.Country, c.City }
                             into g
                              select new { Sehir = g.Key.City, Ulke = g.Key.Country, Adet = g.Count() }
                              );
                foreach (var item in result)
                {//Sira ile o ulke ve sehirden kacar adet var onu gruplar
                    Console.WriteLine("Ulke: {0}, Sehir: {1}, Adet: {2}", item.Ulke, item.Sehir, item.Adet);
                }
            }
        }

        private static void EfCodeFirstUlkeSehirGruplandirma()
        {
            using (NorthwindContext context = new NorthwindContext())
            {

                var result = (from c in context.Customers
                                  //Yine anonim bir nesne olarak cagiriyoruz istersek tabi bu anonim nesneyi
                                  //class olarak olusturup yani DTO olusturup ona da atayabilriz.
                              group c by new { c.Country, c.City }
                             into g
                              select g
                              );//Gruplama tip seklinde degilde anonim olarak olusturuluyor
                //Gruplama ifadesini yaptigimiz her bir degere key diyoruz
                //Her ulkeyi tek tek grupladigi icin bir kere getirecek!!
                foreach (var item in result)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }

        private static void EfCodeFirstUlkeyeGoreGruplama()
        {
            using (NorthwindContext context = new NorthwindContext())
            {

                var result = (from c in context.Customers//Musterileri musterinin ulke sine grupladik
                                                         //ve bu gruplama bilgissini , her bir grubu g isimli tipe atadik, g bizim her
                                                         //bir grubumuzu teker teker cekiyor
                              group c by c.Country//c.Country grubun key degeridir
                             into g
                              select g
                              );//Gruplama tip seklinde degilde anonim olarak olusturuluyor
                //Gruplama ifadesini yaptigimiz her bir degere key diyoruz
                //Her ulkeyi tek tek grupladigi icin bir kere getirecek!!
                foreach (var item in result)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }

        private static void EfCodeFirstWhereSorgusu()
        {
            using (NorthwindContext context = new NorthwindContext())
            {

                var result = (from c in context.Customers
                              where c.Country == "UK" && c.City == "London"
                              select c
                              );
                foreach (var customer in result)
                {
                    Console.WriteLine(customer.ContactName);
                }
            }
        }

        private static void EfCodeFirstDTO()
        {
            using (NorthwindContext context = new NorthwindContext())
            {

                var result = (from c in context.Customers
                              select new Musteri
                              {
                                  Sehir = c.City,
                                  Ulke = c.Country,
                                  Sirket = c.CompanyName
                              });
                foreach (var customer in result)
                {
                    Console.WriteLine(customer.Sirket);
                }
            }
        }

        private static void AnonimNesneCagirma()
        {
            using (NorthwindContext context = new NorthwindContext())
            {

                var result = (from c in context.Customers
                              select new { c.City, c.Country, c.CompanyName });
                foreach (var customer in result)
                {
                    Console.WriteLine(customer.CompanyName);
                }
            }
        }

        private static void EfCodeFirstUpdate()
        {
            EfFirsCodeUpdateCustomer();
        }

        private static void EfFirsCodeUpdateCustomer()
        {
            //Simdi de bir musterinin bilgilerini guncelleyelim
            using (var context = new NorthwindContext())
            {
                var customer = context.Customers.Find("Jonas");
                //Bunu yaptigimiz zaman customer nesnesi iste gercekten veritabaninda tabloda var olan
                //customer orneklerinden bir tanesi dir iste ORM budur bize bunu saglar
                customer.ContactName = "Adem";
                customer.City = "Arendal";
                customer.Country = "Sveden";

                context.SaveChanges();
            };
        }

        private static void EntityframeworkSiparisleriSilme()
        {
            //Bir de silme islemi yapalim ama musteriyi silemeyiz cunku Orders tablosu icinde
            //CustomerId foreign key olarak var  oldugu icin , silemeyiz foreign key hatasi aliriz..
            //Onun icin musterinin siparislerini sileriz...
            using (NorthwindContext context = new NorthwindContext())
            {
                //Order i id sinden yakalariz once...
                var order = context.Orders.Find(1);
                context.Orders.Remove(order);
                context.SaveChanges();
                //BURDA SUNA DIKKAT!!!REFERANS TIPLERI IYI BILMEK COK ONEMLI 
                //   Order order2 = new Order { OrderID = 1 };//Bunu verirsek bizim tablomuzdaki
                //orderimizi silmeyecektir cunku biz burda order i new ledik ve yeni bir 
                //instance olustu ve gidip yeni bir referans adresi olusturdu heap bellekte 
                //degisken ismini stack da tutuyor..dolyisi ile tum degerleri id dahil ayni olsa
                //bile sen new ledigin anda o artik baska birsey, baska bir instance oluyor...
            }
        }

        private static void EntityFrameworkCodeFirstSiparisEkleme()
        {
            //Simdide musteriye bir tane siparis girelim
            using (NorthwindContext context = new NorthwindContext())
            {
                //Burda biz Find ile musterinin id sini vererek o musteri yi buluyoruz...
                Customer customer = context.Customers.Find("Jonas");
                customer.Orders.Add(new Order
                {
                    OrderID = 1,
                    OrderDate = DateTime.Now,
                    ShipCity = "Stavenger",
                    ShipCountry = "Norway"
                });

                context.SaveChanges();
            }
        }

        private static void EntityFrameworkCodeFirstAdd()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //Bu sekilde biz entityframeworkun olusturdugu veritabaninmiza veri ekleyebiliriz...
                context.Customers.Add(new Entities.Customer
                {
                    ContactName = "Jonas",
                    CustomerID = "Jonas",
                    CompanyName = "Ciar",
                    Country = "NOrway",
                    City = "Skien",
           });

                //Unitofworks design pattern i cercevesinde bu islem yapilir cunku, buraya kadar
                //olan islemlerde bir hata cikarsa geri alabilmek iicn en son kaydediliir...
                //UNITOFWORK TRANSACTION CALISMASINI YERINE GETIRMEK ICIN YAPILMIS BIR CALISMADIR 
                //ASLINDA
                context.SaveChanges();
            }
        }

        private static void EntityframeworkCodeFirst()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                foreach (var item in context.Customers)
                {
                    Console.WriteLine("ContactName  " + item.ContactName);
                }
            }
        }
    }

    class Musteri
    {

        public string Sirket { get; set; }
        public string Sehir { get; set; }
        public string Ulke { get; set; }
        public int Adet { get; set; }
    }
}
