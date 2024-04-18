using FluentAssertions;
using Negocio.Calculos;
using Negocio.EntitiesDTO;
using Negocio.Enums;

namespace TestProject.Testing
{
    public class CalculosRecurrentesTest
    {
        [Fact]
        public void CalcularRecurrente_TipoNoRecurrente_DeberiaRetornarNull()
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

    }
}
