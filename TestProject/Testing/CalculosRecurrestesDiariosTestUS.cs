using FluentAssertions;
using Negocio.Calculos;
using Negocio.EntitiesDTO;
using Negocio.Enums;

namespace TestProject.Testing
{
    public class CalculosRecurrestesDiariosTestUS
    {
        [Fact]
        public void Recurrente_OcurrenciaDiaria_UnaVez_US()
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
                FrecuenciaDiaria = frecuenciaDiaria,
                Idioma = Idiomas.US
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 04, 18),
                Descripcion = "Occurs every day. Schedule will be used on 04/18/2024 at 02:00 PM starting on 04/16/2024",
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
        public void Recurrente_OcurrenciaDiario_VariasHoras_US()
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
                FrecuenciaDiaria = frecuenciaDiaria,
                Idioma = Idiomas.US
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 04, 18),
                Descripcion = "Occurs every day. Schedule will be used on 04/18/2024 between 02:00 PM and 08:00 PM every 2 hours starting on 04/16/2024",
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
