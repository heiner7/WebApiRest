using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapi.Configuration;
using Webapi.DTOs;

namespace Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        ITokenHandleService _services;
        public AuthController(UserManager<IdentityUser> userManager, ITokenHandleService service)
        {
            _userManager = userManager;
            _services = service;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequestDTO user)
        {
            //Verifica si el objecto es valido con los campos establecidos con Required
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(user.Email);
                if (existingUser != null)
                {
                    return BadRequest("El correo electronico indicado ya existe!");
                }

                var isCreated = await _userManager.CreateAsync(new IdentityUser() { 
                    Email = user.Email, UserName = user.Name
                }, user.Password);
                if (isCreated.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(isCreated.Errors.Select(x => x.Description).ToList());
                }
            }
            else
            {
                return BadRequest("Se produjo algun error al registrar el usario");
            }
        }

        //indica que el método de acción puede devolver una respuesta HTTP con el código de estado 200OK.
        [ProducesResponseType(typeof(UserLoginResponseDTO), StatusCodes.Status200OK)]
        //indica que el método de acción puede devolver una respuesta HTTP con el código de estado 204NoContent.
        [ProducesResponseType(typeof(UserLoginResponseDTO), StatusCodes.Status204NoContent)]
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDTO user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(user.Email);
                if (existingUser == null)
                {
                    return BadRequest(new UserLoginResponseDTO() { 
                      Login = false,
                      Errors = new List<string>()
                      {
                          "¡Email no registrado!"
                      }
                    });
                }
                //Chequeamos que el usuario existe
                var isCorrect = await _userManager.CheckPasswordAsync(existingUser, user.Password);

                if (isCorrect)
                {
                    var pars = new TokenParameters()
                    {
                        Id = existingUser.Id,
                        PasswordHash = existingUser.PasswordHash,
                        UserName = existingUser.UserName,
                        Rol = existingUser.UserName
                    };
                    
                    var jwtToken = _services.GenerateJwtToken(pars);
                    return Ok(new UserLoginResponseDTO()
                    {
                        Login = true,
                        Token = jwtToken,
                        Rol = pars.Rol
                    });
                }
                else
                {
                    return BadRequest(new UserLoginResponseDTO()
                    {
                        Login = false,
                        Errors = new List<string>()
                      {
                          "¡Email o contraseña incorrecta!"
                      }
                    });
                }
            }
            else
            {
                return BadRequest(new UserLoginResponseDTO()
                {
                    Login = false,
                    Errors = new List<string>()
                      {
                          "¡Error en el formato!"
                      }
                });
            }
        }

    }
}
