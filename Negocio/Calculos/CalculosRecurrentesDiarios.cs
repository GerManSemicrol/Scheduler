using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.EntitiesDTO;
using Negocio.Enums;

namespace Negocio.Calculos
{
    public class CalculosRecurrentesDiarios
    {
        public DateTime CalculoFechaEjecucion(EntradaDTO entrada)
        {            
            return entrada.FechaActual.AddDays(entrada.DiasRepeticion);
        }
                
        public string ObtenerDescripcion(EntradaDTO entrada)
        {
            if (entrada.FrecuenciaDiaria.TipoFrecuenciaDiaria == TiposCalculos.Una_vez)
            {
                return $"Ocurre diariamente. El programador se utilizará el {entrada.FechaRepeticion.ToString(("dd/MM/yyyy"))} a las {entrada.FrecuenciaDiaria.HoraInicio.ToString("HH:mm")}";
            }
            else
            {
                return $"Ocurre diariamente. El programador se utilizará el {entrada.FechaRepeticion.ToString(("dd/MM/yyyy"))} desde las {entrada.FrecuenciaDiaria.HoraInicio.ToString("HH:mm")}" +
                    $" a las {entrada.FrecuenciaDiaria.HoraFin.ToString("HH:mm")} cada {entrada.FrecuenciaDiaria.TiempoRepeticion} horas";
            }            
        }
    }
}