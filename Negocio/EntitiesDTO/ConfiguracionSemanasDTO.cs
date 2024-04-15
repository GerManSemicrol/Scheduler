using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Enums;

namespace Negocio.EntitiesDTO
{
    public class ConfiguracionSemanasDTO
    {
        public int NumeroSemanas { get; set; }
        public bool[] DiasSemana { get; set; }
        public ConfiguracionSemanasDTO()
        {            
            DiasSemana = new bool[7];
        }

        public bool EstaActivo(DiaSemana dia)
        {
            return DiasSemana[(int)dia];
        }

        public void ActivarDia(DiaSemana dia)
        {
            DiasSemana[(int)dia] = true;
        }

        public void DesactivarDia(DiaSemana dia)
        {
            DiasSemana[(int)dia] = false;
        }
    }
}
