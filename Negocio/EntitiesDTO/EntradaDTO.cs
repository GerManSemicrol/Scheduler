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
        public FrecuenciaDiariaDTO FrecuenciaDiaria { get; set; }
        public ConfiguracionSemanalDTO ConfiguracionSemana { get; set; }
        public ConfiguracionMensualDTO ConfiguracionMensual { get; set; }
        public Idiomas Idioma { get; set; }
    }
}