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
                case FrecuenciasDia.Primero:
                    return PrimerDia(entrada);
                case FrecuenciasDia.Segundo:
                    return PrimerDia(entrada).AddDays(7);
                case FrecuenciasDia.Tercero:
                    return PrimerDia(entrada).AddDays(14);
                case FrecuenciasDia.Cuarto:
                    return PrimerDia(entrada).AddDays(21);
                case FrecuenciasDia.Ultimo:
                    return UltimoDia(entrada);
                default:
                    throw new ArgumentException("Frecuencia no válida.");
            }
        }      

        private DateTime PrimerDia(EntradaDTO entrada)
        {
            DateTime fechaResultado = entrada.FechaActual;

            // Obtiene el día de la semana de repetición deseado
            DayOfWeek diaSemanaDeseado = DiaSemanaDeseado(entrada.ConfiguracionMensual.DiaSemana);

            // Comprobar si el día de la fecha actual es mayor a 7
            if (entrada.FechaActual.Day > 7 || diaSemanaDeseado < fechaResultado.DayOfWeek)
            {
                // Se pasa al día 1 del mes siguiente
                fechaResultado = new DateTime(fechaResultado.Year, fechaResultado.Month, 1).AddMonths(1);
            }                        

            return CalculoFechaResultado(fechaResultado,diaSemanaDeseado);
        }

        private DateTime UltimoDia(EntradaDTO entrada)
        {
            DateTime fechaResultado = PrimerDia(entrada).AddDays(28);
            DayOfWeek diaSemanaDeseado = DiaSemanaDeseado(entrada.ConfiguracionMensual.DiaSemana);

            while (fechaResultado.Month == fechaResultado.AddDays(7).Month)
            {
                fechaResultado = fechaResultado.AddDays(7);
            }

            return CalculoFechaResultado(fechaResultado, diaSemanaDeseado);
        }

        private DateTime CalculoFechaResultado(DateTime fecha, DayOfWeek dia)
        {
            while (fecha.DayOfWeek != dia)
            {
                fecha = fecha.AddDays(1);
            }

            return fecha;
        }

        private DayOfWeek DiaSemanaDeseado(DiasSemana diaSemana)
        {
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
                    return (DayOfWeek)new Random().Next(0, 7); // Los valores van de 0 a 6 (Monday a Sunday)
                case DiasSemana.Entre_semana: return DayOfWeek.Monday;
                case DiasSemana.Fin_de_semana: return DayOfWeek.Saturday;
                default: throw new ArgumentException("Día de la semana no válido");
            }
        }              
    }
}