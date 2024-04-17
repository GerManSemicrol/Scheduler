using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Negocio.Calculos;
using Negocio.EntitiesDTO;
using Negocio.Enums;

namespace TestProject.Testing
{
    public class DescripcionTest
    {
        [Fact]
        public void ObtenerDescripcion_TipoCalculoNulo_DeberiaRetornarNull()
        {
            // Arrange
            var descripcion = new Descripcion();
            var entrada = new EntradaDTO
            {
                TipoCalculo = TiposCalculos.nulo,                
            };            

            // Act
            var resultado = descripcion.ObtenerDescripcion(entrada);

            // Assert
            resultado.Should().BeNull();
        }

    }
}
