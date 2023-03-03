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
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] Login resquest)
        {
            //para enviar un objeto en formato JSON y pasarlo en HttpContent
            var json = JsonConvert.SerializeObject(resquest);
            //Se usa el StringContent para crear un contenido a partir de la cadena JSON que se desea enviar en la solicitud PutAsync.
            //El primer parámetro es la cadena que se desea enviar como contenido, el segundo parámetro es el encoding que se desea utilizar
            //para la cadena y el tercer parámetro es el tipo de contenido que se está enviando, aquí se está indicando que se está
            //enviando un contenido de tipo "application/json"
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = Servicio.getInstance().PostResponse("api/Auth/Login", content,"");
            var consu = await response.Content.ReadAsStringAsync();
            var loginResponse = JsonConvert.DeserializeObject<UserLogin>(consu);

            if (response != null && response.IsSuccessStatusCode)
            {
                return StatusCode(StatusCodes.Status200OK, loginResponse);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, loginResponse);

            }
        }
    }

}
