using FluentAssertions;
using Negocio.Calculos;
using Negocio.EntitiesDTO;
using Negocio.Enums;

namespace TestProject.Testing
{
    public class CalculosRecurrentesMensualesTest
    {
        [Fact]
        public void Tipo0_DiaAnterior_FechaActual()
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
        public void Tipo0_DiaAnterior_FechaActual_Febrero()
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
        public void Tipo0_DiaPosterior_FechaActual()
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
        public void Tipo0_DiaIgual_FechaActual()
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
        public void Tipo0_Dia31_FechaActual()
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
        public void Tipo1_PrimerLunes_FechaActualAnterior()
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
        public void Tipo1_PrimerLunes_FechaActualPosterior()
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
        public void Tipo1_SegundoLunes_FechaActualAnterior()
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
        public void Tipo1_SegundoLunes_FechaActualPosterior()
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
        public void Tipo1_TercerLunes_FechaActualAnterior()
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
        public void Tipo1_TercerLunes_FechaActualPosterior()
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
        public void Tipo1_CuartoLunes_FechaActualAnterior()
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
        public void Tipo1_CuartoLunes_FechaActualPosterior()
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
        public void Tipo1_PrimerMartes_FechaActualAnterior()
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
        public void Tipo1_PrimerMartes_FechaActualPosterior()
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
        public void Tipo1_SegundoMartes_FechaActualAnterior()
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
        public void Tipo1_SegundoMartes_FechaActualPosterior()
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
        public void Tipo1_TercerMartes_FechaActualAnterior()
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
        public void Tipo1_TercerMartes_FechaActualPosterior()
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
        public void Tipo1_CuartoMartes_FechaActualAnterior()
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
        public void Tipo1_CuartoMartes_FechaActualPosterior()
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
        public void Tipo1_PrimerMiercoles_FechaActualAnterior()
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
        public void Tipo1_PrimerMiercoles_FechaActualPosterior()
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
        public void Tipo1_SegundoMiercoles_FechaActualAnterior()
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
        public void Tipo1_SegundoMiercoles_FechaActualPosterior()
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
        public void Tipo1_TercerMiercoles_FechaActualAnterior()
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
        public void Tipo1_TercerMiercoles_FechaActualPosterior()
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
        public void Tipo1_CuartoMiercoles_FechaActualAnterior()
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
        public void Tipo1_CuartoMiercoles_FechaActualPosterior()
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
        public void Tipo1_PrimerJueves_FechaActualAnterior()
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
        public void Tipo1_PrimerJueves_FechaActualPosterior()
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
        public void Tipo1_SegundoJueves_FechaActualAnterior()
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
        public void Tipo1_SegundoJueves_FechaActualPosterior()
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
        public void Tipo1_TercerJueves_FechaActualAnterior()
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
        public void Tipo1_TercerJueves_FechaActualPosterior()
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
        public void Tipo1_CuartoJueves_FechaActualAnterior()
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
        public void Tipo1_CuartoJueves_FechaActualPosterior()
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
        public void Tipo1_PrimerViernes_FechaActualAnterior()
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
        public void Tipo1_PrimerViernes_FechaActualPosterior()
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
        public void Tipo1_SegundoViernes_FechaActualAnterior()
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
        public void Tipo1_SegundoViernes_FechaActualPosterior()
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
        public void Tipo1_TercerViernes_FechaActualAnterior()
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
        public void Tipo1_TercerViernes_FechaActualPosterior()
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
        public void Tipo1_CuartoViernes_FechaActualAnterior()
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
        public void Tipo1_CuartoViernes_FechaActualPosterior()
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
        public void Tipo1_PrimerSabado_FechaActualAnterior()
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
        public void Tipo1_PrimerSabado_FechaActualPosterior()
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
        public void Tipo1_SegundoSabado_FechaActualAnterior()
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
        public void Tipo1_SegundoSabado_FechaActualPosterior()
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
        public void Tipo1_TercerSabado_FechaActualAnterior()
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
        public void Tipo1_TercerSabado_FechaActualPosterior()
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
        public void Tipo1_CuartoSabado_FechaActualAnterior()
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
        public void Tipo1_CuartoSabado_FechaActualPosterior()
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
        public void Tipo1_PrimerDomingo_FechaActualAnterior()
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
        public void Tipo1_PrimerDomingo_FechaActualPosterior()
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
        public void Tipo1_SegundoDomingo_FechaActualAnterior()
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
        public void Tipo1_SegundoDomingo_FechaActualPosterior()
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
        public void Tipo1_TercerDomingo_FechaActualAnterior()
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
        public void Tipo1_TercerDomingo_FechaActualPosterior()
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
        public void Tipo1_CuartoDomingo_FechaActualAnterior()
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
        public void Tipo1_CuartoDomingo_FechaActualPosterior()
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
        public void Tipo1_PrimerWeekday_FechaActualAnterior()
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
        public void Tipo1_PrimerWeekday_FechaActualPosterior()
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
        public void Tipo1_SegundoWeekday_FechaActualAnterior()
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
        public void Tipo1_SegundoWeekday_FechaActualPosterior()
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
        public void Tipo1_TercerWeekday_FechaActualAnterior()
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
        public void Tipo1_TercerWeekday_FechaActualPosterior()
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
        public void Tipo1_CuartoWeekday_FechaActualAnterior()
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
        public void Tipo1_CuartoWeekday_FechaActualPosterior()
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
        public void Tipo1_PrimerWeekend_FechaActualAnterior()
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
        public void Tipo1_PrimerWeekend_FechaActualPosterior()
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
        public void Tipo1_SegundoWeekend_FechaActualAnterior()
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
        public void Tipo1_SegundoWeekend_FechaActualPosterior()
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
        public void Tipo1_TercerWeekend_FechaActualAnterior()
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
        public void Tipo1_TercerWeekend_FechaActualPosterior()
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
        public void Tipo1_CuartoWeekend_FechaActualAnterior()
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
        public void Tipo1_CuartoWeekend_FechaActualPosterior()
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
        public void Tipo1_PrimerDay_FechaActualAnterior()
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
                    DiaSemana = DiasSemana.Dia,
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
        public void Tipo1_PrimerDay_FechaActualPosterior()
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
                    DiaSemana = DiasSemana.Dia,
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
        public void Tipo1_SegundoDay_FechaActualAnterior()
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
                    DiaSemana = DiasSemana.Dia,
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
        public void Tipo1_SegundoDay_FechaActualPosterior()
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
                    DiaSemana = DiasSemana.Dia,
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
        public void Tipo1_TercerDay_FechaActualAnterior()
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
                    DiaSemana = DiasSemana.Dia,
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
        public void Tipo1_TercerDay_FechaActualPosterior()
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
                    DiaSemana = DiasSemana.Dia,
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
        public void Tipo1_CuartoDay_FechaActualAnterior()
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
                    DiaSemana = DiasSemana.Dia,
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
        public void Tipo1_CuartoDay_FechaActualPosterior()
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
                    DiaSemana = DiasSemana.Dia,
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
        public void Tipo1_UltimoLunes_FechaActualAnterior()
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
        public void Tipo1_UltimoLunes_FechaActualPosterior()
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
        public void Tipo1_UltimoMartes_FechaActualAnterior()
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
        public void Tipo1_UltimoMartes_FechaActualPosterior()
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
        public void Tipo1_UltimoMiercoles_FechaActualAnterior()
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
        public void Tipo1_UltimoMiercoles_FechaActualPosterior()
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
        public void Tipo1_UltimoJueves_FechaActualAnterior()
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
        public void Tipo1_UltimoJueves_FechaActualPosterior()
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
        public void Tipo1_UltimoViernes_FechaActualAnterior()
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
        public void Tipo1_UltimoViernes_FechaActualPosterior()
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
        public void Tipo1_UltimoSabado_FechaActualAnterior()
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
        public void Tipo1_UltimoSabado_FechaActualPosterior()
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
        public void Tipo1_UltimoDomingo_FechaActualAnterior()
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
        public void Tipo1_UltimoDomingo_FechaActualPosterior()
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

    }
}