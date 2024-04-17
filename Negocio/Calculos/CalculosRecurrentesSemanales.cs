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
        public DateTime CalculoFechaEjecucion(EntradaDTO entrada)
        {
            int diasHastaProximoDiaSeleccionado = 0;
            int diaActual = (int)entrada.FechaActual.DayOfWeek;

            // Itera sobre los próximos 7 días para encontrar el siguiente día de ejecución.
            for (int i = 1; i <= 7; i++)
            {
                int diaSiguiente = (diaActual + i) % 7;

                // Si el día siguiente está marcado como día de ejecución, establece el contador y sale del bucle.
                if (entrada.ConfiguracionSemana.DiasSemana[diaSiguiente])
                {
                    diasHastaProximoDiaSeleccionado = i;
                    break;
                }
            }

            // Calcular la fecha del próximo día seleccionado
            DateTime fechaProximoDiaSeleccionado = entrada.FechaActual.Date.AddDays(diasHastaProximoDiaSeleccionado);

            // Calcular la hora de ejecución
            DateTime horaEjecucion = CalculoHoraEjecucion(entrada);

            return fechaProximoDiaSeleccionado.Date.Add(horaEjecucion.TimeOfDay);
        }

        private DateTime CalculoHoraEjecucion(EntradaDTO entrada)
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

        public string ObtenerDescripcion(EntradaDTO entrada)
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
