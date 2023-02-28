using Entities;
using Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Webapi.DTOs;

namespace WebServices.Controllers
{
    //Con esto se seguriza el controlador
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles =("Heiner1"))]
    [Route("api/")]
    [ApiController]
    public class FootballTeamController : ControllerBase
    {
        IApplication<FootballTeam> _football;
        public FootballTeamController(IApplication<FootballTeam> football)
        {
            _football = football;
        }

        //indica que el método de acción puede devolver una respuesta HTTP con el código de estado 200OK.
        [ProducesResponseType(typeof(FootballTeam), StatusCodes.Status200OK)]
        //indica que el método de acción puede devolver una respuesta HTTP con el código de estado 204NoContent.
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        [Route("FootballTeam/Get")]
        public IActionResult Get()
        {
            return _football.GetAll().Count > 0 ? Ok(_football.GetAll()) : NoContent();
        }


        //indica que el método de acción puede devolver una respuesta HTTP con el código de estado 200OK.
        [ProducesResponseType(typeof(FootballTeam), StatusCodes.Status200OK)]
        //indica que el método de acción puede devolver una respuesta HTTP con el código de estado 400BadRequest.
        [ProducesResponseType(typeof(ResponseDTO),StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route("FootballTeam/SaveTeam")]
        public IActionResult Save(FootBallTeamDTO dto)
        {
            var f = new FootballTeam()
            {
                Name = dto.Name,
                Foundation = dto.Foundation,
                City = dto.City,
                Coach = dto.Coach
            };

            return _football.Save(f) is not null ? Ok(_football.Save(f)) : BadRequest(new ResponseDTO()
            {
                StatusCode = 404,
                StatusMessage = "La solicitud fue incorrecto debido a una sintaxis incorrecta, una falta de " +
                                     "información o un formato incorrecto en la solicitud."
            });
        }
    }
}
