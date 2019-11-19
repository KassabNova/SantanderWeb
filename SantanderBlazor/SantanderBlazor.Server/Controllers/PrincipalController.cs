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
    public class PrincipalController
    {
        [HttpPost]
        public RespuestaCliente Cliente(Cliente cliente)
        {
            RespuestaCliente respuesta = new RespuestaCliente();
            List<Tarjeta> tarjetas = new List<Tarjeta>();
            double saldo = 0;
            tarjetas = SantanderBlazorHelper.ObtenerTarjetas(cliente.usuario, out respuesta.ResultadoOperacion);

            if (tarjetas != null && tarjetas.Count() > 0)
            {
                foreach (Tarjeta tarjeta in tarjetas)
                {
                    saldo += tarjeta.Saldo;
                    tarjeta.usuario = cliente.usuario;
                }
            }
            respuesta.tarjetas = tarjetas;
            respuesta.saldo = saldo;
            respuesta.cliente = cliente;


            return respuesta;
        }

    }
}
