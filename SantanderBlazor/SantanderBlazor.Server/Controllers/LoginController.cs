using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SantanderBlazor.Shared.Models.Entidades.Respuestas;
using SantanderBlazor.Shared.Models.Entidades;
using SantanderBlazor.Server.Models.Helpers;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;

namespace SantanderBlazor.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        public RespuestaLogin loginRespuesta([FromBody] Cliente cliente)
        {
            RespuestaLogin respuesta = new RespuestaLogin();
            ResultadoOperacion resultadoOperacion = new ResultadoOperacion();
            respuesta.login = SantanderBlazorHelper.LoginCliente(cliente.usuario, cliente.Password, out resultadoOperacion);
            respuesta.resultadoOperacion = resultadoOperacion;
            respuesta.usuario = cliente.usuario;
            if(respuesta.login == true) respuesta.token = createToken(cliente);
           

            return respuesta;
        }


        private string createToken(Cliente cliente)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, cliente.usuario.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JwtExpiry"]));

            var token = new JwtSecurityToken(_configuration["JwtIssuer"], _configuration["JwtAudience"],claims,expires: expiry,signingCredentials:creds);

            var tokenSerialized = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenSerialized;

        }

        private string epochDate(int epoch)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(epoch).ToShortDateString();
        }

    }
}
