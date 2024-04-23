using System;
using Negocio.EntitiesDTO;
using Negocio.Enums;

namespace Negocio.Calculos
{
    public class CalculosRecurrentesMensuales
    {
        public DateTime CalculoFechaEjecucion(EntradaDTO entrada)
        {
            if (entrada.ConfiguracionMensual.Tipo[0])
            {
                return ComprobacionDiaSeleccionadoConActual(entrada);
            }

            return FechaFrecuencia(entrada);
        }        

        private DateTime ComprobacionDiaSeleccionadoConActual(EntradaDTO entrada)
        {
            // Obtener la cantidad de días del mes actual
            int diasMesSiguiente = DateTime.DaysInMonth(entrada.FechaActual.Year, entrada.FechaActual.AddMonths(1).Month);

            // Comprobar si el día seleccionado es menor o igual al día actual y menor o igual al número de días que tiene el mes siguiente
            if (entrada.ConfiguracionMensual.DiaMes <= entrada.FechaActual.Day)
            {
                // Se devuelve el mismo día del mes siguiente
                return ComprobacionDiaSeleccionadoConDiasMesSiguiente(entrada);
            }

            return ComprobacionDiaSeleccionadoDiasMesActual(entrada);
        }

        private DateTime ComprobacionDiaSeleccionadoConDiasMesSiguiente(EntradaDTO entrada)
        {
            // Obtener la cantidad de días del mes actual
            int diasMesSiguiente = DateTime.DaysInMonth(entrada.FechaActual.Year, entrada.FechaActual.AddMonths(1).Month);

            // Comprobar si el dia seleccionado es menor o igual al número de días que tiene el mes siguiente
            if(entrada.ConfiguracionMensual.DiaMes <= diasMesSiguiente)
            {
                // Se devuelve el mismo día del mes siguiente
                return new DateTime(entrada.FechaActual.Year, entrada.FechaActual.Month, entrada.ConfiguracionMensual.DiaMes).AddMonths(1);
            }

            return new DateTime(entrada.FechaActual.Year, entrada.FechaActual.Month, diasMesSiguiente).AddMonths(1);
        }

        private DateTime ComprobacionDiaSeleccionadoDiasMesActual(EntradaDTO entrada)
        {
            // Obtener la cantidad de días del mes actual
            int diasMesActual = DateTime.DaysInMonth(entrada.FechaActual.Year, entrada.FechaActual.Month);

            // Comprobar si el día seleccionado es menor o igual que al número de días que tiene el mes actual
            if (entrada.ConfiguracionMensual.DiaMes <= diasMesActual)
            {
                // Se devuelve el mismo día del mismo mes
                return new DateTime(entrada.FechaActual.Year, entrada.FechaActual.Month, entrada.ConfiguracionMensual.DiaMes);                
            }

            return new DateTime(entrada.FechaActual.Year, entrada.FechaActual.Month, diasMesActual);
        }
               

        private DateTime FechaFrecuencia(EntradaDTO entrada)
        {
            // Obtener el día de la semana deseado
            DayOfWeek diaSemanaDeseado = ObtenerDiaSemana(entrada.ConfiguracionMensual.DiaSemana);

            // Obtener el número del día según la frecuencia
            int numeroDia = (int)entrada.ConfiguracionMensual.FrecuenciaDia;

            // Obtener la fecha actual
            DateTime fechaActual = entrada.FechaActual;

            // Calcular la fecha correspondiente
            DateTime fechaCalculada = new DateTime(fechaActual.Year, fechaActual.Month, 1); // Iniciar con el primer día del mes
            while (fechaCalculada.DayOfWeek != diaSemanaDeseado) // Avanzar al primer día de la semana correspondiente al día de la semana deseado
            {
                fechaCalculada = fechaCalculada.AddDays(1);
            }

            if (entrada.ConfiguracionMensual.FrecuenciaDia == FrecuenciasDia.Ultimo)
            {
                // Si la frecuencia es "Ultimo", nos movemos al último día de la semana correspondiente en el mes
                while (fechaCalculada.Month == fechaActual.Month)
                {
                    if (fechaCalculada.AddDays(7).Month != fechaActual.Month)
                        break;
                    fechaCalculada = fechaCalculada.AddDays(7);
                }
                fechaCalculada = fechaCalculada.AddDays(-7);
            }
            else
            {
                // Avanzar al número de semana deseado
                fechaCalculada = fechaCalculada.AddDays(7 * (numeroDia - 1));
            }

            return fechaCalculada;
        }

        private DayOfWeek ObtenerDiaSemana(DiasSemana diaSemana)
        {
            Random rnd = new Random();

            switch (diaSemana)
            {
                case DiasSemana.Lunes: return DayOfWeek.Monday;
                case DiasSemana.Martes: return DayOfWeek.Tuesday;
                case DiasSemana.Miercoles: return DayOfWeek.Wednesday;
                case DiasSemana.Jueves: return DayOfWeek.Thursday;
                case DiasSemana.Viernes: return DayOfWeek.Friday;
                case DiasSemana.Sabado: return DayOfWeek.Saturday;
                case DiasSemana.Domingo: return DayOfWeek.Sunday;
                case DiasSemana.Dia:
                    // Generar un valor de día aleatorio
                    return (DayOfWeek)rnd.Next(0, 7); // Los valores van de 0 a 6 (Monday a Sunday)
                case DiasSemana.Entre_semana: return DayOfWeek.Monday; // Considerar días entre semana (lunes a viernes)
                case DiasSemana.Fin_de_semana: return DayOfWeek.Saturday; // Considerar fines de semana (sábado y domingo)
                default: throw new ArgumentException("Día de la semana no válido");
            }
        }
    }
}