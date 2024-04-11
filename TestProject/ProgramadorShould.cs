using Negocio.EntitiesDTO;
using Negocio.Enums;
using Negocio.Managament;
using Xunit;

namespace TestProject
{
    public class ProgramadorShould
    {
        //[Fact]
        //public void Comprobar_Tipo_Correcto()
        //{
        //    //Arrange
        //    var programador = new Programador();
        //    var entrada = new EntradaDTO
        //    {
        //        TiposCalculos = TiposCalculos.Una_vez
        //    };
        //    var tipoSalidaEsperada = TiposCalculos.Una_vez;

        //    //Act  
        //    var resultado = programador.Calcular(entrada);

        //    //Assert
        //    Assert.Equal(tipoSalidaEsperada,resultado.Tipo);
        //}

        [Theory]
        [InlineData (TiposCalculos.Una_vez, TiposCalculos.Una_vez)]
        [InlineData (TiposCalculos.Recurrente, TiposCalculos.Recurrente)]
        public void Comprobar_Tipo_Correcto(TiposCalculos entrada, TiposCalculos salida)
        {
            //Arrenge
            var programador = new Programador();
            
            //Act
            var resultado = programador.ComprobarTipo(entrada);

            //Assert
            Assert.Equal(salida, resultado);
        }

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

        [Theory]
        [InlineData (OcurrenciaCalculos.Diaria, 1)]
        [InlineData(OcurrenciaCalculos.Semanal, 7)]
        [InlineData(OcurrenciaCalculos.Quincenal, 15)]
        public void Comprobar_Fecha_Repeticion_Recurrente_Correcta(OcurrenciaCalculos ocurrencia, int dias)
        {
            //Arrenge
            var programador = new Programador();
            var fechaActual= DateTime.Now;
            DateTime fechaEsperada = fechaActual.AddDays(dias);

            //Act
            var fechaResultado = programador.RepeticionRecurrente(fechaActual, ocurrencia);

            //Assert3
            Assert.Equal(fechaEsperada, fechaResultado);
        }

        [Fact]
        public void Calcular_Datos_Salida_Correctos_Una_Vez()
        {
            //Arrenge
            var programador = new Programador();
            var entrada = new EntradaDTO
            {
                FechaActual = DateTime.Now,
                TiposCalculos = TiposCalculos.Una_vez,
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
            //Assert.Equal (salida, salidaResultado);
            Assert.Equal(salida.FechaEjecucion, salidaResultado.FechaEjecucion);
            Assert.Equal(salida.Tipo, salidaResultado.Tipo);
            Assert.Equal(salida.Descripcion, salidaResultado.Descripcion);

        }

        [Fact]
        public void Calcular_Datos_Salida_Correctos_Recurrente()
        {
            //Arrenge
            var programador = new Programador();
            var fechaActual = DateTime.Now;
            var entrada = new EntradaDTO
            {
                FechaActual = fechaActual,
                TiposCalculos = TiposCalculos.Recurrente,
                Ocurrencia = OcurrenciaCalculos.Diaria,
                FechaRepeticion = fechaActual.AddDays(1)
                
            };
            var salida = new SalidaDTO
            {
                FechaEjecucion = entrada.FechaRepeticion,
                Descripcion = $"Ocurre diariamente. El programador se utilizará el {entrada.FechaRepeticion.ToString(("dd/MM/yyyy"))}",
                Tipo = TiposCalculos.Recurrente

            };

            //Act
            var salidaResultado = programador.Calcular(entrada);

            //Assert
            //Assert.Equal (salida, salidaResultado);
            Assert.Equal(salida.FechaEjecucion, salidaResultado.FechaEjecucion);
            Assert.Equal(salida.Tipo, salidaResultado.Tipo);
            Assert.Equal(salida.Descripcion, salidaResultado.Descripcion);

        }

    }
}
