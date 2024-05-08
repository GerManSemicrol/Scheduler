using FluentAssertions;
using Negocio.Calculos;
using Negocio.EntitiesDTO;
using Negocio.Enums;

namespace TestProject.Testing
{
    public class CalculosUnaVezTest
    {
        [Fact]
        public void Calcular_Una_Vez_TipoUnaVez_ESP()
        {
            //Arrenge
            var calculo = new CalculosUnaVez();
            var fecha = new DateTime(2024, 4, 17, 14, 0, 0);
            var entrada = new EntradaDTO
            {
                FechaActual = fecha,
                TipoCalculo = TiposCalculos.Una_vez,
                FechaRepeticion = fecha.AddDays(2),
                Idioma = Idiomas.ESP
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = entrada.FechaRepeticion,
                Descripcion = $"Ocurre una vez. El programador se utilizará el 19/04/2024 a las 14:00",
                Tipo = TiposCalculos.Una_vez
            };

            //Act
            var salidaResultado = calculo.CalcularSoloUnaVez(entrada);

            //Assert            
            //Assert.Equal(salidaEsperada.FechaEjecucion, salidaResultado.FechaEjecucion);
            //Assert.Equal(salidaEsperada.Tipo, salidaResultado.Tipo);
            //Assert.Equal(salidaEsperada.Descripcion, salidaResultado.Descripcion);

            salidaResultado.FechaEjecucion.Should().Be(salidaEsperada.FechaEjecucion);
            salidaResultado.Tipo.Should().Be(salidaEsperada.Tipo);
            salidaResultado.Descripcion.Should().Be(salidaEsperada.Descripcion);
        }

        [Fact]
        public void Calcular_Una_Vez_TipoRecurrente_DeberiaRetornarNull()
        {
            // Arrange
            var calculadora = new CalculosUnaVez();
            var entrada = new EntradaDTO
            {
                TipoCalculo = TiposCalculos.Recurrente, // Tipo distinto de Una_vez                
            };

            // Act
            var resultado = calculadora.CalcularSoloUnaVez(entrada);

            // Assert
            resultado.Should().BeNull();
        }

        [Fact]
        public void Calcular_Una_Vez_TipoUnaVez_US()
        {
            //Arrenge
            var calculo = new CalculosUnaVez();
            var fecha = new DateTime(2024, 4, 17, 14, 0, 0);
            var entrada = new EntradaDTO
            {
                FechaActual = fecha,
                TipoCalculo = TiposCalculos.Una_vez,
                FechaRepeticion = fecha.AddDays(2),
                Idioma = Idiomas.US
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = entrada.FechaRepeticion,
                Descripcion = "Occurs once. Schedule will be used on 04/19/2024 at 02:00 PM",
                Tipo = TiposCalculos.Una_vez
            };

            //Act
            var salidaResultado = calculo.CalcularSoloUnaVez(entrada);

            //Assert
            salidaResultado.FechaEjecucion.Should().Be(salidaEsperada.FechaEjecucion);
            salidaResultado.Tipo.Should().Be(salidaEsperada.Tipo);
            salidaResultado.Descripcion.Should().Be(salidaEsperada.Descripcion);
        }

        [Fact]
        public void Calcular_Una_Vez_TipoUnaVez_UK()
        {
            //Arrenge
            var calculo = new CalculosUnaVez();
            var fecha = new DateTime(2024, 4, 17, 14, 0, 0);
            var entrada = new EntradaDTO
            {
                FechaActual = fecha,
                TipoCalculo = TiposCalculos.Una_vez,
                FechaRepeticion = fecha.AddDays(2),
                Idioma = Idiomas.UK
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = entrada.FechaRepeticion,
                Descripcion = "Occurs once. Schedule will be used on 19/04/2024 at 02:00 PM",
                Tipo = TiposCalculos.Una_vez
            };

            //Act
            var salidaResultado = calculo.CalcularSoloUnaVez(entrada);

            //Assert
            salidaResultado.FechaEjecucion.Should().Be(salidaEsperada.FechaEjecucion);
            salidaResultado.Tipo.Should().Be(salidaEsperada.Tipo);
            salidaResultado.Descripcion.Should().Be(salidaEsperada.Descripcion);
        }
    }
}
