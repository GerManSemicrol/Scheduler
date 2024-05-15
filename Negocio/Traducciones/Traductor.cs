using System;
using System.Collections.Generic;
using Negocio.Enums;

namespace Negocio.Traducciones
{
    public abstract class Traductor
    {
        protected Dictionary<string, string> traducciones;

        public Traductor()
        {
            traducciones = new Dictionary<string, string>();
            InicializarTraducciones();
        }

        protected abstract void InicializarTraducciones();

        public string ObtenerTraducciones(string clave)
        {
            if (traducciones.TryGetValue(clave, out string traduccion))
            {
                return traduccion;
            }
            return string.Empty;
        }

        public string TraducirDiaSemana(DiasSemana dia)
        {
            return ObtenerTraducciones(dia.ToString());
        }

        public string TraducirFrecuenciaDia(FrecuenciasDia frecuencia)
        {
            return ObtenerTraducciones(frecuencia.ToString());
        }
    }
}
