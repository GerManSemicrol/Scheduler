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
            return $"Ocurre una vez. El programador se utilizará el {entrada.FechaRepeticion.ToString(("dd/MM/yyyy"))} a las " +
                    $"{entrada.FechaRepeticion.ToString(("HH:mm"))}";
        }

        private string DescripcionCalculoRecurrenteDiarioUnaVez(EntradaDTO entrada)
        {
            return $"Ocurre diariamente. El programador se utilizará el {entrada.FechaRepeticion.ToString(("dd/MM/yyyy"))} a las {entrada.FrecuenciaDiaria.HoraInicio.ToString("HH:mm")}";
        }

        private string DescripcionCalculoRecurrenteDiarioVariasVeces(EntradaDTO entrada)
        {
            return $"Ocurre diariamente. El programador se utilizará el {entrada.FechaRepeticion.ToString(("dd/MM/yyyy"))} desde las {entrada.FrecuenciaDiaria.HoraInicio.ToString("HH:mm")}" +
                                $" a las {entrada.FrecuenciaDiaria.HoraFin.ToString("HH:mm")} cada {entrada.FrecuenciaDiaria.TiempoRepeticion} horas";
        }

        private string DescripcionCalculoRecurrenteSemanalUnaVez(EntradaDTO entrada)
        {
            return $"Ocurre cada {entrada.ConfiguracionSemana.NumeroSemanas} semana/s. El programador se utilizará el {entrada.FechaRepeticion.ToString(("dd/MM/yyyy"))}" +
                                $" a las {entrada.FrecuenciaDiaria.HoraInicio.ToString("HH:mm")}";
        }

        private string DescripcionCalculoRecurrenteSemanalVariasVeces(EntradaDTO entrada)
        {
            return $"Ocurre cada {entrada.ConfiguracionSemana.NumeroSemanas} semana/s. El programador se utilizará el {entrada.FechaRepeticion.ToString(("dd/MM/yyyy"))}" +
                                $" desde las {entrada.FrecuenciaDiaria.HoraInicio.ToString("HH:mm")}" +
                                $" a las {entrada.FrecuenciaDiaria.HoraFin.ToString("HH:mm")} cada {entrada.FrecuenciaDiaria.TiempoRepeticion} horas";
        }

        private string DescripcionCalculoRecurrenteMensualUnDiaUnaVez(EntradaDTO entrada)
        {
            return $"Ocurre el día {entrada.ConfiguracionMensual.DiaMes} cada {entrada.ConfiguracionMensual.CantidadMeses} meses. El programador se utilizará una vez al día a las " +
                            $"{entrada.FrecuenciaDiaria.HoraInicio.ToString("HH:mm:ss")}";
        }
        private string DescripcionCalculoRecurrenteMensualUnDiaVariasVeces(EntradaDTO entrada)
        {
            return $"Ocurre el día {entrada.ConfiguracionMensual.DiaMes} cada {entrada.ConfiguracionMensual.CantidadMeses} meses." +
                $" El programador se utilizará cada {entrada.FrecuenciaDiaria.TiempoRepeticion} hora/s entre las" +
                            $" {entrada.FrecuenciaDiaria.HoraInicio.ToString("HH:mm:ss")} y las {entrada.FrecuenciaDiaria.HoraFin.ToString("HH:mm:ss")}";
        }

        private string DescripcionCalculoRecurrenteMensualVariosDiasUnaVez(EntradaDTO entrada)
        {
            return $"Ocurre el {entrada.ConfiguracionMensual.FrecuenciaDia} {entrada.ConfiguracionMensual.DiaSemana} cada {entrada.ConfiguracionMensual.CantidadMeses} meses." +
                $" El programador se utilizará una vez al día a las {entrada.FrecuenciaDiaria.HoraInicio.ToString("HH:mm:ss")}";
        }

        private string DescripcionCalculoRecurrenteMensualVariosDiasVariasVeces(EntradaDTO entrada)
        {
            return $"Ocurre el {entrada.ConfiguracionMensual.FrecuenciaDia} {entrada.ConfiguracionMensual.DiaSemana} cada {entrada.ConfiguracionMensual.CantidadMeses} meses." +
                $" El programador se utilizará cada {entrada.FrecuenciaDiaria.TiempoRepeticion} hora/s entre las" +
                            $" {entrada.FrecuenciaDiaria.HoraInicio.ToString("HH:mm:ss")} y las {entrada.FrecuenciaDiaria.HoraFin.ToString("HH:mm:ss")}";
        }
    }
}
