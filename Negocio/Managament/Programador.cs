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
        private CalculosUnaVez calculadorOnce = new CalculosUnaVez();
        private CalculosRecurrentes calculadorRecurring = new CalculosRecurrentes();
        public SalidaDTO Calcular(EntradaDTO entrada)
        {
            return calculadorOnce.CalcularSoloUnaVez(entrada) ?? calculadorRecurring.CalcularRecurrente(entrada);
        }
    }
}