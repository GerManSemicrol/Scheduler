using Negocio.EntitiesDTO;
using Negocio.Enums;

namespace Negocio.Calculos
{
    public class CalculosUnaVez
    {
        public SalidaDTO CalcularSoloUnaVez(EntradaDTO entrada)
        {
            if (entrada.TipoCalculo != TiposCalculos.Una_vez)
            {
                return null;
            }
            return new SalidaDTO()
            {
                Tipo = entrada.TipoCalculo,
                FechaEjecucion = entrada.FechaRepeticion,
                Descripcion = new Descripcion().ObtenerDescripcion(entrada)
            };
        }        
    }
}
