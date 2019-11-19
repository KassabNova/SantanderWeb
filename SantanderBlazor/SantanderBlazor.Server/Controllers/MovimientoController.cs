using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SantanderBlazor.Shared.Models.Entidades.Respuestas;
using SantanderBlazor.Shared.Models.Entidades.Solicitudes;
using SantanderBlazor.Shared.Models.Entidades;
using SantanderBlazor.Server.Models.Helpers;
using System.Text;

namespace SantanderBlazor.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MovimientoController : ControllerBase
    {
        [HttpPost]
        public RespuestaTransferencia Transferencia([FromBody] SolicitudTransferencia solicitud)
        {
            RespuestaTransferencia respuesta = new RespuestaTransferencia();
            respuesta.ResultadoOperacion = new ResultadoOperacion();
            if (solicitud.Monto == 0 || solicitud.TarjetaOrigen == null)
            {
                respuesta.ResultadoOperacion.Tipo = TipoResultado.INCOMPLETE;
                respuesta.ResultadoOperacion.Detalle = "Solicitud Incompleta";
            }
            else
            {
                if (solicitud.PagoTerceros) SantanderBlazorHelper.TransferenciaTerceros(solicitud.TarjetaOrigen, solicitud.Monto, solicitud.Detalle, out respuesta.ResultadoOperacion);
                else SantanderBlazorHelper.TransferenciaInterbancaria(solicitud.TarjetaOrigen, solicitud.TarjetaDestino, solicitud.Monto, solicitud.Detalle, out respuesta.ResultadoOperacion);
                //respuesta.credito = creditos;
            }


            return respuesta;
        }
        [HttpPost]
        public RespuestaMovimientos Movimientos([FromBody] Tarjeta tarjeta)
        {
            RespuestaMovimientos respuesta = new RespuestaMovimientos();
            respuesta.ResultadoOperacion = new ResultadoOperacion();
            List<Movimiento> movimientos = new List<Movimiento>();
            if (tarjeta.NumTarjeta == null)
            {
                respuesta.ResultadoOperacion.Tipo = TipoResultado.INCOMPLETE;
                respuesta.ResultadoOperacion.Detalle = "Solicitud Incompleta";
            }
            else
            {
                movimientos = SantanderBlazorHelper.ObtenerMovimientos(tarjeta.NumTarjeta, out respuesta.ResultadoOperacion);
                respuesta.Movimientos = movimientos;
            }

            return respuesta;
        }
    }
}
