using FluentAssertions;
using Negocio.Calculos;
using Negocio.EntitiesDTO;
using Negocio.Enums;

namespace TestProject.Testing
{
    public class DescripcionTestUS
    {
        [Fact]
        public void ObtenerDescripcion_Recurrente_Diariamente_UnaVez()
        {
            // Arrenge
            var descripcion = new Descripcion();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 04, 16),
                TipoCalculo = TiposCalculos.Recurrente,
                Ocurrencia = OcurrenciaCalculos.Diaria,
                FrecuenciaDiaria = new FrecuenciaDiariaDTO
                {
                    TipoFrecuenciaDiaria = TiposCalculos.Una_vez,
                    HoraInicio = new DateTime(2024, 04, 18, 14, 0, 0),
                },
                FechaRepeticion = new DateTime(2024, 04, 18),
                Idioma = Idiomas.US
            };

            // Act
            var salidaResultado = descripcion.ObtenerDescripcion(entrada);

            // Assert
            salidaResultado.Should().Be("Occurs every day. Schedule will be used on 04/18/2024 at 02:00 PM starting on 04/16/2024");
        }

        [Fact]
        public void ObtenerDescripcion_Recurrente_Diariamente_Recurrente()
        {
            // Arrenge
            var descripcion = new Descripcion();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 04, 16),
                TipoCalculo = TiposCalculos.Recurrente,
                Ocurrencia = OcurrenciaCalculos.Diaria,
                FrecuenciaDiaria = new FrecuenciaDiariaDTO
                {
                    TipoFrecuenciaDiaria = TiposCalculos.Recurrente,
                    HoraInicio = new DateTime(2024, 04, 18, 9, 0, 0),
                    HoraFin = new DateTime(2024, 04, 18, 20, 0, 0),
                    TiempoRepeticion = 2
                },
                FechaRepeticion = new DateTime(2024, 04, 18),
                Idioma = Idiomas.US
            };

            // Act
            var salidaResultado = descripcion.ObtenerDescripcion(entrada);

            // Assert
            salidaResultado.Should().Be("Occurs every day. Schedule will be used on 04/18/2024 between 09:00 AM and 08:00 PM every 2 hours starting on 04/16/2024");
        }

        [Fact]
        public void ObtenerDescripcion_Recurrente_Semanalmente_UnaVez()
        {
            // Arrenge
            var descripcion = new Descripcion();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 04, 16),
                TipoCalculo = TiposCalculos.Recurrente,
                Ocurrencia = OcurrenciaCalculos.Semanal,
                FrecuenciaDiaria = new FrecuenciaDiariaDTO
                {
                    TipoFrecuenciaDiaria = TiposCalculos.Una_vez,
                    HoraInicio = new DateTime(2024, 04, 18, 9, 0, 0),
                },
                FechaRepeticion = new DateTime(2024, 04, 18),
                Idioma = Idiomas.US,
                ConfiguracionSemana = new ConfiguracionSemanalDTO
                {
                    NumeroSemanas = 2,
                }
            };

            // Act
            var salidaResultado = descripcion.ObtenerDescripcion(entrada);

            // Assert
            salidaResultado.Should().Be("Occurs every 2 week/s. Schedule will be used on 04/18/2024 at 09:00 AM starting on 04/16/2024");
        }

        [Fact]
        public void ObtenerDescripcion_Recurrente_Semanalmente_Recurrente()
        {
            // Arrenge
            var descripcion = new Descripcion();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 04, 16),
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
                Idioma = Idiomas.US,
                ConfiguracionSemana = new ConfiguracionSemanalDTO
                {
                    NumeroSemanas = 2,
                }
            };

            // Act
            var salidaResultado = descripcion.ObtenerDescripcion(entrada);

            // Assert
            salidaResultado.Should().Be("Occurs every 2 week/s. Schedule will be used on 04/18/2024 between 09:00 AM and 08:00 PM every 2 hours starting on 04/16/2024");
        }

        [Fact]
        public void ObtenerDescripcion_Recurrente_Mensual_UnDia_UnaVez()
        {
            // Arrenge
            var descripcion = new Descripcion();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 04, 18),
                TipoCalculo = TiposCalculos.Recurrente,
                Ocurrencia = OcurrenciaCalculos.Mensual,
                Idioma = Idiomas.US,
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
                Descripcion = $"Occurs on day 3 every 4 month/s. Schedule will be used on day at 09:00 AM starting on 04/18/2024"
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
                FechaActual = new DateTime(2024, 04, 16),
                TipoCalculo = TiposCalculos.Recurrente,
                Ocurrencia = OcurrenciaCalculos.Mensual,
                Idioma = Idiomas.US,
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
            var salidaEsperada = new SalidaDTO
            {
                Descripcion = $"Occurs on day 3 every 4 month/s. Schedule will be used on day between 09:00 AM and 08:00 PM every 2 hours starting on 04/16/2024"
            };

            // Act
            var salidaResultado = descripcion.ObtenerDescripcion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.Descripcion);
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
                Idioma = Idiomas.US,
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
            var salidaEsperada = new SalidaDTO
            {
                Descripcion = "Occurs the First Monday of every 2 month/s. Schedule will be used on day at 09:00 AM starting on 04/18/2024"
            };

            // Act
            var salidaResultado = descripcion.ObtenerDescripcion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.Descripcion);
        }

        [Fact]
        public void ObtenerDescripcion_Recurrente_Mensual_VariosDias_Recurrente()
        {
            // Arrenge
            var descripcion = new Descripcion();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 04, 16),
                TipoCalculo = TiposCalculos.Recurrente,
                Ocurrencia = OcurrenciaCalculos.Mensual,
                Idioma = Idiomas.US,
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
            var salidaEsperada = new SalidaDTO
            {
                Descripcion = "Occurs the First Monday of every 2 month/s. Schedule will be used on day between 09:00 AM and 08:00 PM every 2 hours starting on 04/16/2024"
            };

            // Act
            var salidaResultado = descripcion.ObtenerDescripcion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.Descripcion);
        }
    }
}