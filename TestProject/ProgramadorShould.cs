using Negocio.Calculos;
using Negocio.EntitiesDTO;
using Negocio.Enums;
using Negocio.Managament;
using Xunit;

namespace TestProject
{
    public class ProgramadorShould
    {
        //[Fact]
        //public void Comprobar_Fecha_Repeticion_Recurrente_Correcta_Diaria()
        //{
        //    //Arrenge
        //    var programador = new Programador();
        //    var entrada = new EntradaDTO
        //    {
        //        FechaActual = DateTime.Now,
        //        Ocurrencia = OcurrenciaCalculos.Diaria,
        //    };
        //    var fechaSalidaEsperada = entrada.FechaActual.AddDays(1);

        //    //Act
        //    var fechaResultado = programador.RepeticionRecurrente(entrada.FechaActual, entrada.Ocurrencia);

        //    //Assert3
        //    Assert.Equal(fechaSalidaEsperada, fechaResultado);
        //}

        //[Theory]
        //[InlineData (OcurrenciaCalculos.Diaria, 1)]
        //[InlineData(OcurrenciaCalculos.Semanal, 7)]
        //[InlineData(OcurrenciaCalculos.Quincenal, 15)]
        //public void Comprobar_Fecha_Repeticion_Recurrente_Correcta(OcurrenciaCalculos ocurrencia, int dias)
        //{
        //    //Arrenge
        //    var programador = new Programador();
        //    var fechaActual= DateTime.Now;
        //    DateTime fechaEsperada = fechaActual.AddDays(dias);

        //    //Act
        //    var fechaResultado = programador.RepeticionRecurrente(fechaActual, ocurrencia);

        //    //Assert3
        //    Assert.Equal(fechaEsperada, fechaResultado);
        //}

        [Fact]
        public void Calcular_Datos_Salida_Correctos_Una_Vez()
        {
            //Arrenge
            var programador = new Programador();
            var entrada = new EntradaDTO
            {
                FechaActual = DateTime.Now,
                TipoCalculo = TiposCalculos.Una_vez,
                FechaRepeticion = DateTime.Now.AddDays(2)
            };
            var salida = new SalidaDTO
            {
                FechaEjecucion = entrada.FechaRepeticion,
                Descripcion = $"Ocurre una vez. El programador se utilizará el {entrada.FechaRepeticion.ToString(("dd/MM/yyyy"))} a las " +
                    $"{entrada.FechaRepeticion.ToString(("HH:mm"))}",
                Tipo = TiposCalculos.Una_vez

            };

            //Act
            var salidaResultado = programador.Calcular(entrada);

            //Assert            
            Assert.Equal(salida.FechaEjecucion, salidaResultado.FechaEjecucion);
            Assert.Equal(salida.Tipo, salidaResultado.Tipo);
            Assert.Equal(salida.Descripcion, salidaResultado.Descripcion);
        }

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

        [Fact]
        public void Calcular_Datos_Salida_Correctos_Recurrente_Semanal_Una_Vez_Al_Dia()
        {
            //Arrenge
            var programador = new Programador();
            var fechaActual = DateTime.Now;
            var frecuenciaDiaria = new FrecuenciaDiariaDTO
            {
                TipoFrecuenciaDiaria = TiposCalculos.Una_vez,
                HoraInicio = new DateTime(fechaActual.Year, fechaActual.Month, fechaActual.Day, 15, 0, 0)
            };
            var configuracionSemanal = new ConfiguracionSemanalDTO
            {
                DiasSemana = new bool[7]
            };
            configuracionSemanal.DiasSemana[1] = true;

            var entrada = new EntradaDTO
            {
                FechaActual = fechaActual,
                TipoCalculo = TiposCalculos.Recurrente,
                Ocurrencia = OcurrenciaCalculos.Semanal,
                FechaRepeticion = new DateTime(2024, 04, 22),
                FrecuenciaDiaria = frecuenciaDiaria,
                ConfiguracionSemana = configuracionSemanal
            };
            var salida = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 04, 22, 15, 0, 0),
                Descripcion = $"Ocurre semanalmente. El programador se utilizará el 22/04/2024 a las 15:00",
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
        public void Calcular_Datos_Salida_Correctos_Recurrente_Semanal_Varias_Horas_Al_Dia()
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
            var configuracionSemanal = new ConfiguracionSemanalDTO
            {
                DiasSemana = new bool[7]
            };
            configuracionSemanal.DiasSemana[1] = true;

            var entrada = new EntradaDTO
            {
                FechaActual = fechaActual,
                TipoCalculo = TiposCalculos.Recurrente,
                Ocurrencia = OcurrenciaCalculos.Semanal,
                FechaRepeticion = new DateTime(2024, 04, 22),
                FrecuenciaDiaria = frecuenciaDiaria,
                ConfiguracionSemana = configuracionSemanal
            };
            var salida = new SalidaDTO
            {
                FechaEjecucion = new DateTime(2024, 04, 22, 16, 0, 0),
                Descripcion = $"Ocurre semanalmente. El programador se utilizará el 22/04/2024 desde las 14:00" +
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

        [Fact]
        public void Calcular_Datos_Salida_Correctos_Recurrente_Quincenal()
        {
            //Arrenge
            var programador = new Programador();
            var fechaActual = DateTime.Now;
            var frecuenciaDiaria = new FrecuenciaDiariaDTO
            {
                TipoFrecuenciaDiaria = TiposCalculos.Recurrente
            };
            var entrada = new EntradaDTO
            {
                FechaActual = fechaActual,
                TipoCalculo = TiposCalculos.Recurrente,
                Ocurrencia = OcurrenciaCalculos.Quincenal,
                FechaRepeticion = fechaActual.AddDays(15),
                FrecuenciaDiaria = frecuenciaDiaria

            };
            var salida = new SalidaDTO
            {
                FechaEjecucion = entrada.FechaRepeticion,
                Descripcion = $"Ocurre quincenalmente. El programador se utilizará el {entrada.FechaRepeticion.ToString(("dd/MM/yyyy"))} cada {entrada.FrecuenciaDiaria.TipoFrecuenciaDiaria} horas entre las" +
                        $" {entrada.FrecuenciaDiaria.HoraInicio.ToString("HH:mm:ss")} y las {entrada.FrecuenciaDiaria.HoraFin}",
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
