using System;
using System.Globalization;
using Negocio.EntitiesDTO;
using Negocio.Enums;
using Negocio.Traducciones;

namespace Negocio.Calculos
{
    public class Descripcion
    {

        public string ObtenerDescripcion(EntradaDTO entrada)
        {
            string formatoFecha = entrada.Idioma == Idiomas.US ? "MM/dd/yyyy" : "dd/MM/yyyy";
            string formatoHora = entrada.Idioma != Idiomas.ESP ? "hh:mm tt" : "HH:mm";

            if (entrada.TipoCalculo == TiposCalculos.Una_vez)
            {
                return DescripcionCalculoUnavez(entrada, formatoFecha, formatoHora);
            }
            
            
                switch (entrada.Ocurrencia)
                {
                    case OcurrenciaCalculos.Diaria:
                        if (entrada.FrecuenciaDiaria.TipoFrecuenciaDiaria == TiposCalculos.Una_vez)
                        {
                            return DescripcionCalculoRecurrenteDiarioUnaVez(entrada, formatoFecha, formatoHora);
                        }
                        else
                        {
                            return DescripcionCalculoRecurrenteDiarioVariasVeces(entrada, formatoFecha, formatoHora);
                        }
                    case OcurrenciaCalculos.Semanal:
                        if (entrada.FrecuenciaDiaria.TipoFrecuenciaDiaria == TiposCalculos.Una_vez)
                        {
                            return DescripcionCalculoRecurrenteSemanalUnaVez(entrada, formatoFecha, formatoHora);
                        }
                        else
                        {
                            return DescripcionCalculoRecurrenteSemanalVariasVeces(entrada, formatoFecha, formatoHora);
                        }
                    case OcurrenciaCalculos.Mensual:
                        if (entrada.ConfiguracionMensual.Tipo[0])
                        {

                            if (entrada.FrecuenciaDiaria.TipoFrecuenciaDiaria == TiposCalculos.Una_vez)
                            {
                                return DescripcionCalculoRecurrenteMensualUnDiaUnaVez(entrada, formatoFecha, formatoHora);
                            }
                            return DescripcionCalculoRecurrenteMensualUnDiaVariasVeces(entrada, formatoFecha, formatoHora);

                        }
                        else
                        {
                            if (entrada.FrecuenciaDiaria.TipoFrecuenciaDiaria == TiposCalculos.Una_vez)
                            {
                                return DescripcionCalculoRecurrenteMensualVariosDiasUnaVez(entrada, formatoFecha, formatoHora);
                            }
                            return DescripcionCalculoRecurrenteMensualVariosDiasVariasVeces(entrada, formatoFecha, formatoHora);
                        }
                    default:
                        return null;
                
            }
            return null;
        }

        private Traductor ObtenerTraductor(Idiomas idioma)
        {
            switch (idioma)
            {
                case Idiomas.ESP:
                    return new TraduccionesESP();
                default:
                    return new TraduccionesENG();
            }
        }

        private string DescripcionCalculoUnavez(EntradaDTO entrada, String formatoFecha, String formatoHora)
        {
            Traductor traductor = ObtenerTraductor(entrada.Idioma);

            string descripcionPlantilla = traductor.ObtenerTraducciones("OccursOnce");

            return string.Format(descripcionPlantilla,
                                 entrada.FechaRepeticion.ToString(formatoFecha),
                                 entrada.FechaRepeticion.ToString(formatoHora, CultureInfo.InvariantCulture),
                                 entrada.FechaActual.ToString(formatoFecha));
        }

        private string DescripcionCalculoRecurrenteDiarioUnaVez(EntradaDTO entrada, String formatoFecha, String formatoHora)
        {
            Traductor traductor = ObtenerTraductor(entrada.Idioma);
            string descripcionPlantilla = traductor.ObtenerTraducciones("OccursEveryDayOnce");

            return string.Format(descripcionPlantilla,
                                 entrada.FechaRepeticion.ToString(formatoFecha),
                                 entrada.FrecuenciaDiaria.HoraInicio.ToString(formatoHora, CultureInfo.InvariantCulture),
                                 entrada.FechaActual.ToString(formatoFecha));
        }

        private string DescripcionCalculoRecurrenteDiarioVariasVeces(EntradaDTO entrada, String formatoFecha, String formatoHora)
        {
            Traductor traductor = ObtenerTraductor(entrada.Idioma);
            string descripcionPlantilla = traductor.ObtenerTraducciones("OccursEveryDayMultiple");

            return string.Format(descripcionPlantilla,
                                 entrada.FechaRepeticion.ToString(formatoFecha),
                                 entrada.FrecuenciaDiaria.HoraInicio.ToString(formatoHora, CultureInfo.InvariantCulture),
                                 entrada.FrecuenciaDiaria.HoraFin.ToString(formatoHora, CultureInfo.InvariantCulture),
                                 entrada.FrecuenciaDiaria.TiempoRepeticion,
                                 entrada.FechaActual.ToString(formatoFecha));
        }

