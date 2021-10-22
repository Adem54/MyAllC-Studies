using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
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
        public IActionResult GetAll()//https://localhost:44314/api/products/getall
        {
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]

        public IActionResult GetById(int id)//https://localhost:44314/api/products/getbyid?id=1
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallbycategoryid")]

        public IActionResult GetAllByCategoryId(int id)
        {
            var result = _productService.GetAllByCategoryId(id);//https://localhost:44314/api/products/getallbycategoryid?id=2
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallbyunitprice")]
        public IActionResult GetAllByUnitPrice(decimal min, decimal max)
            //https://localhost:44314/api/products/getallbyunitprice?min=20&max=50
        {
            var result = _productService.GetAllByUnitPrice(min, max);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("productdetaildto")]

        public IActionResult ProductDetailDto()//https://localhost:44314/api/products/productdetaildto
        {
            var result = _productService.GetProductDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)//https://localhost:44314/api/products/add
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Product product)//https://localhost:44314/api/products/update
        {
            var result = _productService.Update(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpDelete]
        public IActionResult Delete(Product product)//https://localhost:44314/api/products/
        {
            var result = _productService.Delete(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
