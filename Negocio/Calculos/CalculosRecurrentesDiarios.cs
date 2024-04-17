using System;
using Negocio.EntitiesDTO;

namespace Negocio.Calculos
{
    public class CalculosRecurrentesDiarios
    {
        public DateTime CalculoFechaEjecucion(EntradaDTO entrada)
        {            
            return entrada.FechaActual.AddDays(entrada.DiasRepeticion);
        }
    }
}