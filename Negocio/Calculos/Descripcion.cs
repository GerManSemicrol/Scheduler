using System.Globalization;
using Negocio.EntitiesDTO;
using Negocio.Enums;

namespace Negocio.Calculos
{
    public class Descripcion
    {
        public string ObtenerDescripcion(EntradaDTO entrada)
        {
            if (entrada.TipoCalculo == TiposCalculos.Una_vez)
            {
                return new Descripcion().DescripcionCalculoUnavez(entrada);
            }
            else if (entrada.TipoCalculo == TiposCalculos.Recurrente)
            {
                switch (entrada.Ocurrencia)
                {
                    case OcurrenciaCalculos.Diaria:
                        if (entrada.FrecuenciaDiaria.TipoFrecuenciaDiaria == TiposCalculos.Una_vez)
                        {
                            return new Descripcion().DescripcionCalculoRecurrenteDiarioUnaVez(entrada);
                        }
                        else
                        {
                            return new Descripcion().DescripcionCalculoRecurrenteDiarioVariasVeces(entrada);
                        }
                    case OcurrenciaCalculos.Semanal:
                        if (entrada.FrecuenciaDiaria.TipoFrecuenciaDiaria == TiposCalculos.Una_vez)
                        {
                            return new Descripcion().DescripcionCalculoRecurrenteSemanalUnaVez(entrada);
                        }
                        else
                        {
                            return new Descripcion().DescripcionCalculoRecurrenteSemanalVariasVeces(entrada);
                        }
                    case OcurrenciaCalculos.Mensual:
                        if (entrada.ConfiguracionMensual.Tipo[0])
                        {

                            if (entrada.FrecuenciaDiaria.TipoFrecuenciaDiaria == TiposCalculos.Una_vez)
                            {
                                return new Descripcion().DescripcionCalculoRecurrenteMensualUnDiaUnaVez(entrada);
                            }
                            return new Descripcion().DescripcionCalculoRecurrenteMensualUnDiaVariasVeces(entrada);

                        }
                        else
                        {
                            if (entrada.FrecuenciaDiaria.TipoFrecuenciaDiaria == TiposCalculos.Una_vez)
                            {
                                return new Descripcion().DescripcionCalculoRecurrenteMensualVariosDiasUnaVez(entrada);
                            }
                            return new Descripcion().DescripcionCalculoRecurrenteMensualVariosDiasVariasVeces(entrada);
                        }
                    default:
                        return null;
                }
            }
            return null;
        }

        private string DescripcionCalculoUnavez(EntradaDTO entrada)
        {
            if (entrada.Idioma == Idiomas.UK)
            {
                return $"Occurs once. Schedule will be used on {entrada.FechaRepeticion.ToString("dd/MM/yyyy")} at " +
                   $"{entrada.FechaRepeticion.ToString("hh:mm tt", CultureInfo.InvariantCulture)}";
            }
            else if (entrada.Idioma == Idiomas.US)
            {
                return $"Occurs once. Schedule will be used on {entrada.FechaRepeticion.ToString("MM/dd/yyyy")} at " +
                   $"{entrada.FechaRepeticion.ToString("hh:mm tt", CultureInfo.InvariantCulture)}";
            }
            return $"Ocurre una vez. El programador se utilizará el {entrada.FechaRepeticion.ToString("dd/MM/yyyy")} a las " +
                   $"{entrada.FechaRepeticion.ToString("HH:mm")}";
        }

        private string DescripcionCalculoRecurrenteDiarioUnaVez(EntradaDTO entrada)
        {
            if (entrada.Idioma == Idiomas.UK)
            {
                return $"Occurs every day. Schedule will be used on {entrada.FechaRepeticion.ToString("dd/MM/yyyy")} at " +
                   $"{entrada.FrecuenciaDiaria.HoraInicio.ToString("hh:mm tt", CultureInfo.InvariantCulture)} starting on {entrada.FechaActual.ToString("dd/MM/yyyy")}";
            }
            else if (entrada.Idioma == Idiomas.US)
            {
                return $"Occurs every day. Schedule will be used on {entrada.FechaRepeticion.ToString("MM/dd/yyyy")} at " +
                   $"{entrada.FrecuenciaDiaria.HoraInicio.ToString("hh:mm tt", CultureInfo.InvariantCulture)} starting on {entrada.FechaActual.ToString("MM/dd/yyyy")}";
            }
            return $"Ocurre diariamente. El programador se utilizará el {entrada.FechaRepeticion.ToString("dd/MM/yyyy")} a las {entrada.FrecuenciaDiaria.HoraInicio.ToString("HH:mm")}";
        }

