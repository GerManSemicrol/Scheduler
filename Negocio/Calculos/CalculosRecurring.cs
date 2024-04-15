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
        public SalidaDTO CalcularRecurrente(EntradaDTO entrada)
        {
            if (entrada.TiposCalculos != TiposCalculos.Recurrente)
            {
                return null;
            }
            return new SalidaDTO()
            {
                Tipo = entrada.TiposCalculos,
                FechaEjecucion = FechaRepeticionRecurrente(entrada),
                Descripcion = ObtenerDescripcion(FechaRepeticionRecurrente(entrada), entrada.TiposCalculos)
            };
        }
        private DateTime FechaRepeticionRecurrente(EntradaDTO entrada)
        {
            DateTime fechaRepeticion = new DateTime();

            if (entrada.Ocurrencia == OcurrenciaCalculos.Diaria)
            {
                fechaRepeticion = entrada.FechaActual.AddDays(entrada.DiasRepeticion);
            }
            else if (entrada.Ocurrencia == OcurrenciaCalculos.Semanal)
            {
                fechaRepeticion = entrada.FechaActual.AddDays(7);
            }

            else if (entrada.Ocurrencia == OcurrenciaCalculos.Quincenal)
            {
                fechaRepeticion = entrada.FechaActual.AddDays(15);
            }

            return fechaRepeticion;
        }

        private string ObtenerDescripcion(DateTime fecha, TiposCalculos tipo)
        {            
                return $"Ocurre diariamente. El programador se utilizará el {fecha.ToString(("dd/MM/yyyy"))}";            
        }


    }
}
