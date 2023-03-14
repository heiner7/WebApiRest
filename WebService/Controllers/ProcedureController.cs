using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebSite.Models;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcedureController : ControllerBase
    {

        [HttpGet]
        [Route("obtenerEvents")]
        public async Task<IActionResult> obtenerEvents()
        {
            HttpResponseMessage response = Servicio.getInstance().GetResponse("api/Procedure/GetEvents");
            //response.EnsureSuccessStatusCode();
            //Leer la respuesta de la consulta de la api de articulo
            var consuTeam = await response.Content.ReadAsStringAsync();
            //Se usa para convertir esa cadena JSON en una lista de objetos "Articulo".
            //articulos = JsonConvert.DeserializeObject<List<Product>>(consuArticulos);
            if (response != null && response.IsSuccessStatusCode)
            {
                return StatusCode(StatusCodes.Status200OK, consuTeam);
            }

            return StatusCode(StatusCodes.Status204NoContent, consuTeam);

        }

    }
}
