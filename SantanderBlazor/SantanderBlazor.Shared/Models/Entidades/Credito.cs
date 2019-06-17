using System;
using System.Collections.Generic;
using System.Text;

namespace SantanderBlazor.Shared.Models.Entidades
{
    public class Credito
    {

        public int IdCredito { get; set; }

        public int NumCuenta { get; set; }

        public double Saldo { get; set; }

        public double Interes { get; set; }

        public String Tipo { get; set; }

        public int PlazoMeses { get; set; }

        public DateTime FechaCorte { get; set; }

        public DateTime FechaPago { get; set; }

        public DateTime FechaPlazo { get; set; }



    }

}
