using Entities;
using Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace WebServices.Controllers
{
    
    [Route("api/")]
    [ApiController]
    public class TareaTeamController : ControllerBase
    {
        IApplication<Tarea> _tarea;
        public TareaTeamController(IApplication<Tarea> tarea)
        {
            _tarea = tarea;
        }

        //indica que el método de acción puede devolver una respuesta HTTP con el código de estado 200OK.
        [ProducesResponseType(typeof(Tarea), StatusCodes.Status200OK)]
        //indica que el método de acción puede devolver una respuesta HTTP con el código de estado 204NoContent.
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        [Route("Tarea/ObtenerTarea/{id:int}")]
        public IActionResult Get(int id)
        {
            return _tarea.GetAll(id).Count > 0 ? Ok(_tarea.GetAll(id)) : NoContent();
        }

        //indica que el método de acción puede devolver una respuesta HTTP con el código de estado 200OK.
        [ProducesResponseType(typeof(Tarea), StatusCodes.Status200OK)]
        //indica que el método de acción puede devolver una respuesta HTTP con el código de estado 204NoContent.
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        [Route("Tarea/ObtenerEstadoTarea/{estado:bool}")]
        public IActionResult ObtenerEstado(bool estado)
        {
            return _tarea.GetAll(0).Count > 0 ? Ok(_tarea.GetByState(estado)) : NoContent();
        }

        //Con esto se seguriza el controlador
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //indica que el método de acción puede devolver una respuesta HTTP con el código de estado 200OK.
        [ProducesResponseType(typeof(Tarea), StatusCodes.Status200OK)]
        //indica que el método de acción puede devolver una respuesta HTTP con el código de estado 400BadRequest.
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        [Route("Tarea/GuardarTarea")]
        public IActionResult Save(TareaDTO dto)
        {
            var f = new Tarea()
            {
                Titulo = dto.Titulo,
                Descripción = dto.Descripción,
                FechaRegistro = dto.FechaRegistro,
                TareaCompleta = dto.TareaCompleta,
                FechaTerminada = dto.FechaTerminada
            };

            return Ok(_tarea.Save(f));           
        }

        //Con esto se seguriza el controlador
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //indica que el método de acción puede devolver una respuesta HTTP con el código de estado 200OK.
        [ProducesResponseType(typeof(Tarea), StatusCodes.Status200OK)]
        //indica que el método de acción puede devolver una respuesta HTTP con el código de estado 400BadRequest.
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut]
        [Route("Tarea/EditarTarea")]
        //El parametro [FromBody] para indicar que se espera recibir un objeto ExampleObject en el cuerpo del mensaje HTTP
        public IActionResult editarTarea([FromBody] TareaDTO dto)
        {
            try
            {
                var f = new Tarea()
                {
                    Id = dto.Id,
                    Titulo = dto.Titulo,
                    Descripción = dto.Descripción,
                    FechaRegistro = dto.FechaRegistro,
                    TareaCompleta = dto.TareaCompleta,
                    FechaTerminada = dto.FechaTerminada
                };

                return Ok(_tarea.Save(f));
            }
            catch (Exception)
            {
                return Unauthorized();
            }

        }

        //Con esto se seguriza el controlador
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //indica que el método de acción puede devolver una respuesta HTTP con el código de estado 200OK.
        [ProducesResponseType(StatusCodes.Status200OK)]
        //indica que el método de acción puede devolver una respuesta HTTP con el código de estado 400BadRequest.
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpDelete]
        [Route("Tarea/eliminarTarea/{id:int}")]

        public IActionResult eliminarTarea(int id)
        {
            try
            {
                _tarea.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return Unauthorized();
            }

        }

    }
}
