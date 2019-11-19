using System;
using System.Collections.Generic;
using System.Text;

namespace SantanderBlazor.Shared.Models.Entidades
{
    public class Sucursal
    {
        public int IdSucursal { get; set; }

        public String Direccion { get; set; }

        public String Tipo { get; set; }

        public String Nombre { get; set; }

        public String Longitud { get; set; }

        public String Latitud { get; set; }
    }
}
