using System;
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