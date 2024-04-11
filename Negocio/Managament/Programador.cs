using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.EntitiesDTO;
using Negocio.Enums;

namespace Negocio.Managament
{
    public class Programador
    {
        public SalidaDTO Calcular(EntradaDTO entrada)
        {
            return CalcularSoloUnaVez(entrada) ?? CalcularRecurrente(entrada);
        }
                
        private SalidaDTO CalcularRecurrente(EntradaDTO entrada)
        {
            if(entrada.TiposCalculos != TiposCalculos.Recurrente)
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

        private SalidaDTO CalcularSoloUnaVez(EntradaDTO entrada)
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

        private DateTime RepeticionRecurrente (DateTime fecha, OcurrenciaCalculos ocurrencia)
        {
            DateTime fechaRepeticion= new DateTime();

            if(ocurrencia == OcurrenciaCalculos.Diaria)
            {
                fechaRepeticion = fecha.AddDays(1);
            }
            else if(ocurrencia == OcurrenciaCalculos.Semanal)
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
            if(tipo == TiposCalculos.Una_vez)
            {
                return $"Ocurre una vez. El programador se utilizará el {fecha.ToString(("dd/MM/yyyy"))} a las " +
                    $"{fecha.ToString(("HH:mm"))}";
            }
            else if(tipo == TiposCalculos.Recurrente)
            {
                return $"Ocurre diariamente. El programador se utilizará el {fecha.ToString(("dd/MM/yyyy"))}";
            }
            return null;
        }
    }
}
