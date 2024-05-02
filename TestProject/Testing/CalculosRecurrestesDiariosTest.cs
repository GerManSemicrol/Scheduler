using FluentAssertions;
using Negocio.Calculos;
using Negocio.EntitiesDTO;
using Negocio.Enums;

namespace TestProject.Testing
{
    public class CalculosRecurrestesDiariosTest
    {
        [Fact]
        public void Recurrente_OcurrenciaDiaria_UnaVez_DeberiaRetornarSalidaDTOCorrecta()
        {
            //Arrenge
            var calculadora = new CalculosRecurrentes();
            var fechaActual = new DateTime(2024, 04, 16);
            var frecuenciaDiaria = new FrecuenciaDiariaDTO
            {
                TipoFrecuenciaDiaria = TiposCalculos.Una_vez,
                HoraInicio = new DateTime(fechaActual.Year, fechaActual.Month, fechaActual.Day, 14, 0, 0)
            };
            var entrada = new EntradaDTO
            {
                FechaActual = fechaActual,
                TipoCalculo = TiposCalculos.Recurrente,
                Ocurrencia = OcurrenciaCalculos.Diaria,
                DiasRepeticion = 2,
                FechaRepeticion = fechaActual.AddDays(2),
                FrecuenciaDiaria = frecuenciaDiaria
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 04, 18),
                Descripcion = "Ocurre diariamente. El programador se utilizará el 18/04/2024 a las 14:00",
                Tipo = TiposCalculos.Recurrente
            };

            //Act
            var salidaResultado = calculadora.CalcularRecurrente(entrada);

            //Assert            
            salidaResultado.Tipo.Should().Be(salidaEsperada.Tipo);
            salidaResultado.FechaEjecucion.Should().Be(salidaEsperada.FechaEjecucion);
            salidaResultado.Descripcion.Should().Be(salidaEsperada.Descripcion);
        }

        [Fact]
        public void Recurrente_OcurrenciaDiario_VariasHoras_DeberiaRetornarSalidaDTOCorrecta()
        {
            //Arrenge
            var calculadora = new CalculosRecurrentes();
            var fechaActual = new DateTime(2024, 04, 16);
            var frecuenciaDiaria = new FrecuenciaDiariaDTO
            {
                TipoFrecuenciaDiaria = TiposCalculos.Recurrente,
                TiempoRepeticion = 2,
                HoraInicio = new DateTime(fechaActual.Year, fechaActual.Month, fechaActual.Day, 14, 0, 0),
                HoraFin = new DateTime(fechaActual.Year, fechaActual.Month, fechaActual.Day, 20, 0, 0)
            };
            var entrada = new EntradaDTO
            {
                FechaActual = fechaActual,
                TipoCalculo = TiposCalculos.Recurrente,
                Ocurrencia = OcurrenciaCalculos.Diaria,
                DiasRepeticion = 2,
                FechaRepeticion = fechaActual.AddDays(2),
                FrecuenciaDiaria = frecuenciaDiaria
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 04, 18),
                Descripcion = $"Ocurre diariamente. El programador se utilizará el 18/04/2024 desde las 14:00" +
                    $" a las 20:00 cada 2 horas",
                Tipo = TiposCalculos.Recurrente
            };

            //Act
            var salidaResultado = calculadora.CalcularRecurrente(entrada);

            //Assert
            salidaResultado.Tipo.Should().Be(salidaEsperada.Tipo);
            salidaResultado.FechaEjecucion.Should().Be(salidaEsperada.FechaEjecucion);
            salidaResultado.Descripcion.Should().Be(salidaEsperada.Descripcion);            
        }
    }
}
