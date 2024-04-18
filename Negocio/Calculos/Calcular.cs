using Negocio.EntitiesDTO;

namespace Negocio.Calculos
{
    public class Calcular
    {
        private CalculosUnaVez calculadorOnce = new CalculosUnaVez();
        private CalculosRecurrentes calculadorRecurring = new CalculosRecurrentes();
        public SalidaDTO Calculo(EntradaDTO entrada)
        {
            return calculadorOnce.CalcularSoloUnaVez(entrada) ?? calculadorRecurring.CalcularRecurrente(entrada);
        }
    }
}