using Negocio.Calculos;
using Negocio.EntitiesDTO;



namespace Negocio.Managament
{
    public class Programador
    {
        private Calcular calcular = new Calcular();        
        public SalidaDTO Calcular(EntradaDTO entrada)
        {
            return calcular.Calculo(entrada);            
        }
    }
}