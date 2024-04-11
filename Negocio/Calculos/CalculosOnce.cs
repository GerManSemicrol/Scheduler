using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.EntitiesDTO;
using Negocio.Enums;

namespace Negocio.Calculos
{
    public class CalculosOnce
    {
        public SalidaDTO CalcularSoloUnaVez(EntradaDTO entrada)
        {
            if (entrada.TiposCalculos != TiposCalculos.Una_vez)
            {
                return null;
            }
            return new SalidaDTO()
            {
                Tipo = entrada.TiposCalculos,
                FechaEjecucion = entrada.FechaRepeticion,
                Descripcion = ObtenerDescripcion(entrada.FechaRepeticion, entrada.TiposCalculos)
            };
        }
        private string ObtenerDescripcion(DateTime fecha, TiposCalculos tipo)
        {            
                return $"Ocurre una vez. El programador se utilizará el {fecha.ToString(("dd/MM/yyyy"))} a las " +
                    $"{fecha.ToString(("HH:mm"))}";            
        }
    }
}
