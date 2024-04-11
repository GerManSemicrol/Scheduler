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
            SalidaDTO datosSalida = new SalidaDTO();            

            datosSalida.Tipo = ComprobarTipo(entrada.TiposCalculos);
            if(datosSalida.Tipo == TiposCalculos.Una_vez)
            {
                datosSalida.FechaEjecucion = entrada.FechaRepeticion;
                datosSalida.Descripcion = $"Ocurre una vez. El programador se utilizará el {datosSalida.FechaEjecucion.ToString(("dd/MM/yyyy"))} a las " +
                    $"{datosSalida.FechaEjecucion.ToString(("HH:mm"))}";
            }
            else if(datosSalida.Tipo == TiposCalculos.Recurrente)
            {
                datosSalida.FechaEjecucion = RepeticionRecurrente(entrada.FechaActual,entrada.Ocurrencia);
                datosSalida.Descripcion = $"Ocurre diariamente. El programador se utilizará el {datosSalida.FechaEjecucion.ToString(("dd/MM/yyyy"))}";

            }

            return datosSalida;
        }

        public TiposCalculos ComprobarTipo(TiposCalculos tipo)
        {                
            return tipo;
        }

        public DateTime RepeticionRecurrente (DateTime fecha, OcurrenciaCalculos ocurrencia)
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







    }
}
