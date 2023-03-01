using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebService.Model;
using WebSite.Models;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        [HttpGet]
        [Route("obtenerPlayer")]
        public async Task<IActionResult> obtenerPlayer()
        {                      
             HttpResponseMessage response = Servicio.getInstance().GetResponse("api/Player/Get");
             //response.EnsureSuccessStatusCode();
             //Leer la respuesta de la consulta de la api de articulo
              var consuPlayer = await response.Content.ReadAsStringAsync();
             //Se usa para convertir esa cadena JSON en una lista de objetos "Articulo".
              //articulos = JsonConvert.DeserializeObject<List<Product>>(consuArticulos);
              if (response != null && response.IsSuccessStatusCode)
              {
                 return StatusCode(StatusCodes.Status200OK, consuPlayer);
              }

            return StatusCode(StatusCodes.Status204NoContent, consuPlayer);

        }

        [HttpPost]
        [Route("savePlayer")]
        public IActionResult savePlayer([FromBody] Player resquest)
        {     
            HttpResponseMessage response = Servicio.getInstance().PostResponse("api/Player/SavePlayer", resquest);
            
            if (response != null && response.IsSuccessStatusCode)
            {
                return StatusCode(StatusCodes.Status200OK, "ok");
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }        

        }

        [HttpPut]
        [Route("editPlayer")]
        public IActionResult editPlayer([FromBody] Player resquest)
        {

            HttpResponseMessage response = Servicio.getInstance().PostResponse("api/Player/SavePlayer", resquest);

            if (response != null && response.IsSuccessStatusCode)
            {
                return StatusCode(StatusCodes.Status200OK, "ok");
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

        }
    }

}
