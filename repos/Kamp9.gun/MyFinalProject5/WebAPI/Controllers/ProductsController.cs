using Business.Abstract;
using Entities.Concrete;
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

        public IActionResult GetAll()//https://localhost:44318/api/products/getall
        {
            var result = _productService.GetProducts();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        } 

        [HttpGet("getbyid")]

        public IActionResult GetById(int id)//https://localhost:44318/api/products/getbyid?id=1
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
               return BadRequest(result);
        }

        [HttpGet("getbyidcategory")]
        
        public IActionResult GetByIdCategory(int id)//https://localhost:44318/api/products/getbyidcategory?id=2
        {
            var result = _productService.GetByIdCategory(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyunitprice")]
        public IActionResult GetByUnitPrice(decimal min, decimal max)//https://localhost:44318/api/products/getbyunitprice?min=20&max=30
        {
            var result = _productService.GetByUnitPrice(min, max);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getproductdto")]
        public IActionResult GetProductDto()//https://localhost:44318/api/products/getproductdto
        {
            var result = _productService.GetPDetailsDto();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }       

        [HttpPost("add")]
        public IActionResult Add(Product product)//https://localhost:44318/api/products/add
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
    }
}
