using Business.Abstract;
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

        [HttpGet("getall")]
      //  [Authorize(Roles ="Product.GetAll")]//Microsoft.AspNetCore.Authorization
        //Sadece Authorize yazarsak o zaman bu demektir ki kullanıcının bu kaynağa erişmesi icin
        //sadece elinde token olmasi yeterli..

        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getproductid")]
        //https://localhost:44367/api/products/getproductid?productId=2
     //   [Authorize]//Eger Postman Header kisminda Bearer token yazmasak 401 UnAuthorized hatasi aliriz..
        public IActionResult Get(int productId)
        {
            var result = _productService.Get(productId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("productDetailDto")]

        public IActionResult ProductDetailDto()
        {
            var result = _productService.GetProductDtos();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getproductsbycategory")]
        public IActionResult GetProductsByCategory(int categoryId)
        
        {
            var result = _productService.GetAllByCategory(categoryId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
         
            var result = _productService.Add(product);
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
