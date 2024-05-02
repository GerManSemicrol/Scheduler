using System.Security.Cryptography;
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
                FechaRepeticion = new DateTime(2024,04,18),
                ConfiguracionSemana = new ConfiguracionSemanalDTO
                {
                    NumeroSemanas = 2,
                }
            };

            // Act
            var salidaResultado = descripcion.ObtenerDescripcion(entrada);

            // Assert
            salidaResultado.Should().Be("Ocurre cada 2 semana/s. El programador se utilizará el 18/04/2024 a las 09:00");           

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
                FechaRepeticion = new DateTime(2024, 04, 18),
                ConfiguracionSemana = new ConfiguracionSemanalDTO
                {
                    NumeroSemanas = 2,
                }
            };

            // Act
            var salidaResultado = descripcion.ObtenerDescripcion(entrada);

            // Assert
            salidaResultado.Should().Be("Ocurre cada 2 semana/s. El programador se utilizará el 18/04/2024 desde las 09:00 a las 20:00 cada 2 horas");
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

        [Fact]
        public void ObtenerDescripcion_Recurrente_Mensual_UnDia_UnaVez()
        {
            // Arrenge
            var descripcion = new Descripcion();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024,04,18),
                TipoCalculo = TiposCalculos.Recurrente,
                Ocurrencia = OcurrenciaCalculos.Mensual,
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { true },
                    DiaMes = 3,
                    CantidadMeses = 4,
                },
                FrecuenciaDiaria = new FrecuenciaDiariaDTO
                {
                    TipoFrecuenciaDiaria = TiposCalculos.Una_vez,
                    HoraInicio = new DateTime(2024, 04, 18, 9, 0, 0),
                } 
            };
            var salidaEsperada = new SalidaDTO
            {
                Descripcion = "Ocurre el día 3 cada 4 meses. El programador se utilizará una vez al día a las 09:00:00"
            };

            // Act
            var salidaResultado = descripcion.ObtenerDescripcion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.Descripcion);

        }

        [Fact]
        public void ObtenerDescripcion_Recurrente_Mensual_UnDia_Recurrente()
        {
            // Arrenge
            var descripcion = new Descripcion();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 04, 18),
                TipoCalculo = TiposCalculos.Recurrente,
                Ocurrencia = OcurrenciaCalculos.Mensual,
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { true },
                    DiaMes = 3,
                    CantidadMeses = 4,
                },
                FrecuenciaDiaria = new FrecuenciaDiariaDTO
                {
                    TipoFrecuenciaDiaria = TiposCalculos.Recurrente,
                    HoraInicio = new DateTime(2024, 04, 18, 9, 0, 0),
                    HoraFin = new DateTime(2024, 04, 18, 20, 0, 0),
                    TiempoRepeticion = 2
                }             
            };

            // Act
            var salidaResultado = descripcion.ObtenerDescripcion(entrada);

            // Assert
            salidaResultado.Should().Be("Ocurre el día 3 cada 4 meses. El programador se utilizará cada 2 hora/s entre las 09:00:00 y las 20:00:00");

        }

        [Fact]
        public void ObtenerDescripcion_Recurrente_Mensual_VariosDias_UnaVez()
        {
            // Arrenge
            var descripcion = new Descripcion();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 04, 18),
                TipoCalculo = TiposCalculos.Recurrente,
                Ocurrencia = OcurrenciaCalculos.Mensual,
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Primer,
                    DiaSemana = DiasSemana.Lunes,
                    CantidadMeses = 2
                },
                FrecuenciaDiaria = new FrecuenciaDiariaDTO
                {
                    TipoFrecuenciaDiaria = TiposCalculos.Una_vez,
                    HoraInicio = new DateTime(2024, 04, 18, 9, 0, 0),
                }                
            };

            // Act
            var salidaResultado = descripcion.ObtenerDescripcion(entrada);

            // Assert
            salidaResultado.Should().Be("Ocurre el Primer Lunes cada 2 meses. El programador se utilizará una vez al día a las 09:00:00");
        }

        [Fact]
        public void ObtenerDescripcion_Recurrente_Mensual_VariosDias_Recurrente()
        {
            // Arrenge
            var descripcion = new Descripcion();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 04, 18),
                TipoCalculo = TiposCalculos.Recurrente,
                Ocurrencia = OcurrenciaCalculos.Mensual,
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Primer,
                    DiaSemana = DiasSemana.Lunes,
                    CantidadMeses = 2
                },
                FrecuenciaDiaria = new FrecuenciaDiariaDTO
                {
                    TipoFrecuenciaDiaria = TiposCalculos.Recurrente,
                    HoraInicio = new DateTime(2024, 04, 18, 9, 0, 0),
                    HoraFin = new DateTime(2024, 04, 18, 20, 0, 0),
                    TiempoRepeticion = 2
                }                                
            };

            // Act
            var salidaResultado = descripcion.ObtenerDescripcion(entrada);

            // Assert
            salidaResultado.Should().Be("Ocurre el Primer Lunes cada 2 meses. El programador se utilizará cada 2 hora/s entre las 09:00:00 y las 20:00:00");
        }

    }
}
