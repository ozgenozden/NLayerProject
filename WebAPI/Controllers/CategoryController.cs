using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]  
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _categoryService.GetAll  ();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
    }
}