        private string DescripcionCalculoRecurrenteDiarioVariasVeces(EntradaDTO entrada)
        {
            if (entrada.Idioma == Idiomas.UK)
            {
                return $"Occurs every day. Schedule will be used on {entrada.FechaRepeticion.ToString("dd/MM/yyyy")} " +
                    $"between {entrada.FrecuenciaDiaria.HoraInicio.ToString("hh:mm tt", CultureInfo.InvariantCulture)} " +
                    $"and {entrada.FrecuenciaDiaria.HoraFin.ToString("hh:mm tt", CultureInfo.InvariantCulture)} every {entrada.FrecuenciaDiaria.TiempoRepeticion} hours " +
                    $"starting on {entrada.FechaActual.ToString("dd/MM/yyyy")}";
            }
            else if (entrada.Idioma == Idiomas.US)
            {
                return $"Occurs every day. Schedule will be used on {entrada.FechaRepeticion.ToString("MM/dd/yyyy")} " +
                    $"between {entrada.FrecuenciaDiaria.HoraInicio.ToString("hh:mm tt", CultureInfo.InvariantCulture)} " +
                    $"and {entrada.FrecuenciaDiaria.HoraFin.ToString("hh:mm tt", CultureInfo.InvariantCulture)} every {entrada.FrecuenciaDiaria.TiempoRepeticion} hours " +
                    $"starting on {entrada.FechaActual.ToString("MM/dd/yyyy")}";
            }
            return $"Ocurre diariamente. El programador se utilizará el {entrada.FechaRepeticion.ToString("dd/MM/yyyy")} desde las {entrada.FrecuenciaDiaria.HoraInicio.ToString("HH:mm")}" +
                   $" a las {entrada.FrecuenciaDiaria.HoraFin.ToString("HH:mm")} cada {entrada.FrecuenciaDiaria.TiempoRepeticion} horas";
        }

        private string DescripcionCalculoRecurrenteSemanalUnaVez(EntradaDTO entrada)
        {
            if (entrada.Idioma == Idiomas.UK)
            {
                return $"Occurs every {entrada.ConfiguracionSemana.NumeroSemanas} week/s. Schedule will be used on {entrada.FechaRepeticion.ToString("dd/MM/yyyy")} " +
                       $"at {entrada.FrecuenciaDiaria.HoraInicio.ToString("hh:mm tt", CultureInfo.InvariantCulture)}";
            }
            else if (entrada.Idioma == Idiomas.US)
            {
                return $"Occurs every {entrada.ConfiguracionSemana.NumeroSemanas} week/s. Schedule will be used on {entrada.FechaRepeticion.ToString("MM/dd/yyyy")} " +
                       $"at {entrada.FrecuenciaDiaria.HoraInicio.ToString("hh:mm tt", CultureInfo.InvariantCulture)}";
            }
            return $"Ocurre cada {entrada.ConfiguracionSemana.NumeroSemanas} semana/s. El programador se utilizará el {entrada.FechaRepeticion.ToString("dd/MM/yyyy")}" +
                   $" a las {entrada.FrecuenciaDiaria.HoraInicio.ToString("HH:mm")}";
        }

