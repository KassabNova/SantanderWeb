using System;
using System.Collections.Generic;
using System.Text;

namespace SantanderBlazor.Shared.Models.Entidades.Respuestas
{
    public class RespuestaLogin
    {
        public ResultadoOperacion resultadoOperacion { get; set; }

        public bool login { get; set; }

        public string token { get; set; }

        public int usuario { get; set; }

    }
}
