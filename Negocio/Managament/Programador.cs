using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Calculos;
using Negocio.EntitiesDTO;
using Negocio.Enums;



namespace Negocio.Managament
{
    public class Programador
    {
        private CalculosOnce calculadorOnce = new CalculosOnce();
        private CalculosRecurring calculadorRecurring = new CalculosRecurring();
        public SalidaDTO Calcular(EntradaDTO entrada, FrecuenciaDiariaDTO frecuencia)
        {            
            return calculadorOnce.CalcularSoloUnaVez(entrada) ?? calculadorRecurring.CalcularRecurrente(entrada, frecuencia);
        }               
    }
}
