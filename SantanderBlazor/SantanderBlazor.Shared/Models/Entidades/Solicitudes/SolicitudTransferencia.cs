using System;
using System.Collections.Generic;
using System.Text;

namespace SantanderBlazor.Shared.Models.Entidades.Solicitudes
{
    public class SolicitudTransferencia
    {
        public String TarjetaOrigen;

        public String TarjetaDestino;

        public double Monto;

        public bool PagoTerceros;

        public String Detalle;
    }
}
