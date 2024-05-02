using FluentAssertions;
using Negocio.Calculos;
using Negocio.EntitiesDTO;
using Negocio.Enums;

namespace TestProject.Testing
{
    public class CalculosRecurrentesTest
    {
        [Fact]
        public void TipoNoRecurrente_DeberiaRetornarNull()
        {
            // Arrange
            var calculadora = new CalculosRecurrentes();
            var entrada = new EntradaDTO
            {
                TipoCalculo = TiposCalculos.Una_vez, 
                Ocurrencia = OcurrenciaCalculos.Diaria,
                FechaActual = new DateTime(2024, 4, 17) 
            };

            // Act
            var salidaResultado = calculadora.CalcularRecurrente(entrada);

            // Assert
            salidaResultado.Should().BeNull();
        }

        [Fact]
        public void Recurrente_Mensual_SalidaComplete()
        {
            // Arrange
            var calculadora = new CalculosRecurrentes();
            var entrada = new EntradaDTO
            {
                TipoCalculo = TiposCalculos.Recurrente,
                Ocurrencia = OcurrenciaCalculos.Mensual,
                FechaActual = new DateTime(2024, 3, 31),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { true },
                    DiaMes = 30,
                    CantidadMeses = 4
                },
                FrecuenciaDiaria = new FrecuenciaDiariaDTO
                {
                    TipoFrecuenciaDiaria = TiposCalculos.Una_vez,
                    HoraInicio = new DateTime(2024, 03, 31, 9, 0, 0),
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                Tipo = TiposCalculos.Recurrente,
                FechaEjecucion = new DateTime(2024, 4, 30),
                Descripcion = "Ocurre el día 30 cada 4 meses. El programador se utilizará una vez al día a las 09:00:00"
            };


            // Act
            var salidaResultado = calculadora.CalcularRecurrente(entrada);

            // Assert
            salidaResultado.Tipo.Should().Be(salidaEsperada.Tipo);
            salidaResultado.FechaEjecucion.Should().Be(salidaEsperada.FechaEjecucion);
            salidaResultado.Descripcion.Should().Be(salidaEsperada.Descripcion);
        }

    }
}
