﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.EntitiesDTO;
using Negocio.Enums;

namespace Negocio.Calculos
{
    public class CalculosRecurrentes
    {
        public SalidaDTO CalcularRecurrente(EntradaDTO entrada)
        {
            if (entrada.TipoCalculo != TiposCalculos.Recurrente)
            {
                return null;
            }
            return new SalidaDTO()
            {
                Tipo = entrada.TipoCalculo,
                FechaEjecucion = FechaEjecucionRepeticionRecurrente(entrada),
                Descripcion = ObtenerDescripcion(entrada)
            };
        }
        private DateTime FechaEjecucionRepeticionRecurrente(EntradaDTO entrada)
        {
            DateTime fechaRepeticion = new DateTime();

            if (entrada.Ocurrencia == OcurrenciaCalculos.Diaria)
            {  
                return new CalculosRecurrentesDiarios().calculoFechaEjecucion(entrada);
            }
            else if (entrada.Ocurrencia == OcurrenciaCalculos.Semanal)
            {        
                return new CalculosRecurrentesSemanales().calculoFechaEjecucion(entrada);                
            }
            else if (entrada.Ocurrencia == OcurrenciaCalculos.Quincenal)
            {
                fechaRepeticion = entrada.FechaActual.AddDays(15);
            }

            return fechaRepeticion;
        }

        private string ObtenerDescripcion(EntradaDTO entrada)
        {
            if (entrada.Ocurrencia == OcurrenciaCalculos.Diaria)
            {
                CalculosRecurrentesDiarios calculo = new CalculosRecurrentesDiarios();

                return calculo.obtenerDescripcion(entrada);
            }
            if (entrada.Ocurrencia == OcurrenciaCalculos.Semanal)
            {
                CalculosRecurrentesSemanales calculo = new CalculosRecurrentesSemanales();

                return calculo.obtenerDescripcion(entrada);
            }

            if (entrada.Ocurrencia == OcurrenciaCalculos.Quincenal)
            {
                return $"Ocurre quincenalmente. El programador se utilizará el {entrada.FechaRepeticion.ToString(("dd/MM/yyyy"))} cada {entrada.FrecuenciaDiaria.TipoFrecuenciaDiaria} horas entre las" +
                    $" {entrada.FrecuenciaDiaria.HoraInicio.ToString("HH:mm:ss")} y las {entrada.FrecuenciaDiaria.HoraFin}";
            }
            
            return null;
        }

        private DateTime HoraSiguienteEjecucion(EntradaDTO entrada)
        {
            int tiempoAdd = entrada.FrecuenciaDiaria.TiempoRepeticion;
            return entrada.FrecuenciaDiaria.HoraInicio.AddHours(tiempoAdd);
        }

    }
}
