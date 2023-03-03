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
        public IActionResult savePlayer([FromBody] Player resquest, [FromHeader(Name = "Authorization")] string authorizationHeader)
        {
            //para enviar un objeto en formato JSON y pasarlo en HttpContent
            var json = JsonConvert.SerializeObject(resquest);
            //Se usa el StringContent para crear un contenido a partir de la cadena JSON que se desea enviar en la solicitud PutAsync.
            //El primer parámetro es la cadena que se desea enviar como contenido, el segundo parámetro es el encoding que se desea utilizar
            //para la cadena y el tercer parámetro es el tipo de contenido que se está enviando, aquí se está indicando que se está
            //enviando un contenido de tipo "application/json"
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = Servicio.getInstance().PostResponse("api/Player/SavePlayer", content, authorizationHeader);
            
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
        public IActionResult editPlayer([FromBody] Player resquest, [FromHeader(Name = "Authorization")] string authorizationHeader
)
        {
            //para enviar un objeto en formato JSON y pasarlo en HttpContent
            var json = JsonConvert.SerializeObject(resquest);
            //Se usa el StringContent para crear un contenido a partir de la cadena JSON que se desea enviar en la solicitud PutAsync.
            //El primer parámetro es la cadena que se desea enviar como contenido, el segundo parámetro es el encoding que se desea utilizar
            //para la cadena y el tercer parámetro es el tipo de contenido que se está enviando, aquí se está indicando que se está
            //enviando un contenido de tipo "application/json"
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = Servicio.getInstance().PutResponse("api/Player/EditPlayer", content, authorizationHeader);

            if (response != null && response.IsSuccessStatusCode)
            {
                return StatusCode(StatusCodes.Status200OK, "ok");
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized);
            }
        }

        [HttpDelete]
        [Route("removePlayer/{id:int}")]
        public IActionResult removePlayer(int id)
        {           
            HttpResponseMessage response = Servicio.getInstance().DeleteResponse("api/Player/removePlayer/"+id);

            if (response != null && response.IsSuccessStatusCode)
            {
                return StatusCode(StatusCodes.Status200OK, "ok");
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized);
            }
        }

    }

}
