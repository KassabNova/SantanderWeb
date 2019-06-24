using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SantanderBlazor.Shared.Models.Entidades.Respuestas;
using SantanderBlazor.Shared.Models.Entidades;
using SantanderBlazor.Server.Models.Helpers;

namespace SantanderBlazor.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        // POST: api/Login
       
        [HttpPost]
        public RespuestaLogin loginRespuesta([FromBody] Cliente cliente)
        {
            RespuestaLogin respuesta = new RespuestaLogin();
            ResultadoOperacion resultadoOperacion = new ResultadoOperacion();
            respuesta.login = SantanderBlazorHelper.LoginCliente(cliente.usuario, cliente.Password, out resultadoOperacion);
            respuesta.resultadoOperacion = resultadoOperacion;
            return respuesta;
        }


    }
}
