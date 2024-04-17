
using Negocio.EntitiesDTO;
using Negocio.Enums;
using Negocio.Managament;

namespace TestProject.Testing
{
    public class CalculosRecurrentesSemanalesTest
    {
        [Fact]
        public void Calcular_Datos_Salida_Correctos_Recurrente_Semanal_Una_Vez_Al_Dia()
        {
            //Arrenge
            var programador = new Programador();
            var fechaActual = DateTime.Now;
            var frecuenciaDiaria = new FrecuenciaDiariaDTO
            {
                TipoFrecuenciaDiaria = TiposCalculos.Una_vez,
                HoraInicio = new DateTime(fechaActual.Year, fechaActual.Month, fechaActual.Day, 15, 0, 0)
            };
            var configuracionSemanal = new ConfiguracionSemanalDTO
            {
                DiasSemana = new bool[7]
            };
            configuracionSemanal.DiasSemana[1] = true;

            var entrada = new EntradaDTO
            {
                FechaActual = fechaActual,
                TipoCalculo = TiposCalculos.Recurrente,
                Ocurrencia = OcurrenciaCalculos.Semanal,
                FechaRepeticion = new DateTime(2024, 04, 22),
                FrecuenciaDiaria = frecuenciaDiaria,
                ConfiguracionSemana = configuracionSemanal
            };
            var salida = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 04, 22, 15, 0, 0),
                Descripcion = $"Ocurre semanalmente. El programador se utilizará el 22/04/2024 a las 15:00",
                Tipo = TiposCalculos.Recurrente

            };

            //Act
            var salidaResultado = programador.Calcular(entrada);

            //Assert            
            Assert.Equal(salida.FechaEjecucion, salidaResultado.FechaEjecucion);
            Assert.Equal(salida.Tipo, salidaResultado.Tipo);
            Assert.Equal(salida.Descripcion, salidaResultado.Descripcion);
        }

        [Fact]
        public void Calcular_Datos_Salida_Correctos_Recurrente_Semanal_Varias_Horas_Al_Dia_Hora_Actual_Posterior_Hora_Inicio()
        {
            //Arrenge
            var programador = new Programador();
            var fechaActual = new DateTime(2024, 04, 16);
            var frecuenciaDiaria = new FrecuenciaDiariaDTO
            {
                TipoFrecuenciaDiaria = TiposCalculos.Recurrente,
                TiempoRepeticion = 2,
                HoraInicio = new DateTime(fechaActual.Year, fechaActual.Month, fechaActual.Day, 14, 0, 0),
                HoraFin = new DateTime(fechaActual.Year, fechaActual.Month, fechaActual.Day, 20, 0, 0)
            };
            var configuracionSemanal = new ConfiguracionSemanalDTO
            {
                DiasSemana = new bool[7]
            };
            configuracionSemanal.DiasSemana[1] = true;

            var entrada = new EntradaDTO
            {
                FechaActual = fechaActual,
                TipoCalculo = TiposCalculos.Recurrente,
                Ocurrencia = OcurrenciaCalculos.Semanal,
                FechaRepeticion = new DateTime(2024, 04, 22),
                FrecuenciaDiaria = frecuenciaDiaria,
                ConfiguracionSemana = configuracionSemanal
            };
            var salida = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 04, 22, 14, 0, 0),
                Descripcion = $"Ocurre semanalmente. El programador se utilizará el 22/04/2024 desde las 14:00 a las 20:00 cada 2 horas",
                Tipo = TiposCalculos.Recurrente
            };

            //Act
            var salidaResultado = programador.Calcular(entrada);

            //Assert            
            Assert.Equal(salida.FechaEjecucion, salidaResultado.FechaEjecucion);
            Assert.Equal(salida.Tipo, salidaResultado.Tipo);
            Assert.Equal(salida.Descripcion, salidaResultado.Descripcion);
        }

        [Fact]
        public void Calcular_Datos_Salida_Correctos_Recurrente_Semanal_Varias_Horas_Al_Dia_Hora_Actual_Anterior_Hora_Inicio()
        {
            //Arrenge
            var programador = new Programador();
            var fechaActual = new DateTime(2024, 04, 16);
            var frecuenciaDiaria = new FrecuenciaDiariaDTO
            {
                TipoFrecuenciaDiaria = TiposCalculos.Recurrente,
                TiempoRepeticion = 2,
                HoraInicio = new DateTime(fechaActual.Year, fechaActual.Month, fechaActual.Day, 14, 0, 0),
                HoraFin = new DateTime(fechaActual.Year, fechaActual.Month, fechaActual.Day, 20, 0, 0)
            };
            var configuracionSemanal = new ConfiguracionSemanalDTO
            {
                DiasSemana = new bool[7]
            };
            configuracionSemanal.DiasSemana[1] = true;

            var entrada = new EntradaDTO
            {
                FechaActual = fechaActual,
                TipoCalculo = TiposCalculos.Recurrente,
                Ocurrencia = OcurrenciaCalculos.Semanal,
                FechaRepeticion = new DateTime(2024, 04, 22),
                FrecuenciaDiaria = frecuenciaDiaria,
                ConfiguracionSemana = configuracionSemanal
            };
            var salida = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 04, 22, 14, 0, 0),
                Descripcion = $"Ocurre semanalmente. El programador se utilizará el 22/04/2024 desde las 14:00 a las 20:00 cada 2 horas",
                Tipo = TiposCalculos.Recurrente
            };

            //Act
            var salidaResultado = programador.Calcular(entrada);

            //Assert            
            Assert.Equal(salida.FechaEjecucion, salidaResultado.FechaEjecucion);
            Assert.Equal(salida.Tipo, salidaResultado.Tipo);
            Assert.Equal(salida.Descripcion, salidaResultado.Descripcion);
        }
    }
}