        private string DescripcionCalculoRecurrenteSemanalUnaVez(EntradaDTO entrada, String formatoFecha, String formatoHora)
        {
            Traductor traductor = ObtenerTraductor(entrada.Idioma);
            string descripcionPlantilla = traductor.ObtenerTraducciones("OccursEveryWeekOnce");

            return string.Format(descripcionPlantilla,
                             entrada.ConfiguracionSemana.NumeroSemanas,
                             entrada.FechaRepeticion.ToString(formatoFecha),
                             entrada.FrecuenciaDiaria.HoraInicio.ToString(formatoHora, CultureInfo.InvariantCulture),
                             entrada.FechaActual.ToString(formatoFecha));
        }

        private string DescripcionCalculoRecurrenteSemanalVariasVeces(EntradaDTO entrada, String formatoFecha, String formatoHora)
        {
            Traductor traductor = ObtenerTraductor(entrada.Idioma);
            string descripcionPlantilla = traductor.ObtenerTraducciones("OccursEveryWeekMultiple");

            return string.Format(descripcionPlantilla,
                                 entrada.ConfiguracionSemana.NumeroSemanas,
                                 entrada.FechaRepeticion.ToString(formatoFecha),
                                 entrada.FrecuenciaDiaria.HoraInicio.ToString(formatoHora, CultureInfo.InvariantCulture),
                                 entrada.FrecuenciaDiaria.HoraFin.ToString(formatoHora, CultureInfo.InvariantCulture),
                                 entrada.FrecuenciaDiaria.TiempoRepeticion,
                                 entrada.FechaActual.ToString(formatoFecha));
        }

        private string DescripcionCalculoRecurrenteMensualUnDiaUnaVez(EntradaDTO entrada, String formatoFecha, String formatoHora)
        {
            Traductor traductor = ObtenerTraductor(entrada.Idioma);
            string descripcionPlantilla = traductor.ObtenerTraducciones("OccursEveryMonthOneDayOnce");


            return string.Format(descripcionPlantilla,
                                 entrada.ConfiguracionMensual.DiaMes,
                                 entrada.ConfiguracionMensual.CantidadMeses,
                                 entrada.FrecuenciaDiaria.HoraInicio.ToString(formatoHora, CultureInfo.InvariantCulture),
                                 entrada.FechaActual.ToString(formatoFecha));
        }

        private string DescripcionCalculoRecurrenteMensualUnDiaVariasVeces(EntradaDTO entrada, String formatoFecha, String formatoHora)
        {
            Traductor traductor = ObtenerTraductor(entrada.Idioma);
            string descripcionPlantilla = traductor.ObtenerTraducciones("OccursEveryMonthOneDayMultiple");

            return string.Format(descripcionPlantilla,
                                 entrada.ConfiguracionMensual.DiaMes,
                                 entrada.ConfiguracionMensual.CantidadMeses,
                                 entrada.FrecuenciaDiaria.HoraInicio.ToString(formatoHora, CultureInfo.InvariantCulture),
                                 entrada.FrecuenciaDiaria.HoraFin.ToString(formatoHora, CultureInfo.InvariantCulture),
                                 entrada.FrecuenciaDiaria.TiempoRepeticion,
                                 entrada.FechaActual.ToString(formatoFecha));
        }

        private string DescripcionCalculoRecurrenteMensualVariosDiasUnaVez(EntradaDTO entrada, String formatoFecha, String formatoHora)
        {
            Traductor traductor = ObtenerTraductor(entrada.Idioma);
            string descripcionPlantilla = traductor.ObtenerTraducciones("OccursEveryMonthMultipleDaysOnce");

            return string.Format(descripcionPlantilla,
                                 traductor.TraducirFrecuenciaDia(entrada.ConfiguracionMensual.FrecuenciaDia),
                                 traductor.TraducirDiaSemana(entrada.ConfiguracionMensual.DiaSemana),
                                 entrada.ConfiguracionMensual.CantidadMeses,
                                 entrada.FrecuenciaDiaria.HoraInicio.ToString(formatoHora, CultureInfo.InvariantCulture),
                                 entrada.FechaActual.ToString(formatoFecha));
        }

        private string DescripcionCalculoRecurrenteMensualVariosDiasVariasVeces(EntradaDTO entrada, String formatoFecha, String formatoHora)
        {
            Traductor traductor = ObtenerTraductor(entrada.Idioma);
            string descripcionPlantilla = traductor.ObtenerTraducciones("OccursEveryMonthMultipleDaysMultiple");

            return string.Format(descripcionPlantilla,
                                 traductor.TraducirFrecuenciaDia(entrada.ConfiguracionMensual.FrecuenciaDia),
                                 traductor.TraducirDiaSemana(entrada.ConfiguracionMensual.DiaSemana),
                                 entrada.ConfiguracionMensual.CantidadMeses,
                                 entrada.FrecuenciaDiaria.HoraInicio.ToString(formatoHora, CultureInfo.InvariantCulture),
                                 entrada.FrecuenciaDiaria.HoraFin.ToString(formatoHora, CultureInfo.InvariantCulture),
                                 entrada.FrecuenciaDiaria.TiempoRepeticion,
                                 entrada.FechaActual.ToString(formatoFecha));
        }
    }
}