using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Managament
{
    public class Managament
    {
        public string unaVez(string fechaEjecucion)
        {            
            return fechaEjecucion;
        }

        public string unaVezDescripcion(string fechaActual, string fechaEjecucion)
        {
            return ($"Ocurre una vez. El programador se utilizará el {fechaEjecucion} a partir del {fechaActual}");
        }

    }
}
