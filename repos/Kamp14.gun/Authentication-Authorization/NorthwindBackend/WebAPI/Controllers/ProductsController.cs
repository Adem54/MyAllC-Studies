using Business.Abstract;
using Core.Extensions;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        //Biz burda IProductService kullandik,yani soyut bir sinif kullandik ve bu interface bircok
        //somut sinifin referansini tutabilir ve controller bunun hangi somut sinifi tuttugunu 
        //bilmiyor..
        //Ayni sekilde ProductManager da da bir IProductDal interface uzerinden dependency-
        //injection olayi yapilmis ve controller onun da somut sinifinin kim oldugunu bilmiyor
        //Bizim neye ihtiyacimiz var dependency injection konfigurasyonu yapmamiz gerekiyor
        //Biz bu konfigurasyonu normalde WebAPI altinda Startup.cs de ConfigureService icinde
        //AddSingleton ile yapabilirz ama o zaman da buraya bagimli olmus oluruz.
        //Biz uygulamamizi api degilde MVC uzernde yapmak istersek bu serferde
        //bir de orda bu konfigurasyonu yapmamiz gerekir ve uygulamamiz API ye bagimli olur
        //Bundan dolayi dependency yonetimini Autofac ile business tarafinda ayaga kaldiracagiz
        //Startup.cs bir IoC container di bizim icin ama biz Autofac ile yapacaktik o isi
        //Autofac bize IoS inversion of kontroll alt yapisini sunuyor bize
        //Business katmaninda Autofac paketini kurariz ilk once

       
            [HttpGet("getall")]//https://localhost:44333/api/products/getall
        // [Authorize]//bu authorize Microsoft.AspNetCore.Authorization; burdan geliyor
            //Sadece authorize yazarsak bu demektir ki buraya erismesi icin, yani bu operasyonu
            //calistirabilmesi icin kisinin sadece Authenticate olmasi yeterli
            //yani sisteme giris yaptiginda elinde bir token olmasi yeterli bizim icin demek
            //
        public IActionResult GetAll()
            {
                var result = _productService.GetAll();
                if (result.Success)
                {
                    return Ok(result.Data);
                }
                return BadRequest(result.Message);
        }

        [HttpGet("getbycategoryid")]//https://localhost:44333/api/products/getbycategoryid?categoryId=2
      //  [Authorize(Roles ="Product.GetByCategory")]
    
        // [Authorize(Roles ="Admin")] bu sekilde daha basit sistemlerde Admin ise buraya erissin
        // diyebiliriz ama biz biraz daha profesyonel gideceksek o zaman
        //[Authorize(Roles ="Product.GetByCategory")] diyerek kategoriye gore urun listeleyebilme
        // yetkisi varsa erissin kategoriye gore urunlere diyoruz...Daha genis sistem
        //Bu arada illa belli bir sekilde yapilacak die bir kural yok role bazli yapilar
        //projenin ihtiyacina gore sekillenir
        //Adim,editor,moderator,user gibi roller de yazabiliriz ihtiyaca gore
       
        public IActionResult GetByCategoryId(int categoryId)
            {
            
                var result = _productService.GetByAllCategory(categoryId);
                if (result.Success)
                {
                    return Ok(result.Data);
                }
                return BadRequest(result.Message);
            }

        [HttpGet("getbyid")]
        public IActionResult Get(int productId)
        {
            var result = _productService.Get(productId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("Add")]


        public IActionResult Add(Product product)
        {
            //ClaimPrincipal a yazdigimiz Extension a Nasil Erisiriz Test Ediyoruz!!!!!
            //User bir  ClaimsPrincipal dir dolayisi ile biz onu extend ettigimiz icin User.ClaimRoles
            //diye yazarak Claim rollerine erisecegiz artikk..
            //ClaimRoles u da biz Core altinda Extensions da yazmistik ordan gelir
            //Bu sekilde User a ait ClaimRolleri getirir...
            //    User.ClaimRoles();//Extension olanlar asagi dogru ok isareti ile geliyor ve bu projede
            //yazilsmi bir extension dir...
            //Simdi gidip User.ClaimRoles() e Business de erismeye calisacagiz...
            
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(Product product)
        {
            
            var result = _productService.Update(product);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
       
        [HttpPost("delete")]

        public IActionResult Delete(Product product)
        {
            var result = _productService.Delete(product);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("transaction")]

        public IActionResult TransactionTest(Product product)
        {
            var result = _productService.TransactionalOperation(product);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

    }
}
//Eger bir yerde bir tur teknoloji kullaniyorsak orda klasorleme yapmaliyiz ki
//yarin oburgun o teknolojiyi degistirmemiz gerekirse ona bagimli kalmamis oluruz