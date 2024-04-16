using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Enums;

namespace Negocio.EntitiesDTO
{
    public class SalidaDTO
    {
        public DateTime FechaEjecucion { get; set; }
        public string Descripcion { get; set; }
        public TiposCalculos Tipo { get; set; }        
    }
}