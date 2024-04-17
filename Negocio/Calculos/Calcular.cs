using Negocio.EntitiesDTO;

namespace Negocio.Calculos
{
    internal class Calcular
    {
        private CalculosUnaVez calculadorOnce = new CalculosUnaVez();
        private CalculosRecurrentes calculadorRecurring = new CalculosRecurrentes();
        internal SalidaDTO Calculo(EntradaDTO entrada)
        {
            return calculadorOnce.CalcularSoloUnaVez(entrada) ?? calculadorRecurring.CalcularRecurrente(entrada);
        }
    }
}