        private string DescripcionCalculoRecurrenteSemanalVariasVeces(EntradaDTO entrada)
        {
            if (entrada.Idioma == Idiomas.UK)
            {
                return $"Occurs every {entrada.ConfiguracionSemana.NumeroSemanas} week/s. Schedule will be used on {entrada.FechaRepeticion.ToString("dd/MM/yyyy")} " +
                       $"between {entrada.FrecuenciaDiaria.HoraInicio.ToString("hh:mm tt", CultureInfo.InvariantCulture)} " +
                       $"and {entrada.FrecuenciaDiaria.HoraFin.ToString("hh:mm tt", CultureInfo.InvariantCulture)} every {entrada.FrecuenciaDiaria.TiempoRepeticion} hours " +
                       $"starting on {entrada.FechaActual.ToString("dd/MM/yyyy")}";
            }
            else if (entrada.Idioma == Idiomas.US)
            {
                return $"Occurs every {entrada.ConfiguracionSemana.NumeroSemanas} week/s. Schedule will be used on {entrada.FechaRepeticion.ToString("MM/dd/yyyy")} " +
                       $"between {entrada.FrecuenciaDiaria.HoraInicio.ToString("hh:mm tt", CultureInfo.InvariantCulture)} " +
                       $"and {entrada.FrecuenciaDiaria.HoraFin.ToString("hh:mm tt", CultureInfo.InvariantCulture)} every {entrada.FrecuenciaDiaria.TiempoRepeticion} hours " +
                       $"starting on {entrada.FechaActual.ToString("MM/dd/yyyy")}";
            }
            return $"Ocurre cada {entrada.ConfiguracionSemana.NumeroSemanas} semana/s. El programador se utilizará el {entrada.FechaRepeticion.ToString("dd/MM/yyyy")} " +
                   $"desde las {entrada.FrecuenciaDiaria.HoraInicio.ToString("HH:mm")} " +
                   $"a las {entrada.FrecuenciaDiaria.HoraFin.ToString("HH:mm")} cada {entrada.FrecuenciaDiaria.TiempoRepeticion} horas";
        }

        private string DescripcionCalculoRecurrenteMensualUnDiaUnaVez(EntradaDTO entrada)
        {
            if (entrada.Idioma == Idiomas.UK)
            {
                return $"Occurs on day {entrada.ConfiguracionMensual.DiaMes} every {entrada.ConfiguracionMensual.CantidadMeses} month/s. Schedule will be used on day at " +
                       $"{entrada.FrecuenciaDiaria.HoraInicio.ToString("hh:mm tt", CultureInfo.InvariantCulture)} " +
                       $"starting on {entrada.FechaActual.ToString("dd/MM/yyyy")}";
            }
            else if (entrada.Idioma == Idiomas.US)
            {
                return $"Occurs on day {entrada.ConfiguracionMensual.DiaMes} every {entrada.ConfiguracionMensual.CantidadMeses} month/s. Schedule will be used on day at " +
                       $"{entrada.FrecuenciaDiaria.HoraInicio.ToString("hh:mm tt", CultureInfo.InvariantCulture)} " +
                       $"starting on {entrada.FechaActual.ToString("MM/dd/yyyy")}";
            }
            return $"Ocurre el día {entrada.ConfiguracionMensual.DiaMes} cada {entrada.ConfiguracionMensual.CantidadMeses} meses. El programador se utilizará una vez al día a las " +
                   $"{entrada.FrecuenciaDiaria.HoraInicio.ToString("HH:mm:ss")}";
        }
        private string DescripcionCalculoRecurrenteMensualUnDiaVariasVeces(EntradaDTO entrada)
        {
            if (entrada.Idioma == Idiomas.UK)
            {
                return $"Occurs on day {entrada.ConfiguracionMensual.DiaMes} every {entrada.ConfiguracionMensual.CantidadMeses} month/s. Schedule will be used on day between " +
                       $"{entrada.FrecuenciaDiaria.HoraInicio.ToString("hh:mm tt", CultureInfo.InvariantCulture)} " +
                       $"and {entrada.FrecuenciaDiaria.HoraFin.ToString("hh:mm tt", CultureInfo.InvariantCulture)} every {entrada.FrecuenciaDiaria.TiempoRepeticion} hours " +
                       $"starting on {entrada.FechaActual.ToString("dd/MM/yyyy")}";
            }
            else if (entrada.Idioma == Idiomas.US)
            {
                return $"Occurs on day {entrada.ConfiguracionMensual.DiaMes} every {entrada.ConfiguracionMensual.CantidadMeses} month/s. Schedule will be used on day between " +
                      $"{entrada.FrecuenciaDiaria.HoraInicio.ToString("hh:mm tt", CultureInfo.InvariantCulture)} " +
                      $"and {entrada.FrecuenciaDiaria.HoraFin.ToString("hh:mm tt", CultureInfo.InvariantCulture)} every {entrada.FrecuenciaDiaria.TiempoRepeticion} hours " +
                      $"starting on {entrada.FechaActual.ToString("MM/dd/yyyy")}";
            }
            return $"Ocurre el día {entrada.ConfiguracionMensual.DiaMes} cada {entrada.ConfiguracionMensual.CantidadMeses} meses. " +
                   $"El programador se utilizará cada {entrada.FrecuenciaDiaria.TiempoRepeticion} hora/s entre las " +
                   $"{entrada.FrecuenciaDiaria.HoraInicio.ToString("HH:mm:ss")} y las {entrada.FrecuenciaDiaria.HoraFin.ToString("HH:mm:ss")}";
        }

