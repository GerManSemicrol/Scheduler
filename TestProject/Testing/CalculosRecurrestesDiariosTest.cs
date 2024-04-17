

using Negocio.EntitiesDTO;
using Negocio.Enums;
using Negocio.Managament;

namespace TestProject.Testing
{
    public class CalculosRecurrestesDiariosTest
    {
        [Fact]
        public void Calcular_Datos_Salida_Correctos_Recurrente_Diaria_Una_Vez()
        {
            //Arrenge
            var programador = new Programador();
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
            var salida = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 04, 18),
                Descripcion = $"Ocurre diariamente. El programador se utilizará el 18/04/2024 a las 14:00",
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
        public void Calcular_Datos_Salida_Correctos_Recurrente_Diaria_Varias_Horas()
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
            var entrada = new EntradaDTO
            {
                FechaActual = fechaActual,
                TipoCalculo = TiposCalculos.Recurrente,
                Ocurrencia = OcurrenciaCalculos.Diaria,
                DiasRepeticion = 2,
                FechaRepeticion = fechaActual.AddDays(2),
                FrecuenciaDiaria = frecuenciaDiaria
            };
            var salida = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 04, 18),
                Descripcion = $"Ocurre diariamente. El programador se utilizará el 18/04/2024 desde las 14:00" +
                    $" a las 20:00 cada 2 horas",
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
