using System;
using Negocio.EntitiesDTO;
using Negocio.Enums;

namespace Negocio.Calculos
{
    public class CalculosRecurrentes
    {
        public SalidaDTO CalcularRecurrente(EntradaDTO entrada)
        {
            if (entrada.TipoCalculo != TiposCalculos.Recurrente)
            {
                return null;
            }
            return new SalidaDTO()
            {
                Tipo = entrada.TipoCalculo,
                FechaEjecucion = FechaEjecucionRepeticionRecurrente(entrada),
                Descripcion = new Descripcion().ObtenerDescripcion(entrada)
            };
        }
        private DateTime FechaEjecucionRepeticionRecurrente(EntradaDTO entrada)
        {
            DateTime fechaRepeticion = new DateTime();

            if (entrada.Ocurrencia == OcurrenciaCalculos.Diaria)
            {  
                return new CalculosRecurrentesDiarios().CalculoFechaEjecucion(entrada);
            }
            else if (entrada.Ocurrencia == OcurrenciaCalculos.Semanal)
            {        
                return new CalculosRecurrentesSemanales().CalculoFechaEjecucion(entrada);                
            }
            else if (entrada.Ocurrencia == OcurrenciaCalculos.Quincenal)
            {
                fechaRepeticion = entrada.FechaActual.AddDays(15);
            }

            return fechaRepeticion;
        }        
    }
}
