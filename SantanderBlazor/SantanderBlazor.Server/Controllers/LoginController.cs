using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SantanderBlazor.Shared;
using SantanderBlazor.Shared.Models.Entidades.Respuestas;
using SantanderBlazor.Shared.Models.Entidades;
using SantanderBlazor.Server.Models.Helpers;

namespace SantanderBlazor.Server.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        // POST: api/Login
       
        [HttpPost]
        public RespuestaLogin Post([FromBody] Cliente cliente)
        {
            RespuestaLogin respuesta = new RespuestaLogin();
            bool login = SantanderBlazorHelper.LoginCliente(cliente.usuario, cliente.Password, out respuesta.ResultadoOperacion);
            respuesta.login = login;
            
            return respuesta;
        }
       

    }
}
