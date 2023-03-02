using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            HttpResponseMessage response = Servicio.getInstance().PostResponse("api/Auth/Login", resquest);
            var consu = await response.Content.ReadAsStringAsync();
            var loginResponse = JsonConvert.DeserializeObject<Login>(consu);

            if (response != null && response.IsSuccessStatusCode)
            {
                return StatusCode(StatusCodes.Status200OK, response.Content);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest);

            }
        }
    }

}
