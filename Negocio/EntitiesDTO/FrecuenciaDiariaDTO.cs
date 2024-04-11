﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Enums;

namespace Negocio.EntitiesDTO
{
    public class FrecuenciaDiariaDTO
    {
        public TiposCalculos TiposCalculos { get; set; }
        public int Horas { get; set; }
        public int Minutos { get; set; }
        public int Segundos { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }   

    }
}