        private string DescripcionCalculoRecurrenteMensualVariosDiasUnaVez(EntradaDTO entrada)
        {
            if (entrada.Idioma == Idiomas.UK)
            {
                return $"Occurs the {entrada.ConfiguracionMensual.FrecuenciaDia} {entrada.ConfiguracionMensual.DiaSemana} of every {entrada.ConfiguracionMensual.CantidadMeses} month/s. " +
                       $"Schedule will be used on day at {entrada.FrecuenciaDiaria.HoraInicio.ToString("hh:mm tt", CultureInfo.InvariantCulture)} " +
                       $"starting on {entrada.FechaActual.ToString("dd/MM/yyyy")}";
            }
            else if (entrada.Idioma == Idiomas.US)
            {
                return $"Occurs the {entrada.ConfiguracionMensual.FrecuenciaDia} {entrada.ConfiguracionMensual.DiaSemana} of every {entrada.ConfiguracionMensual.CantidadMeses} month/s. " +
                       $"Schedule will be used on day at {entrada.FrecuenciaDiaria.HoraInicio.ToString("hh:mm tt", CultureInfo.InvariantCulture)} " +
                       $"starting on {entrada.FechaActual.ToString("MM/dd/yyyy")}";
            }
            return $"Ocurre el {entrada.ConfiguracionMensual.FrecuenciaDia} {entrada.ConfiguracionMensual.DiaSemana} cada {entrada.ConfiguracionMensual.CantidadMeses} meses. " +
                   $"El programador se utilizará una vez al día a las {entrada.FrecuenciaDiaria.HoraInicio.ToString("HH:mm:ss")}";
        }

        private string DescripcionCalculoRecurrenteMensualVariosDiasVariasVeces(EntradaDTO entrada)
        {
            if (entrada.Idioma == Idiomas.UK)
            {
                return $"Occurs the {entrada.ConfiguracionMensual.FrecuenciaDia} {entrada.ConfiguracionMensual.DiaSemana} of every {entrada.ConfiguracionMensual.CantidadMeses} month/s. " +
                       $"Schedule will be used on day between {entrada.FrecuenciaDiaria.HoraInicio.ToString("hh:mm tt", CultureInfo.InvariantCulture)} " +
                       $"and {entrada.FrecuenciaDiaria.HoraFin.ToString("hh:mm tt", CultureInfo.InvariantCulture)} every {entrada.FrecuenciaDiaria.TiempoRepeticion} hours " +
                       $"starting on {entrada.FechaActual.ToString("dd/MM/yyyy")}";
            }
            else if (entrada.Idioma == Idiomas.US)
            {
                return $"Occurs the {entrada.ConfiguracionMensual.FrecuenciaDia} {entrada.ConfiguracionMensual.DiaSemana} of every {entrada.ConfiguracionMensual.CantidadMeses} month/s. " +
                       $"Schedule will be used on day between {entrada.FrecuenciaDiaria.HoraInicio.ToString("hh:mm tt", CultureInfo.InvariantCulture)} " +
                       $"and {entrada.FrecuenciaDiaria.HoraFin.ToString("hh:mm tt", CultureInfo.InvariantCulture)} every {entrada.FrecuenciaDiaria.TiempoRepeticion} hours " +
                       $"starting on {entrada.FechaActual.ToString("MM/dd/yyyy")}";
            }
            return $"Ocurre el {entrada.ConfiguracionMensual.FrecuenciaDia} {entrada.ConfiguracionMensual.DiaSemana} cada {entrada.ConfiguracionMensual.CantidadMeses} meses. " +
                   $"El programador se utilizará cada {entrada.FrecuenciaDiaria.TiempoRepeticion} hora/s entre las " +
                   $"{entrada.FrecuenciaDiaria.HoraInicio.ToString("HH:mm:ss")} y las {entrada.FrecuenciaDiaria.HoraFin.ToString("HH:mm:ss")}";
        }
    }
}
