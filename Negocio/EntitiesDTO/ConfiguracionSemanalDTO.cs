namespace Negocio.EntitiesDTO
{
    public class ConfiguracionSemanalDTO
    {
        public int NumeroSemanas { get; set; }
        public bool[] DiasSemana { get; set; } = new bool[7];
    }
}
