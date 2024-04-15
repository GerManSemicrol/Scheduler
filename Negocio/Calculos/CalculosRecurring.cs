using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.EntitiesDTO;
using Negocio.Enums;

namespace Negocio.Calculos
{
    public class CalculosRecurring
    {
        public SalidaDTO CalcularRecurrente(EntradaDTO entrada, FrecuenciaDiariaDTO frecuencia)
        {
            if (entrada.TiposCalculos != TiposCalculos.Recurrente)
            {
                return null;
            }
            return new SalidaDTO()
            {
                Tipo = entrada.TiposCalculos,
                FechaEjecucion = RepeticionRecurrente(entrada.FechaActual, entrada.Ocurrencia),
                Descripcion = ObtenerDescripcion(RepeticionRecurrente(entrada.FechaActual, entrada.Ocurrencia), entrada.TiposCalculos)
            };
        }
        private DateTime RepeticionRecurrente(DateTime fecha, OcurrenciaCalculos ocurrencia)
        {
            DateTime fechaRepeticion = new DateTime();

            if (ocurrencia == OcurrenciaCalculos.Diaria)
            {
                fechaRepeticion = fecha.AddDays(1);
            }
            else if (ocurrencia == OcurrenciaCalculos.Semanal)
            {
                fechaRepeticion = fecha.AddDays(7);
            }

            else if (ocurrencia == OcurrenciaCalculos.Quincenal)
            {
                fechaRepeticion = fecha.AddDays(15);
            }

            return fechaRepeticion;
        }

        private string ObtenerDescripcion(DateTime fecha, TiposCalculos tipo)
        {            
                return $"Ocurre diariamente. El programador se utilizará el {fecha.ToString(("dd/MM/yyyy"))}";            
        }
    }
}
