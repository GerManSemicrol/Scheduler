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
                        return new Descripcion().DescripcionCalculoRecurrenteMensual(entrada);
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

        private string DescripcionCalculoRecurrenteMensual(EntradaDTO entrada)
        {
            return $"Ocurre mensualmente. El programador se utilizará el {entrada.FechaRepeticion.ToString(("dd/MM/yyyy"))} cada {entrada.FrecuenciaDiaria.TipoFrecuenciaDiaria} horas entre las" +
                            $" {entrada.FrecuenciaDiaria.HoraInicio.ToString("HH:mm:ss")} y las {entrada.FrecuenciaDiaria.HoraFin}";
        }
    }
}
