using Application;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Webapi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ProcedureController : ControllerBase
    {
        IApplication<DataEvent> _data;
        public ProcedureController(IApplication<DataEvent> data)
        {
            _data = data;
        }

        //indica que el método de acción puede devolver una respuesta HTTP con el código de estado 200OK.
        [ProducesResponseType(typeof(DataEvent), StatusCodes.Status200OK)]
        //indica que el método de acción puede devolver una respuesta HTTP con el código de estado 204NoContent.
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        [Route("Procedure/GetEvents")]
        public IActionResult GetDataEvents()
        {
            return _data.GetProcedure().Count > 0 ? Ok(_data.GetProcedure()) : NoContent();
        }
    }
}
