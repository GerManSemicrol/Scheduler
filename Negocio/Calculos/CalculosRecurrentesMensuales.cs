using System;
using System.Collections.Generic;
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
            if (entrada.ConfiguracionMensual.DiaMes <= diasMesSiguiente)
            {
                // Se devuelve el mismo día del mes siguiente
                return new DateTime(entrada.FechaActual.Year, entrada.FechaActual.Month, entrada.ConfiguracionMensual.DiaMes).AddMonths(1);
            }

            // Si no se cumple condición se devuelve el último día del mes siguiente
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

            // Si no se cumple condición se devuelve el último día del mismo mes
            return new DateTime(entrada.FechaActual.Year, entrada.FechaActual.Month, diasMesActual);
        }

        private DateTime FechaFrecuencia(EntradaDTO entrada)
        {

            switch (entrada.ConfiguracionMensual.FrecuenciaDia)
            {
                case FrecuenciasDia.Primer:
                    return ComprobarDiaFechaActual(entrada, 0);
                case FrecuenciasDia.Segundo:
                    return ComprobarDiaFechaActual(entrada, 1);
                case FrecuenciasDia.Tercer:
                    return ComprobarDiaFechaActual(entrada, 2);
                case FrecuenciasDia.Cuarto:
                    return ComprobarDiaFechaActual(entrada, 3);
                case FrecuenciasDia.Ultimo:
                    return ComprobarDiaFechaActual(entrada, (ObtenerDiasMesDiaSemanaDeseado(entrada).Count) - 1);
                default:
                    throw new ArgumentException("Frecuencia no válida.");
            }
        }

        private DateTime ComprobarDiaFechaActual(EntradaDTO entrada, int indice)
        {
            List<DateTime> dias = ObtenerDias(entrada);

            // Obtener la fecha actual
            DateTime fechaActual = entrada.FechaActual;

            if (dias[indice] >= fechaActual)
            {
                return dias[indice];
            }

            // Si no se encontró ninguna fecha posterior a la fecha actual, se toma el primer día del mes siguiente
            entrada.FechaActual = new DateTime(fechaActual.Year, fechaActual.Month, 1).AddMonths(1);
            dias = ObtenerDias(entrada);

            if (entrada.ConfiguracionMensual.FrecuenciaDia == FrecuenciasDia.Ultimo)
            {
                indice = dias.Count - 1;
            }

            return dias[indice];
        }

        private List<DateTime> ObtenerDias(EntradaDTO entrada)
        {
            if (entrada.ConfiguracionMensual.DiaSemana == DiasSemana.Dia)
            {
                return ObtenerDiasDiaDeseado(entrada);
            }

            return ObtenerDiasMesDiaSemanaDeseado(entrada);
        }

        private List<DateTime> ObtenerDiasDiaDeseado(EntradaDTO entrada)
        {
            List<DateTime> dias = new List<DateTime>();
            

            // Calcular el día de la semana de la fecha actual
            int DiaDeLaSemana = (int)entrada.FechaActual.DayOfWeek;

            DayOfWeek diaSemanaDeseado = DiaSemanaDeseado(entrada);

            // Calcular la diferencia entre el día de la semana deseado y el primer día del mes
            int diferencia = ((int)diaSemanaDeseado - DiaDeLaSemana + 7) % 7;

            // Calcular el primer día del mes que coincide con el día de la semana especificado
            DateTime primerDiaBuscado = entrada.FechaActual.AddDays(diferencia);

            // Añadir los siguientes días que coinciden con el día de la semana especificado
            while (primerDiaBuscado.Month == entrada.FechaActual.Month)
            {
                dias.Add(primerDiaBuscado);
                primerDiaBuscado = primerDiaBuscado.AddDays(1);
            }

            return dias;
        }

        private List<DateTime> ObtenerDiasMesDiaSemanaDeseado(EntradaDTO entrada)
        {
            List<DateTime> dias = new List<DateTime>();

            // Obtener el primer día del mes
            DateTime fecha = new DateTime(entrada.FechaActual.Year, entrada.FechaActual.Month, 1);

            // Calcular el día de la semana del primer día del mes
            int primerDiaDeLaSemana = (int)fecha.DayOfWeek;

            DayOfWeek diaSemanaDeseado = DiaSemanaDeseado(entrada);

            // Calcular la diferencia entre el día de la semana deseado y el primer día del mes
            int diferencia = ((int)diaSemanaDeseado - primerDiaDeLaSemana + 7) % 7;

            // Calcular el primer día del mes que coincide con el día de la semana especificado
            DateTime primerDiaBuscado = fecha.AddDays(diferencia);

            // Añadir los siguientes días que coinciden con el día de la semana especificado
            while (primerDiaBuscado.Month == entrada.FechaActual.Month)
            {
                dias.Add(primerDiaBuscado);
                primerDiaBuscado = primerDiaBuscado.AddDays(7);
            }

            return dias;
        }

        private DayOfWeek DiaSemanaDeseado(EntradaDTO entrada)
        {
            switch (entrada.ConfiguracionMensual.DiaSemana)
            {
                case DiasSemana.Lunes: return DayOfWeek.Monday;
                case DiasSemana.Martes: return DayOfWeek.Tuesday;
                case DiasSemana.Miercoles: return DayOfWeek.Wednesday;
                case DiasSemana.Jueves: return DayOfWeek.Thursday;
                case DiasSemana.Viernes: return DayOfWeek.Friday;
                case DiasSemana.Sabado: return DayOfWeek.Saturday;
                case DiasSemana.Domingo: return DayOfWeek.Sunday;
                case DiasSemana.Dia: return ComprobacionDay(entrada);
                case DiasSemana.Entre_semana: return DayOfWeek.Monday;
                case DiasSemana.Fin_de_semana: return DayOfWeek.Saturday;
                default: throw new ArgumentException("Día de la semana no válido");
            }
        }

        private DayOfWeek ComprobacionDay(EntradaDTO entrada)
        {
            DateTime horaActual = DateTime.Now;

            // Verificar si la hora actual es posterior a la hora de inicio
            if (horaActual.TimeOfDay > entrada.FrecuenciaDiaria.HoraInicio.TimeOfDay)
            {
                // Si es posterior, se pasa al día siguiente
                return entrada.FechaActual.AddDays(1).DayOfWeek;
            }
            else
            {
                // Si es anterior, devuelve el mismo día 
                return DateTime.Today.Add(entrada.FrecuenciaDiaria.HoraInicio.TimeOfDay).DayOfWeek;
            }
        }
    }
}