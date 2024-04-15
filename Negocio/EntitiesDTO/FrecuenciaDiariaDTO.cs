using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Enums;

namespace Negocio.EntitiesDTO
{
    public class FrecuenciaDiariaDTO
    {
        public TiposCalculos TipoFrecuenciaDiaria { get; set; }        
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public int TiempoRepeticion { get; set; }
    }
}