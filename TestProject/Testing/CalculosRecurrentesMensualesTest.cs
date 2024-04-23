using FluentAssertions;
using Negocio.Calculos;
using Negocio.EntitiesDTO;

namespace TestProject.Testing
{
    public class CalculosRecurrentesMensualesTest
    {
        [Fact]
        public void CalculoFechaEjecucion_Recurrente_Mensual_DiaAnterior_FechaActual()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 31),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { true },
                    DiaMes = 30
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 30)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void CalculoFechaEjecucion_Recurrente_Mensual_DiaAnterior_FechaActual_Febrero()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 1, 31),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { true },
                    DiaMes = 30
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 2, 29)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void CalculoFechaEjecucion_Recurrente_Mensual_DiaPosterior_FechaActual()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 4, 22),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { true },
                    DiaMes = 25
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 25)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void CalculoFechaEjecucion_Recurrente_Mensual_DiaIgual_FechaActual()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 4, 22),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { true },
                    DiaMes = 22
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 5, 22)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void CalculoFechaEjecucion_Recurrente_Mensual_Dia31_FechaActual()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 4, 22),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { true },
                    DiaMes = 31
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 30)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }


    }
}
