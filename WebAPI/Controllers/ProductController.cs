using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {

        IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
         
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAlll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

          }

        [HttpGet("getById")]
        public IActionResult Get(int id)
        {
            var result = _productService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpGet("getByCategoryId")]
        public IActionResult GetByCategoryId(int categoryId)
        {
            var result = _productService.GetAllByCategoryId(categoryId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpPost("post")]
        public IActionResult Post(Product product)
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

