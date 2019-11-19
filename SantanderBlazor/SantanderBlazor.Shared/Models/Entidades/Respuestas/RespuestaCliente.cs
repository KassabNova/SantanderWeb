using System;
using System.Collections.Generic;
using System.Text;

namespace SantanderBlazor.Shared.Models.Entidades.Respuestas
{
    public class RespuestaCliente
    {
        public ResultadoOperacion ResultadoOperacion;

        public Cliente cliente;

        public List<Tarjeta> tarjetas;

        public double saldo;
    }
}
