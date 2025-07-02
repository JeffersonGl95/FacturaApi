using FacturaApi.Controllers;
using FacturaApi.Models;
using FacturaApi.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace FacturaApiTest.Tests { 

public class UnitTest1
{
  

        [Fact]
        public void PostFactura_DeberiaRetornarCreated_AlGuardarFactura()
        {
            // Arrange
            var mockRepo = new Mock<FacturaService>();
            var controller = new FacturaController(mockRepo.Object);

            var factura = new Factura
            {
                NumeroFactura = "FAC-0001",
                Fecha = new DateTime(),
                Identificacion = "1712345678",
                Nombre = "María Pérez",
                Proveedor = "Distribuidora XYZ",
                Cantidad = 3,
                ProductoId = 3,
                SubproductoId = 2,
                Subtotal = (decimal)100.0,
                Iva = (decimal)15.0,
                Total = (decimal)115.0,
                Sincronizada = false
            };

            List<Factura> facturas = new List<Factura> { factura };
            // Act
            var resultado = controller.Post(facturas);

            // Assert



            var createdResult = Assert.IsType<CreatedAtActionResult>(resultado);
            Assert.Equal("PostFactura", createdResult.ActionName);
            var resultadoFactura = Assert.IsType<Factura>(createdResult.Value);
            Assert.Equal("FAC-001", resultadoFactura.NumeroFactura);
            mockRepo.Verify(r => r.Crear(It.IsAny<Factura>()), Times.Once);
        }

        [Fact]
        public void PostFactura_ConFacturaNula_DeberiaRetornarBadRequest()
        {
            var mockRepo = new Mock<FacturaService>();
            var controller = new FacturaController(mockRepo.Object);

            var resultado = controller.Post(null);

            var badRequest = Assert.IsType<BadRequestObjectResult>(resultado);
            Assert.Equal(HttpStatusCode.BadRequest, badRequest.Value);
        }


    
}
}