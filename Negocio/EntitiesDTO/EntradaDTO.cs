using System;
using Negocio.Enums;

namespace Negocio.EntitiesDTO
{
    public class EntradaDTO
    {
        public DateTime FechaActual { get; set; }
        public TiposCalculos TipoCalculo { get; set; }
        public DateTime FechaRepeticion { get; set; }
        public OcurrenciaCalculos Ocurrencia { get; set; }
        public int DiasRepeticion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public FrecuenciaDiariaDTO FrecuenciaDiaria { get; set; }
        public ConfiguracionSemanalDTO ConfiguracionSemana { get; set; }
    }
}
