using System;
using System.Collections.Generic;
using System.Text;

namespace SantanderBlazor.Shared.Models.Entidades
{
    public class ResultadoOperacion
    {
        public TipoResultado Tipo;

        public String Detalle;

        public ResultadoOperacion()
        {
            Tipo = TipoResultado.NO_ERROR;
            Detalle = "Todo jala perfecto";
        }
    }
    public enum TipoResultado
    {
        NO_ERROR,
        DATA_ACCESS_ERROR,
        NOT_FOUND,
        OPERATION_ERROR,
        INCOMPLETE
    }
}
