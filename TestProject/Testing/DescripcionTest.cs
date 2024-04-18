using FluentAssertions;
using Negocio.Calculos;
using Negocio.EntitiesDTO;
using Negocio.Enums;

namespace TestProject.Testing
{
    public class DescripcionTest
    {
        [Fact]
        public void ObtenerDescripcion_Nulo_DeberiaRetornarNull()
        {
            // Arrange
            var descripcion = new Descripcion();
            var entrada = new EntradaDTO
            {
                TipoCalculo = TiposCalculos.nulo,                
            };            

            // Act
            var salidaResultado = descripcion.ObtenerDescripcion(entrada);

            // Assert
            salidaResultado.Should().BeNull();
        }

        [Fact]
        public void ObtenerDescripcion_Recurrente_Diariamente_UnaVez()
        {
            // Arrenge
            var descripcion = new Descripcion();
            var entrada = new EntradaDTO
            {
                TipoCalculo = TiposCalculos.Recurrente,
                Ocurrencia = OcurrenciaCalculos.Diaria,
                FrecuenciaDiaria = new FrecuenciaDiariaDTO
                {
                    TipoFrecuenciaDiaria = TiposCalculos.Una_vez,
                    HoraInicio = new DateTime(2024, 04, 18, 9, 0, 0),
                },
                FechaRepeticion = new DateTime(2024, 04, 18)
            };

            // Act
            var salidaResultado = descripcion.ObtenerDescripcion(entrada);

            // Assert
            salidaResultado.Should().Be("Ocurre diariamente. El programador se utilizará el 18/04/2024 a las 09:00");

        }

        [Fact]
        public void ObtenerDescripcion_Recurrente_Diariamente_Recurrente()
        {
            // Arrenge
            var descripcion = new Descripcion();
            var entrada = new EntradaDTO
            {
                TipoCalculo = TiposCalculos.Recurrente,
                Ocurrencia = OcurrenciaCalculos.Diaria,
                FrecuenciaDiaria = new FrecuenciaDiariaDTO
                {
                    TipoFrecuenciaDiaria = TiposCalculos.Recurrente,
                    HoraInicio = new DateTime(2024, 04, 18, 9, 0, 0),
                    HoraFin = new DateTime(2024, 04, 18, 20, 0, 0),
                    TiempoRepeticion = 2
                },
                FechaRepeticion = new DateTime(2024, 04, 18)
            };

            // Act
            var salidaResultado = descripcion.ObtenerDescripcion(entrada);

            // Assert
            salidaResultado.Should().Be("Ocurre diariamente. El programador se utilizará el 18/04/2024 desde las 09:00 a las 20:00 cada 2 horas");
        }

        [Fact]
        public void ObtenerDescripcion_Recurrente_Semanalmente_UnaVez()
        {
            // Arrenge
            var descripcion = new Descripcion();
            var entrada = new EntradaDTO
            {
                TipoCalculo = TiposCalculos.Recurrente,
                Ocurrencia = OcurrenciaCalculos.Semanal,
                FrecuenciaDiaria = new FrecuenciaDiariaDTO
                {
                    TipoFrecuenciaDiaria = TiposCalculos.Una_vez,
                    HoraInicio = new DateTime(2024,04,18,9,0,0),
                },
                FechaRepeticion = new DateTime(2024,04,18)
            };

            // Act
            var salidaResultado = descripcion.ObtenerDescripcion(entrada);

            // Assert
            salidaResultado.Should().Be("Ocurre semanalmente. El programador se utilizará el 18/04/2024 a las 09:00");           

        }

        [Fact]
        public void ObtenerDescripcion_Recurrente_Semanalmente_Recurrente()
        {
            // Arrenge
            var descripcion = new Descripcion();
            var entrada = new EntradaDTO
            {
                TipoCalculo = TiposCalculos.Recurrente,
                Ocurrencia = OcurrenciaCalculos.Semanal,
                FrecuenciaDiaria = new FrecuenciaDiariaDTO
                {
                    TipoFrecuenciaDiaria = TiposCalculos.Recurrente,
                    HoraInicio = new DateTime(2024, 04, 18, 9, 0, 0),
                    HoraFin = new DateTime(2024, 04, 18, 20, 0, 0),
                    TiempoRepeticion = 2
                },
                FechaRepeticion = new DateTime(2024, 04, 18)
            };

            // Act
            var salidaResultado = descripcion.ObtenerDescripcion(entrada);

            // Assert
            salidaResultado.Should().Be("Ocurre semanalmente. El programador se utilizará el 18/04/2024 desde las 09:00 a las 20:00 cada 2 horas");
        }

        [Fact]
        public void ObtenerDescripcion_Recurrente_Nulo_DeberiaRetornarNull()
        {
            // Arrange
            var descripcion = new Descripcion();
            var entrada = new EntradaDTO
            {
                TipoCalculo = TiposCalculos.Recurrente,
                Ocurrencia = OcurrenciaCalculos.Nulo
            };

            // Act
            var salidaResultado = descripcion.ObtenerDescripcion(entrada);

            // Assert
            salidaResultado.Should().BeNull();
        }

    }
}
