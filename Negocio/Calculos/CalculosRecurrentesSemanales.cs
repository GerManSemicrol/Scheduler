using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.EntitiesDTO;
using Negocio.Enums;

namespace Negocio.Calculos
{
    public class CalculosRecurrentesSemanales
    {
        public DateTime calculoFechaEjecucion(EntradaDTO entrada)
        {
            int diasHastaProximoDiaSeleccionado = 0;
            int diaActual = (int)entrada.FechaActual.DayOfWeek;
            for (int i = 1; i <= 7; i++)
            {
                int diaSiguiente = (diaActual + i) % 7;
                if (entrada.ConfiguracionSemana.DiasSemana[diaSiguiente])
                {
                    diasHastaProximoDiaSeleccionado = i;
                    break;
                }
            }

            // Calcular la fecha del próximo día seleccionado
            DateTime fechaProximoDiaSeleccionado = entrada.FechaActual.Date.AddDays(diasHastaProximoDiaSeleccionado);

            // Calcular la hora de ejecución
            DateTime horaEjecucion = calculoHoraEjecucion(entrada);            

            return fechaProximoDiaSeleccionado.Date.Add(horaEjecucion.TimeOfDay);

        }

        private DateTime calculoHoraEjecucion(EntradaDTO entrada)
        {
            DateTime horaActual = DateTime.Now;

            // Verificar si la hora actual es posterior a la hora de inicio
            if (horaActual.TimeOfDay > entrada.FrecuenciaDiaria.HoraInicio.TimeOfDay)
            {
                // Si es posterior, calcular la próxima ejecución sumando el tiempo de repetición a la hora de inicio
                return DateTime.Today.Add(entrada.FrecuenciaDiaria.HoraInicio.TimeOfDay).AddHours(entrada.FrecuenciaDiaria.TiempoRepeticion);
            }
            else
            {
                // Si es anterior, devolver la hora de inicio misma
                return DateTime.Today.Add(entrada.FrecuenciaDiaria.HoraInicio.TimeOfDay);
            }
        }

        public string obtenerDescripcion(EntradaDTO entrada)
        {
            if (entrada.FrecuenciaDiaria.TipoFrecuenciaDiaria == TiposCalculos.Una_vez)
            {
                return $"Ocurre semanalmente. El programador se utilizará el {entrada.FechaRepeticion.ToString(("dd/MM/yyyy"))} a las {entrada.FrecuenciaDiaria.HoraInicio.ToString("HH:mm")}";
            }
            else
            {
                return $"Ocurre semanalmente. El programador se utilizará el {entrada.FechaRepeticion.ToString(("dd/MM/yyyy"))} desde las {entrada.FrecuenciaDiaria.HoraInicio.ToString("HH:mm")}" +
                    $" a las {entrada.FrecuenciaDiaria.HoraFin.ToString("HH:mm")} cada {entrada.FrecuenciaDiaria.TiempoRepeticion} horas";
            }
            
        }
    }
}
