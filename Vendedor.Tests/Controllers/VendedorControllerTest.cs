
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ServicioVendedor.Api.Controllers;
using System.Net;
using Vendedor.Aplicacion.Comun;
using Vendedor.Aplicacion.Vendedor.Comandos;

namespace Vendedor.Tests.Controllers
{
    public class VendedorControllerTest
    {
        private readonly Mock<IMediator> mockMediator;

        public VendedorControllerTest()
        {
            mockMediator = new Mock<IMediator>();
        }


        [Theory]
        [InlineData(Resultado.Exitoso, HttpStatusCode.Created)]
        [InlineData(Resultado.Error, HttpStatusCode.InternalServerError)]
        public async Task Crear_respuestas(Resultado enumRes, HttpStatusCode status) 
        { 
            var output = new BaseOut
            {
                Resultado = enumRes,
                Status = status
            };

            mockMediator.Setup(m => m.Send(It.IsAny<VendedorCrear>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(output);

            var objPrueba = new VendedorController(mockMediator.Object);

            var comando = new VendedorCrear(
                idTipoDocumento: 1,
                NumeroDocumento: "123456789",
                Nombre: "Juan",
                Apellido: "Pérez",
                Telefono: "(+57) 123-456-7890",
                Correo: "correo@correo.com",
                Direccion: "Carrera 1 # 1-1"
                );

            var resultado = await objPrueba.Crear(comando);

            Assert.NotNull(resultado);

            if (enumRes == Resultado.Exitoso)
            {
                var verResultado = Assert.IsType<CreatedResult>(resultado);
                var res = verResultado.Value as BaseOut;
                Assert.IsType<BaseOut>(res);
                Assert.Equal(201, verResultado.StatusCode);
            }
            else 
            {
                var verResultado = Assert.IsType<ObjectResult>(resultado);
                var res = verResultado.Value as ProblemDetails;
                Assert.IsType<ProblemDetails>(res);
                Assert.Equal(500, verResultado.StatusCode);
            }
        }
    }
}
