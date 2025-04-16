
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System.Net;
using Vendedor.Aplicacion.Comun;
using Vendedor.Aplicacion.Documento.Dto;
using Vendedor.Dominio.ObjetoValor;

namespace Vendedor.Tests.Aplicacion.DataTests
{
    public class TiposDocumentoHandlerDataTest : TheoryData<List<Documento>, ListaTipoDocumentosOut>
    {
        public TiposDocumentoHandlerDataTest() 
        {
            List<Documento> documentosOk =
            [
                    new () { Id = 1, Codigo = "CC", Nombre = "pruebas 1" },
                    new () { Id = 2, Codigo = "CE", Nombre = "pruebas 2"},
                    new () { Id = 3, Codigo = "NIT", Nombre = "pruebas 3"}
            ];

            var respuestaOk = new ListaTipoDocumentosOut
            {
                Resultado = Resultado.Exitoso,
                Mensaje = "Consulta exitosa",
                Status = HttpStatusCode.OK,
                Documentos =
                [
                    new () { Id = 1, Codigo = "CC", Nombre = "pruebas 1" },
                    new () { Id = 2, Codigo = "CE", Nombre = "pruebas 2"},
                    new () { Id = 3, Codigo = "NIT", Nombre = "pruebas 3"}
                ]
            };

            var respuestaVacio = new ListaTipoDocumentosOut
            {
                Resultado = Resultado.SinRegistros,
                Mensaje = "Tipos de documento no tiene valores",
                Status = HttpStatusCode.NoContent,
                Documentos = []
            };

            Add(documentosOk, respuestaOk);
            Add([], respuestaVacio);
            Add(null, respuestaVacio);

        }

    }
}
