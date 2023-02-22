using Application;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IApplication<RegisterProduct> _product;
        public ProductController(IApplication<RegisterProduct> product)
        {
            _product = product;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_product.GetAll());
        }
    }
}
