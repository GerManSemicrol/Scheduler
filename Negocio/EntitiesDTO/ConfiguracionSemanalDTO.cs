using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Enums;

namespace Negocio.EntitiesDTO
{
    public class ConfiguracionSemanalDTO
    {
        public int NumeroSemanas { get; set; }
        public bool[] DiasSemana { get; set; } = new bool[7];
    }
}
