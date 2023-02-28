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
using WebServices;

namespace Webapi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        IApplication<RegisterPlayer> _player;
        public PlayerController(IApplication<RegisterPlayer> player)
        {
            _player = player;
        }

        //Con esto se seguriza el controlador
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = ("Heiner"))]
        //indica que el método de acción puede devolver una respuesta HTTP con el código de estado 200OK.
        [ProducesResponseType(typeof(RegisterPlayer), StatusCodes.Status200OK)]
        //indica que el método de acción puede devolver una respuesta HTTP con el código de estado 204NoContent.
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        [Route("Player/Get")]
        public IActionResult Get()
        {
            //proporciona un mensaje que indique que la solicitud se ha procesado correctamente,
            //mediante el uso de un encabezado HTTP personalizado
            Response.Headers.Add("Message", "No hay datos disponible");

            return _player.GetAll().Count > 0 ? Ok(_player.GetAll()) : NoContent();         
        }

        //indica que el método de acción puede devolver una respuesta HTTP con el código de estado 200OK.
        [ProducesResponseType(typeof(FootballTeam), StatusCodes.Status200OK)]
        //indica que el método de acción puede devolver una respuesta HTTP con el código de estado 400BadRequest.
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route("Player/SavePlayer")]
        //El parametro [FromBody] para indicar que se espera recibir un objeto ExampleObject en el cuerpo del mensaje HTTP
        public IActionResult Save( PlayerDTO dto)
        {
            var f = new RegisterPlayer()
            {
                Name = dto.Name,
                LastName = dto.LastName,
                Position = dto.Position,
                TeamId = dto.TeamId
            };

            return _player.Save(f) is not null ? Ok(_player.Save(f)) : BadRequest(new ResponseDTO()
            {
                StatusCode = 404,
                StatusMessage = "La solicitud fue incorrecto debido a una sintaxis incorrecta, una falta de " +
                                     "información o un formato incorrecto en la solicitud."
            });
        }

    }
}
