using FluentAssertions;
using Negocio.Calculos;
using Negocio.EntitiesDTO;
using Negocio.Enums;
using Negocio.Managament;

namespace TestProject.Testing
{
    public class CalculosRecurrentesSemanalesTest
    {
        [Fact]
        public void CalculoFechaEjecucion_DiaActualMartes_DiaEjecucionProximoMartes()
        {
            //Arrange
            var calculadora = new CalculosRecurrentesSemanales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 4, 17),
                ConfiguracionSemana = new ConfiguracionSemanalDTO
                {
                    DiasSemana = new bool[] { false, true, false, false, false, false, false }
                },
                FrecuenciaDiaria = new FrecuenciaDiariaDTO
                {
                    HoraInicio = new DateTime(2024, 4, 17, 9, 0, 0),
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 22, 9, 0, 0)
            };

            //Act
            var salidaResultado = calculadora.CalculoFechaEjecucion(entrada);

            //Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void Calcular_HoraEjecucion_HoraActualAnterior_HoraDeInicio()
        {
            //Arrange
            var calculo = new CalculosRecurrentesSemanales();
            var entrada = new EntradaDTO
            {
                FrecuenciaDiaria = new FrecuenciaDiariaDTO
                {
                    HoraInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 20, 0, 0),
                }
            };

            //Act
            var salidaEsperada = calculo.CalculoHoraEjecucion(entrada);

            //Assert
            salidaEsperada.Should().Be(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 20, 0, 0));
        }
        [Fact]
        public void Calcular_HoraEjecucion_HoraActualPosterior_HoraDeInicio()
        {
            //Arrange
            var calculo = new CalculosRecurrentesSemanales();
            var entrada = new EntradaDTO
            {
                FrecuenciaDiaria = new FrecuenciaDiariaDTO
                {
                    HoraInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0)
                }
            };

            //Act
            var salidaEsperada = calculo.CalculoHoraEjecucion(entrada);

            //Assert
            salidaEsperada.Should().Be(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0));
        }

        [Fact]
        public void Calcular_Datos_Salida_Correctos_Recurrente_Semanal_Una_Vez_Al_Dia()
        {
            //Arrenge
            var programador = new Programador();
            var fechaActual = new DateTime(2024, 04, 28);
            var frecuenciaDiaria = new FrecuenciaDiariaDTO
            {
                TipoFrecuenciaDiaria = TiposCalculos.Una_vez,
                HoraInicio = new DateTime(fechaActual.Year, fechaActual.Month, fechaActual.Day, 15, 0, 0)
            };
            var configuracionSemanal = new ConfiguracionSemanalDTO
            {
                DiasSemana = new bool[7],
                NumeroSemanas = 2
            };
            configuracionSemanal.DiasSemana[1] = true;

            var entrada = new EntradaDTO
            {
                FechaActual = fechaActual,
                Idioma = Idiomas.ESP,
                TipoCalculo = TiposCalculos.Recurrente,
                Ocurrencia = OcurrenciaCalculos.Semanal,
                FechaRepeticion = new DateTime(2024, 04, 28),
                FrecuenciaDiaria = frecuenciaDiaria,
                ConfiguracionSemana = configuracionSemanal,
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 04, 29, 15, 0, 0),
                Descripcion = $"Ocurre cada 2 semana/s. El programador se utilizará el 28/04/2024 a las 15:00",
                Tipo = TiposCalculos.Recurrente

            };

            //Act
            var salidaResultado = programador.Calcular(entrada);

            //Assert
            salidaResultado.Tipo.Should().Be(salidaEsperada.Tipo);
            salidaResultado.Descripcion.Should().Be(salidaEsperada.Descripcion);
            salidaResultado.FechaEjecucion.Should().Be(salidaEsperada.FechaEjecucion);
        }
    }
}