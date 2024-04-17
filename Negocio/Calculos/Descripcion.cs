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
                return $"Ocurre una vez. El programador se utilizará el {entrada.FechaRepeticion.ToString(("dd/MM/yyyy"))} a las " +
                    $"{entrada.FechaRepeticion.ToString(("HH:mm"))}";
            }
            else if (entrada.TipoCalculo == TiposCalculos.Recurrente)
            {
                switch (entrada.Ocurrencia)
                {
                    case OcurrenciaCalculos.Diaria:
                        if (entrada.FrecuenciaDiaria.TipoFrecuenciaDiaria == TiposCalculos.Una_vez)
                        {
                            return $"Ocurre diariamente. El programador se utilizará el {entrada.FechaRepeticion.ToString(("dd/MM/yyyy"))} a las {entrada.FrecuenciaDiaria.HoraInicio.ToString("HH:mm")}";
                        }
                        else
                        {
                            return $"Ocurre diariamente. El programador se utilizará el {entrada.FechaRepeticion.ToString(("dd/MM/yyyy"))} desde las {entrada.FrecuenciaDiaria.HoraInicio.ToString("HH:mm")}" +
                                $" a las {entrada.FrecuenciaDiaria.HoraFin.ToString("HH:mm")} cada {entrada.FrecuenciaDiaria.TiempoRepeticion} horas";
                        }
                    case OcurrenciaCalculos.Semanal:
                        if (entrada.FrecuenciaDiaria.TipoFrecuenciaDiaria == TiposCalculos.Una_vez)
                        {
                            return $"Ocurre semanalmente. El programador se utilizará el {entrada.FechaRepeticion.ToString(("dd/MM/yyyy"))} a las {entrada.FrecuenciaDiaria.HoraInicio.ToString("HH:mm")}";
                        }
                        else
                        {
                            return $"Ocurre semanalmente. El programador se utilizará el {entrada.FechaRepeticion.ToString(("dd/MM/yyyy"))} desde las {entrada.FrecuenciaDiaria.HoraInicio.ToString("HH:mm")}" +
                                $" a las {entrada.FrecuenciaDiaria.HoraFin.ToString("HH:mm")} cada {entrada.FrecuenciaDiaria.TiempoRepeticion} horas";
                        }
                    case OcurrenciaCalculos.Quincenal:
                        return $"Ocurre quincenalmente. El programador se utilizará el {entrada.FechaRepeticion.ToString(("dd/MM/yyyy"))} cada {entrada.FrecuenciaDiaria.TipoFrecuenciaDiaria} horas entre las" +
                            $" {entrada.FrecuenciaDiaria.HoraInicio.ToString("HH:mm:ss")} y las {entrada.FrecuenciaDiaria.HoraFin}";
                    default:
                        return null;
                }
            }
            return null;
        }
    }
}
