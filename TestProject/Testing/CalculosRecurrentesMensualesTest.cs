using FluentAssertions;
using Negocio.Calculos;
using Negocio.EntitiesDTO;
using Negocio.Enums;

namespace TestProject.Testing
{
    public class CalculosRecurrentesMensualesTest
    {
        [Fact]
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo0_DiaAnterior_FechaActual()
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo0_DiaAnterior_FechaActual_Febrero()
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo0_DiaPosterior_FechaActual()
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo0_DiaIgual_FechaActual()
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo0_Dia31_FechaActual()
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_PrimerLunes_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 5),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Primero,
                    DiaSemana = DiasSemana.Lunes,
                    CantidadMeses = 1
                }
            };
            var salidaEsperada = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024,4,1)
            };

            // Act
            var salidaResultado = calculo.CalculoFechaEjecucion(entrada);

            // Assert
            salidaResultado.Should().Be(salidaEsperada.FechaEjecucion);
        }

        [Fact]
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_PrimerLunes_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 3),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Primero,
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_SegundoLunes_FechaActualAnterior()
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_SegundoLunes_FechaActualPosterior()
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_TercerLunes_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 5),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Tercero,
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_TercerLunes_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 19),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Tercero,
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_CuartoLunes_FechaActualAnterior()
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_CuartoLunes_FechaActualPosterior()
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_PrimerMartes_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 6),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Primero,
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_PrimerMartes_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 2),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Primero,
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_SegundoMartes_FechaActualAnterior()
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_SegundoMartes_FechaActualPosterior()
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_TercerMartes_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 5),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Tercero,
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_TercerMartes_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 20),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Tercero,
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_CuartoMartes_FechaActualAnterior()
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_CuartoMartes_FechaActualPosterior()
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_PrimerMiercoles_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 13),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Primero,
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_PrimerMiercoles_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 3),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Primero,
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_SegundoMiercoles_FechaActualAnterior()
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_SegundoMiercoles_FechaActualPosterior()
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_TercerMiercoles_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 13),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Tercero,
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_TercerMiercoles_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 27),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Tercero,
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_CuartoMiercoles_FechaActualAnterior()
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_CuartoMiercoles_FechaActualPosterior()
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_PrimerJueves_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 12),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Primero,
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_PrimerJueves_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 3),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Primero,
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_SegundoJueves_FechaActualAnterior()
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_SegundoJueves_FechaActualPosterior()
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_TercerJueves_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 5),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Tercero,
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_TercerJueves_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 26),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Tercero,
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_CuartoJueves_FechaActualAnterior()
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_CuartoJueves_FechaActualPosterior()
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_PrimerViernes_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 8),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Primero,
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_PrimerViernes_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 1),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Primero,
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_SegundoViernes_FechaActualAnterior()
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_SegundoViernes_FechaActualPosterior()
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_TercerViernes_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 5),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Tercero,
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_TercerViernes_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 19),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Tercero,
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_CuartoViernes_FechaActualAnterior()
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_CuartoViernes_FechaActualPosterior()
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_PrimerSabado_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 5),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Primero,
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_PrimerSabado_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 1),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Primero,
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_SegundoSabado_FechaActualAnterior()
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_SegundoSabado_FechaActualPosterior()
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_TercerSabado_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 5),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Tercero,
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_TercerSabado_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 19),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Tercero,
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_CuartoSabado_FechaActualAnterior()
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_CuartoSabado_FechaActualPosterior()
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_PrimerDomingo_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 5),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Primero,
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_PrimerDomingo_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 2),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Primero,
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_SegundoDomingo_FechaActualAnterior()
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_SegundoDomingo_FechaActualPosterior()
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_TercerDomingo_FechaActualAnterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 5),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Tercero,
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_TercerDomingo_FechaActualPosterior()
        {
            // Arrange
            var calculo = new CalculosRecurrentesMensuales();
            var entrada = new EntradaDTO
            {
                FechaActual = new DateTime(2024, 3, 19),
                ConfiguracionMensual = new ConfiguracionMensualDTO
                {
                    Tipo = new bool[] { false, true },
                    FrecuenciaDia = FrecuenciasDia.Tercero,
                    DiaSemana = DiasSemana.Lunes,
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_CuartoDomingo_FechaActualAnterior()
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
        public void CalculoFechaEjecucion_Recurrente_Mensual_Tipo1_CuartoDomingo_FechaActualPosterior()
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

    }    

}
