using System;
using System.Collections.Generic;

namespace Ctor6Important
{
    class Program
    {
        static void Main(string[] args)
        {
            DataAccess1 dataAccess = new DataAccess1();

            var result = dataAccess.GetAll();//Biz bunu yaptigimiz anda gelen veri yani result degiskenine
            //atadigimiz veri Result<T> generic class inin new lenmis halidir dolayisi ile biz artik 
            //result degiskeni uzerinden Result<T> generiginin propertieslerine ulasabiliriz
            //Ki zaten biz Result<T> generiginde propertieslere constructor daki parametreleri atayarak
            //Result<T> generik class i new lenirken parantezde verilen verileri alabilmemizi sagladik!!!!!


            Console.WriteLine(result.Message);
            Console.ReadLine();
        }
    }

   
    public class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
    }

    public class DataAccess1
    {
        List<Product> _products;

        public DataAccess1()
        {
            _products = new List<Product>
         {
             new Product(){ProductId=1, CategoryId=1, ProductName="Bardak",UnitPrice=5, UnitsInStock=14},
             new Product(){ProductId=2, CategoryId=1, ProductName="Tabak",UnitPrice=7, UnitsInStock=9},
             new Product(){ProductId=3, CategoryId=2, ProductName="Ekran",UnitPrice=50, UnitsInStock=17},
             new Product(){ProductId=4, CategoryId=2, ProductName="Klavye",UnitPrice=25, UnitsInStock=11},
             new Product(){ProductId=5, CategoryId=2, ProductName="Mause",UnitPrice=35, UnitsInStock=24}
         };

        }

        //Zaten List<Product> turunde donen bir methoda diyoruz ki sen bu turu artik yeni bir generic class in
        //icerisine alarak o generic class turunde dondurmesini sagliyorsun ve GetAll  ile donen veriyi de
        //o generic class icersinde properties olusturup tabi tur burda generic olunca isler dahada kolaylasiyor
        //ve o properties e constructor a verilen data yi da atayinca arttik Result<T> new lenirken 
        //parametrelerden data yerine zaten products listesini yaziyoruz ve ekstra mesaj vs gibi donmek istedigimiz
        //verileri de donuyoruz..... Yani burda zaten bir tip ile donen bir methodu generic class icerisine alip 
        //o generic class turunde bir veri olarak donmesini saglayarak GetAll ile normalde donen veri 
        // dataAccess.GetAll() yazdigimiz anda return new Result<List<Product>>(_products, "Veri listelendi", true);
        //Result generigi new lendigi icin yani onu new lemis oluyoruz o zaman biz dataAccess.GetAll. diye
        //devam edersek eger o zaman Result<T> generigindeki properties lere ulasiriiz ve zaten o propertieslere
        //de deger olarak new lerken parantezde ne verdi isek onlar gelir!!!!!
        public Result<List<Product>> GetAll()
        {
            return new Result<List<Product>>(_products, "Veri listelendi", true);
        }

        public class Result<T>
        {
            public Result(T data,string message,bool success)
            {
                Data = data;
                Message = message;
                Success = success;

            }
        
            public T Data{ get;}
            public string Message { get; set; }
            public bool Success { get; set; }
        }
        
    } 
}
