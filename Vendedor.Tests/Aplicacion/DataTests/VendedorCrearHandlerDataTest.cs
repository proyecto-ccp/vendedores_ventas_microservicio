
using System.Net;
using Vendedor.Aplicacion.Comun;
using Vendedor.Aplicacion.Vendedor.Comandos;
using Vendedor.Dominio.ObjetoValor;

namespace Vendedor.Tests.Aplicacion.DataTests
{
    public class VendedorCrearHandlerDataTest : TheoryData<Documento, VendedorCrear, BaseOut>
    {
        public VendedorCrearHandlerDataTest() 
        {
            var documentoOk = new Documento
            {
                Id = 1,
                Nombre = "CC",
                Codigo = "Cedula"

            };

            var comandoOk = new VendedorCrear(
                IdTipoDocumento: 1,
                NumeroDocumento: "123456789",
                Nombre: "Juan",
                Apellido: "Pérez",
                Telefono: "(+57) 123-456-7890",
                Correo: "correo@correo.com",
                Direccion: "Carrera 1 # 1-1",
                Idzona: Guid.NewGuid(),
                Contrasena: "Contrasena123",
                IdUsuario: Guid.NewGuid()
                );

            var respuestaOk = new BaseOut
            {
                Mensaje = "Vendedor creado correctamente",
                Resultado = Resultado.Exitoso,
                Status = HttpStatusCode.Created
            };

            var respuestaError = new BaseOut
            {
                Mensaje = "El tipo de documento no existe",
                Resultado = Resultado.Error,
                Status = HttpStatusCode.InternalServerError
            };

            Add(documentoOk, comandoOk, respuestaOk);
            Add(null, comandoOk, respuestaError);
        }

    }
}
