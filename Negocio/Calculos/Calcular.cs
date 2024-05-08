using Negocio.EntitiesDTO;

namespace Negocio.Calculos
{
    public class Calcular
    {
        private CalculosUnaVez calculadorUnaVez = new CalculosUnaVez();
        private CalculosRecurrentes calculadorRecurrente = new CalculosRecurrentes();
        public SalidaDTO Calculo(EntradaDTO entrada)
        {
            return calculadorUnaVez.CalcularSoloUnaVez(entrada) ?? calculadorRecurrente.CalcularRecurrente(entrada);
        }
    }
}