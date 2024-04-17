using Negocio.Calculos;
using Negocio.EntitiesDTO;



namespace Negocio.Managament
{
    public class Programador
    {
        private CalculosUnaVez calculadorOnce = new CalculosUnaVez();
        private CalculosRecurrentes calculadorRecurring = new CalculosRecurrentes();
        public SalidaDTO Calcular(EntradaDTO entrada)
        {
            return calculadorOnce.CalcularSoloUnaVez(entrada) ?? calculadorRecurring.CalcularRecurrente(entrada);
        }
    }
}