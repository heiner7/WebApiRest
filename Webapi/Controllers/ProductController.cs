using Application;
using Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapi.DTOs;

namespace Webapi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IApplication<RegisterProduct> _product;
        public ProductController(IApplication<RegisterProduct> product)
        {
            _product = product;
        }

        //Con esto se seguriza el controlador
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = ("Heiner"))]
        //indica que el método de acción puede devolver una respuesta HTTP con el código de estado 200OK.
        [ProducesResponseType(typeof(RegisterProduct), StatusCodes.Status200OK)]
        //indica que el método de acción puede devolver una respuesta HTTP con el código de estado 204NoContent.
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        [Route("Product/Get")]
        public IActionResult Get()
        {
            //proporciona un mensaje que indique que la solicitud se ha procesado correctamente,
            //mediante el uso de un encabezado HTTP personalizado
            Response.Headers.Add("Message", "No hay datos disponible");

            return _product.GetAll().Count > 0 ? Ok(_product.GetAll()) : NoContent();         
        }
    }
}
