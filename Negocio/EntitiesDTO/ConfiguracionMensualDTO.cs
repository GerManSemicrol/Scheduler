using Negocio.Enums;

namespace Negocio.EntitiesDTO
{
    public class ConfiguracionMensualDTO
    {
        public bool[] Tipo { get; set; } = new bool[2];
        public int DiaMes { get; set; }
        public int CantidadMeses { get; set; }
        public FrecuenciasDia FrecuenciaDia { get; set; }
        public DiasSemana DiaSemana { get; set; }    
    }
}
