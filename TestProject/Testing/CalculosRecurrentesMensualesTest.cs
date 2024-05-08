using FluentAssertions;
using Negocio.Calculos;
using Negocio.EntitiesDTO;
using Negocio.Enums;

namespace TestProject.Testing
{
    public class CalculosRecurrentesMensualesTest
    {
        [Fact]
        public void DiaConcreto_DiaAnterior_FechaActual()
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
        public void DiaConcreto_DiaAnterior_FechaActual_Febrero()
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
        public void DiaConcreto_DiaPosterior_FechaActual()
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
        public void DiaConcreto_DiaIgual_FechaActual()
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
        public void DiaConcreto_Dia31_FechaActual()
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

        [Fact]
        public void DiaSemana_PrimerLunes_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 3),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Primer,
                    DiaSemana = DiasSemana.Lunes,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 4)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_PrimerLunes_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 5),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Primer,
                    DiaSemana = DiasSemana.Lunes,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 1)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_SegundoLunes_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 5),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Segundo,
                    DiaSemana = DiasSemana.Lunes,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 11)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_SegundoLunes_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 12),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Segundo,
                    DiaSemana = DiasSemana.Lunes,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 8)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_TercerLunes_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 5),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Tercer,
                    DiaSemana = DiasSemana.Lunes,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 18)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_TercerLunes_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 19),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Tercer,
                    DiaSemana = DiasSemana.Lunes,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 15)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_CuartoLunes_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 5),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Cuarto,
                    DiaSemana = DiasSemana.Lunes,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 25)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_CuartoLunes_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 27),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Cuarto,
                    DiaSemana = DiasSemana.Lunes,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 22)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_UltimoLunes_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 3),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Ultimo,
                    DiaSemana = DiasSemana.Lunes,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 25)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_UltimoLunes_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 26),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Ultimo,
                    DiaSemana = DiasSemana.Lunes,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 29)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_PrimerMartes_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 2),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Primer,
                    DiaSemana = DiasSemana.Martes,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 5)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_PrimerMartes_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 6),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Primer,
                    DiaSemana = DiasSemana.Martes,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 2)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_SegundoMartes_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 4),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Segundo,
                    DiaSemana = DiasSemana.Martes,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 12)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_SegundoMartes_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 13),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Segundo,
                    DiaSemana = DiasSemana.Martes,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 9)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_TercerMartes_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 5),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Tercer,
                    DiaSemana = DiasSemana.Martes,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 19)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_TercerMartes_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 20),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Tercer,
                    DiaSemana = DiasSemana.Martes,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 16)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_CuartoMartes_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 5),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Cuarto,
                    DiaSemana = DiasSemana.Martes,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 26)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_CuartoMartes_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 27),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Cuarto,
                    DiaSemana = DiasSemana.Martes,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 23)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_UltimoMartes_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 3),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Ultimo,
                    DiaSemana = DiasSemana.Martes,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 26)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_UltimoMartes_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 27),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Ultimo,
                    DiaSemana = DiasSemana.Martes,
                    CantidadMeses = 1
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
        public void DiaSemana_PrimerMiercoles_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 3),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Primer,
                    DiaSemana = DiasSemana.Miercoles,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 6)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_PrimerMiercoles_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 13),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Primer,
                    DiaSemana = DiasSemana.Miercoles,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 3)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_SegundoMiercoles_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 6),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Segundo,
                    DiaSemana = DiasSemana.Miercoles,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 13)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_SegundoMiercoles_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 20),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Segundo,
                    DiaSemana = DiasSemana.Miercoles,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 10)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_TercerMiercoles_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 13),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Tercer,
                    DiaSemana = DiasSemana.Miercoles,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 20)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_TercerMiercoles_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 27),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Tercer,
                    DiaSemana = DiasSemana.Miercoles,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 17)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_CuartoMiercoles_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 13),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Cuarto,
                    DiaSemana = DiasSemana.Miercoles,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 27)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void TDiaSemana_CuartoMiercoles_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 28),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Cuarto,
                    DiaSemana = DiasSemana.Miercoles,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 24)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_UltimoMiercoles_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 3),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Ultimo,
                    DiaSemana = DiasSemana.Miercoles,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 27)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_UltimoMiercoles_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 28),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Ultimo,
                    DiaSemana = DiasSemana.Miercoles,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 24)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_PrimerJueves_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 3),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Primer,
                    DiaSemana = DiasSemana.Jueves,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 7)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_PrimerJueves_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 12),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Primer,
                    DiaSemana = DiasSemana.Jueves,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 4)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_SegundoJueves_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 5),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Segundo,
                    DiaSemana = DiasSemana.Jueves,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 14)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_SegundoJueves_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 19),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Segundo,
                    DiaSemana = DiasSemana.Jueves,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 11)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_TercerJueves_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 5),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Tercer,
                    DiaSemana = DiasSemana.Jueves,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 21)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_TercerJueves_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 26),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Tercer,
                    DiaSemana = DiasSemana.Jueves,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 18)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_CuartoJueves_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 5),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Cuarto,
                    DiaSemana = DiasSemana.Jueves,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 28)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_CuartoJueves_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 30),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Cuarto,
                    DiaSemana = DiasSemana.Jueves,
                    CantidadMeses = 1
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
        public void DiaSemana_UltimoJueves_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 3),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Ultimo,
                    DiaSemana = DiasSemana.Jueves,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 28)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_UltimoJueves_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 29),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Ultimo,
                    DiaSemana = DiasSemana.Jueves,
                    CantidadMeses = 1
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
        public void DiaSemana_PrimerViernes_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 1),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Primer,
                    DiaSemana = DiasSemana.Viernes,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 1)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_PrimerViernes_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 8),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Primer,
                    DiaSemana = DiasSemana.Viernes,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 5)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_SegundoViernes_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 5),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Segundo,
                    DiaSemana = DiasSemana.Viernes,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 8)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_SegundoViernes_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 12),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Segundo,
                    DiaSemana = DiasSemana.Viernes,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 12)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_TercerViernes_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 5),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Tercer,
                    DiaSemana = DiasSemana.Viernes,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 15)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_TercerViernes_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 19),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Tercer,
                    DiaSemana = DiasSemana.Viernes,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 19)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_CuartoViernes_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 5),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Cuarto,
                    DiaSemana = DiasSemana.Viernes,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 22)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_CuartoViernes_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 27),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Cuarto,
                    DiaSemana = DiasSemana.Viernes,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 26)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }
        

        [Fact]
        public void DiaSemana_UltimoViernes_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 3),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Ultimo,
                    DiaSemana = DiasSemana.Viernes,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 29)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_UltimoViernes_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 30),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Ultimo,
                    DiaSemana = DiasSemana.Viernes,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 26)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_PrimerSabado_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 1),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Primer,
                    DiaSemana = DiasSemana.Sabado,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 2)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_PrimerSabado_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 5),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Primer,
                    DiaSemana = DiasSemana.Sabado,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 6)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_SegundoSabado_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 5),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Segundo,
                    DiaSemana = DiasSemana.Sabado,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 9)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_SegundoSabado_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 12),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Segundo,
                    DiaSemana = DiasSemana.Sabado,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 13)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_TercerSabado_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 5),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Tercer,
                    DiaSemana = DiasSemana.Sabado,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 16)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_TercerSabado_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 19),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Tercer,
                    DiaSemana = DiasSemana.Sabado,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 20)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_CuartoSabado_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 5),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Cuarto,
                    DiaSemana = DiasSemana.Sabado,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 23)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_CuartoSabado_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 27),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Cuarto,
                    DiaSemana = DiasSemana.Sabado,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 27)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_UltimoSabado_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 3),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Ultimo,
                    DiaSemana = DiasSemana.Sabado,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 30)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_UltimoSabado_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 31),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Ultimo,
                    DiaSemana = DiasSemana.Sabado,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 27)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_PrimerDomingo_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 2),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Primer,
                    DiaSemana = DiasSemana.Domingo,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 3)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_PrimerDomingo_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 5),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Primer,
                    DiaSemana = DiasSemana.Domingo,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 7)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_SegundoDomingo_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 5),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Segundo,
                    DiaSemana = DiasSemana.Domingo,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 10)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_SegundoDomingo_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 12),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Segundo,
                    DiaSemana = DiasSemana.Domingo,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 14)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_TercerDomingo_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 5),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Tercer,
                    DiaSemana = DiasSemana.Domingo,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 17)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_TercerDomingo_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 19),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Tercer,
                    DiaSemana = DiasSemana.Domingo,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 21)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_CuartoDomingo_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 5),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Cuarto,
                    DiaSemana = DiasSemana.Domingo,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 24)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_CuartoDomingo_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 27),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Cuarto,
                    DiaSemana = DiasSemana.Domingo,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 28)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_UltimoDomingo_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 3),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Ultimo,
                    DiaSemana = DiasSemana.Domingo,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 31)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_UltimoDomingo_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 4, 30),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Ultimo,
                    DiaSemana = DiasSemana.Domingo,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 5, 26)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_PrimerWeekday_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 3),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Primer,
                    DiaSemana = DiasSemana.Entre_semana,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 4)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_PrimerWeekday_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 5),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Primer,
                    DiaSemana = DiasSemana.Entre_semana,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 1)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_SegundoWeekday_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 5),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Segundo,
                    DiaSemana = DiasSemana.Entre_semana,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 11)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_SegundoWeekday_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 12),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Segundo,
                    DiaSemana = DiasSemana.Entre_semana,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 8)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_TercerWeekday_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 5),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Tercer,
                    DiaSemana = DiasSemana.Entre_semana,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 18)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_TercerWeekday_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 19),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Tercer,
                    DiaSemana = DiasSemana.Entre_semana,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 15)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_CuartoWeekday_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 5),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Cuarto,
                    DiaSemana = DiasSemana.Entre_semana,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 25)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_CuartoWeekday_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 27),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Cuarto,
                    DiaSemana = DiasSemana.Entre_semana,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 22)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_PrimerWeekend_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 1),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Primer,
                    DiaSemana = DiasSemana.Fin_de_semana,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 2)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_PrimerWeekend_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 5),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Primer,
                    DiaSemana = DiasSemana.Fin_de_semana,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 6)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_SegundoWeekend_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 5),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Segundo,
                    DiaSemana = DiasSemana.Fin_de_semana,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 9)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_SegundoWeekend_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 12),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Segundo,
                    DiaSemana = DiasSemana.Fin_de_semana,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 13)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_TercerWeekend_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 5),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Tercer,
                    DiaSemana = DiasSemana.Fin_de_semana,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 16)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_TercerWeekend_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 19),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Tercer,
                    DiaSemana = DiasSemana.Fin_de_semana,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 20)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_CuartoWeekend_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 5),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Cuarto,
                    DiaSemana = DiasSemana.Fin_de_semana,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 3, 23)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_CuartoWeekend_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 27),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Cuarto,
                    DiaSemana = DiasSemana.Fin_de_semana,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 4, 27)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_PrimerDay_HoraActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
                FrecuenciaDiaria = new FrecuenciaDiariaDTO
                {
                    HoraInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 0, 0).AddHours(-1)
                },
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Primer,
                    DiaSemana = DiasSemana.Dia,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(1)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_PrimerDay_HoraActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
                FrecuenciaDiaria = new FrecuenciaDiariaDTO
                {
                    HoraInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 0, 0).AddHours(1)
                },
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Primer,
                    DiaSemana = DiasSemana.Dia,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_SegundoDay_HoraActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
                FrecuenciaDiaria = new FrecuenciaDiariaDTO
                {
                    HoraInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 0, 0).AddHours(-1)
                },
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Segundo,
                    DiaSemana = DiasSemana.Dia,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(2)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_SegundoDay_HoraActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
                FrecuenciaDiaria = new FrecuenciaDiariaDTO
                {
                    HoraInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 0, 0).AddHours(1)
                },
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Segundo,
                    DiaSemana = DiasSemana.Dia,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(1)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_TercerDay_HoraActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
                FrecuenciaDiaria = new FrecuenciaDiariaDTO
                {
                    HoraInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 0, 0).AddHours(-1)
                },
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Tercer,
                    DiaSemana = DiasSemana.Dia,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(3)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_TercerDay_HoraActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
                FrecuenciaDiaria = new FrecuenciaDiariaDTO
                {
                    HoraInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 0, 0).AddHours(1)
                },
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Tercer,
                    DiaSemana = DiasSemana.Dia,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(2)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_CuartoDay_HoraActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
                FrecuenciaDiaria = new FrecuenciaDiariaDTO
                {
                    HoraInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 0, 0).AddHours(-1)
                },
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Cuarto,
                    DiaSemana = DiasSemana.Dia,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(4)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_CuartoDay_HoraActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
                FrecuenciaDiaria = new FrecuenciaDiariaDTO
                {
                    HoraInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 0, 0).AddHours(1)
                },
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Cuarto,
                    DiaSemana = DiasSemana.Dia,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(3)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_UltimoDay_HoraActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
                FrecuenciaDiaria = new FrecuenciaDiariaDTO
                {
                    HoraInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 0, 0).AddHours(-1)
                },
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Ultimo,
                    DiaSemana = DiasSemana.Dia,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(4)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void DiaSemana_UltimoDay_HoraActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
                FrecuenciaDiaria = new FrecuenciaDiariaDTO
                {
                    HoraInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 0, 0).AddHours(1)
                },
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Ultimo,
                    DiaSemana = DiasSemana.Dia,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(4)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }        
    }
}