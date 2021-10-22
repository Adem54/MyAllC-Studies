using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Exception;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.CrossCuttingConcerns.Validation;
using Core.Extensions;
using Core.Utilities;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
      //  IHttpContextAccessor _httpContextAccessor;
        //IHttpContextAccessor ile initialise context e erisebiliyoruz...
        //Ve IHttpContextAccessor u ProductManager a enjekte ederiz context i kullanabilmek icin
        ICategoryService _categoryService;
        public ProductManager(IProductDal productDal, ICategoryService categoryService )
        {
            _productDal = productDal;
            _categoryService = categoryService;
        //    _httpContextAccessor = httpContextAccessor;
            //Biz _httpContextAccessor u dpeendency ile buraya enjekte edince burayi WebBased
            //bir sistem yaptik yani webe bagli yani bu projeyi windows form bazli birprojeye
            //baglamaya kalktigimiz da patlariz o yuzden bundan kurtulmammiz gerekir...
        }
        //Burasi kullanici ile irtibatin kuruldugu yer.Ve burda ornegin herhangi bir hata oldugu
        //zaman bu her turlu hata olabilir bu hata direk kullaniciya yansitiliyor
        //Ama kullanicya yansimadan once biz bunu farkedelim ki hataya gore kullaniciyi 
        //dogru yonlendirebilelim...

        //[ValidationAspect(typeof(ProductValidator))] Amacim boyle birsey yapmak ve bunun
        //Add Operassyonu basladigi anda ValidationAspect ile ProductValidator kullanarak parametrede
        //gecen ProductValidator un ihtiyac duydugu nesne yani Product parametrede git o nesnenin aynisini
        //bul ve onu bu Validator u kullanarak Validate et yani gelecegimiz nokta bu olacak!!!
        //[ValidationAspect(typeof(ProductValidator),Priority=1)]
        //[AuthorizationAspect(typeof(ProductValidator),Priority=2)]

        [ValidationAspect(typeof(ProductValidator), Priority = 1)]
     //   [CacheRemoveAspect(pattern:"IProductService.Get")]
       // [CacheRemoveAspect(pattern: "ICategoryService.Get")]
        //Add operasyonumuz basarili  oldugunda bizim IProductService.Get olan yani ProductManager veya
        //IProductService miz de get ile baslayan operasyonlardan cache de olan varsa onlari silecek
        public IResult Add(Product product)
        {
           // _httpContextAccessor.HttpContext.User.ClaimRoles();
            //Boyle kullanmak istemiyorum ben bunu Aspect ile kullanmak istiyorum 
            //ValidationTool.Validate(new ProductValidator(), product);
          
           IResult result= BusinessRules.Run(CheckIfProductNameExists(product.ProductName),
               CheckIfCategoryIsEnable());
            if (result!=null)
            {
                return result;
            }
          
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

      

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        //Hata durumunda da bu sekilde goruntuleyebiliriz...
        [LogAspect(typeof(FileLogger))]
        public IDataResult<Product> Get(int productId)
        {
            try
            {
                return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId),
              "Urun detayi basari ile getirildi");
            }
            catch (Exception)
            {

                return new ErrorDataResult<Product>("Veri detayi goruntulenemiyor");
            }
        }

       // [ExceptionLogAspect(typeof(FileLogger))]
        [PerformanceAspect(interval:5)]
        public IDataResult<List<Product>> GetAll()
        {
            Thread.Sleep(millisecondsTimeout: 5000);//Baslamadan once 5 saniye beklesin demeek bu
            //Performance testimizi gorebilmek icin buraya boyle birsey yazdik
          
        
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),"Urunler listelendi");
        }

       
        //[SecuredOperation("Product.GetByCategory,Admin")]
        [LogAspect(typeof(DatabaseLogger))]

        [CacheAspect(duration:10)]//1 dakika boyunca cache den gelecek sonrasinda tamamen veritabanindan
        //ve sonra yine cache ye eklenecek
        public IDataResult<List<Product>> GetByAllCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == categoryId),
                "Urunler kategoriye gore listelendi") ;      
           
        }
        

        [TransactionScopeAspect]
        public IResult TransactionalOperation(Product product)
        {
            //Once bir product guncellemeye calisacagiz daha sonra product eklemeye calisacagiz
            //ve Update basarili olsun, Add islemi de basarisiz olacagi zaman Update islemi
            //de veritabanimizda geri alinacak bir senaryo yapacagiz 
            //Amacimiz tamamen Transaction i test etmek...Ne yapildiginin mantiginin onemi yok
          //TransactionScopeAspect tteki invocation dedigi TransactionalOperation icindeki
          //kodlarin tamamidir.. yani Update,Add ve SuccessResult isleminin tamami 
          //TransactionScopeAspect teki invocation dir
            _productDal.Update(product);
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductUpdated);
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }


        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.Get(p => p.ProductName == productName);
            if (result != null)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExist);
            }
            return new SuccessResult();
            //SuccessResult donerse problem yok demektir!   
                                       //Bunu Add icinde soyle kullaniriz eger productName var ise result dondur yani
                                       //bizim methodda yazdigimiz a tutarli bir if yapmamiz lazm orda da , methoddaki mantigi
                                       //orda da surdurduk yani methodun mantigini  orda da koruduk eger dedik productName varsa
                                       //return olarak bu method ne donderiyorsa productName var ise nin sonucunda sende onu donder
                                       //diyoruz...o da nasil oluyor methodun sonucunu bir degiskene ata ve eger productName 
                                       //ile ayni isimde eleman varsa o zaman productName i atadigim degiskeni ver dersek
                                       //o zaman tamam varsa ErrorResult donmustu o doner eger isim yoksa kismi ise zaten 
                                       //o zaman islem yap Add islemini yap demis oluruz...


        }
        //Bir urun eklerken ornegin o urunun kategorisinin veritabanindan kontrol edilmesi..
        private IResult CheckIfCategoryIsEnable()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count < 10)
            {
                return new ErrorResult("Kategori adedi 10 dan kucuktur..");
            }
            return new SuccessResult();
        }
    }
}

//Is kurallari Business tarafinda yazilir.Ara yuz tarafinda yazilmaz cunku bugun arayuz olarak
//bir web arayuz kullanirsin ama yarin oburgun mobil e gecebilirsin..O zaman is kurallarini tekrardan
//bir daha yazmak zorunda kaliriz
//Api bazli yapilar kullaniyoruz api nin icine de yazilmaz...Cunku bu api bir teknolojidir
//Yarin oburgun api den vazgecersek o zaman da is kodlarimiiz orda kaalacaktir

//COKK ONEMLI BILGI...REFERANS TIPLER
//SuccessDataResult=>DataResult u inherit etti
//DataResult=>IDataResult u implement etti
//Sonuc IDataResult hem DataResult un referansini tutar hem de SuccessDataResult un ve ErrorDataResult
//un referansini tutablir ondan dolayi methodlarimiza biz burda tip atadik tip  olarak mesela
//IDataResult u atadik ve artik onu implement etmis nesneler den herhangi biri ile
//return u dondurebiliriz 
//SuccessResult=>Result u inherit ediyor
//Result=>IResult u implmenet ediyor
//IResult hem Result un hem de SuccessResult,ErrorResult un referansini tutabiliyor
//Ondan dolayi Add,Delete,Update methodlarina IResult tipi atamasi yapiliyor ve donus olarak
//da IResult un referansini tuttugu SuccessResult veya ErrorResult donebiliyoruz
