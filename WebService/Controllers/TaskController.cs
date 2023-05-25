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
    public class TaskController : ControllerBase
    {
        [HttpGet]
        [Route("obtenerTarea/{id:int}")]
        public async Task<IActionResult> obtenerTarea(int id)
        {                      
             HttpResponseMessage response = Servicio.getInstance().GetResponse("api/Tarea/ObtenerTarea/"+id);
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

        [HttpGet]
        [Route("obtenerEstadoTarea/{estado:bool}")]
        public async Task<IActionResult> obtenerEstadoTarea(bool estado)
        {
            HttpResponseMessage response = Servicio.getInstance().GetResponse("api/Tarea/ObtenerEstadoTarea/"+estado);
            //response.EnsureSuccessStatusCode();
            //Leer la respuesta de la consulta de la api de articulo
            var consuTarea = await response.Content.ReadAsStringAsync();
            //Se usa para convertir esa cadena JSON en una lista de objetos "Articulo".
            //articulos = JsonConvert.DeserializeObject<List<Product>>(consuArticulos);
            if (response != null && response.IsSuccessStatusCode)
            {
                return StatusCode(StatusCodes.Status200OK, consuTarea);
            }

            return StatusCode(StatusCodes.Status204NoContent, consuTarea);

        }

        [HttpPost]
        [Route("guardarTarea")]
        public IActionResult guardarTarea([FromBody] Tarea resquest, [FromHeader(Name = "Authorization")] string authorizationHeader)
        {
            //para enviar un objeto en formato JSON y pasarlo en HttpContent
            var json = JsonConvert.SerializeObject(resquest);
            //Se usa el StringContent para crear un contenido a partir de la cadena JSON que se desea enviar en la solicitud PutAsync.
            //El primer parámetro es la cadena que se desea enviar como contenido, el segundo parámetro es el encoding que se desea utilizar
            //para la cadena y el tercer parámetro es el tipo de contenido que se está enviando, aquí se está indicando que se está
            //enviando un contenido de tipo "application/json"
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = Servicio.getInstance().PostResponse("api/Tarea/GuardarTarea", content, authorizationHeader);
            
            if (response != null && response.IsSuccessStatusCode)
            {
                return StatusCode(StatusCodes.Status200OK, "ok");
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized);
            }        
        }

        [HttpPut]
        [Route("editarTarea")]
        public IActionResult editarTarea([FromBody] Tarea resquest, [FromHeader(Name = "Authorization")] string authorizationHeader
)
        {
            //para enviar un objeto en formato JSON y pasarlo en HttpContent
            var json = JsonConvert.SerializeObject(resquest);
            //Se usa el StringContent para crear un contenido a partir de la cadena JSON que se desea enviar en la solicitud PutAsync.
            //El primer parámetro es la cadena que se desea enviar como contenido, el segundo parámetro es el encoding que se desea utilizar
            //para la cadena y el tercer parámetro es el tipo de contenido que se está enviando, aquí se está indicando que se está
            //enviando un contenido de tipo "application/json"
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = Servicio.getInstance().PutResponse("api/Tarea/EditarTarea", content, authorizationHeader);

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
        [Route("eliminarTarea/{id:int}")]
        public IActionResult eliminarTarea(int id, [FromHeader(Name = "Authorization")] string authorizationHeader)
        {           
            HttpResponseMessage response = Servicio.getInstance().DeleteResponse("api/Tarea/eliminarTarea/" + id, authorizationHeader);

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
