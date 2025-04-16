
using AutoMapper;
using Moq;
using System.Net;
using Vendedor.Aplicacion.Comun;
using Vendedor.Aplicacion.Documento.Dto;
using Vendedor.Aplicacion.Documento.Mapeadores;
using Vendedor.Aplicacion.Vendedor.Consultas;
using Vendedor.Dominio.ObjetoValor;
using Vendedor.Dominio.Puerto.Repositorios;
using Vendedor.Dominio.Servicios.Documentos;
using Vendedor.Tests.Aplicacion.DataTests;

namespace Vendedor.Tests.Aplicacion.Consultas
{
    public class TiposDocumentoHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Listar _listarDocumentos;
        private readonly Mock<IDocumentoRepositorio> mockDocumentoRepositorio;

        public TiposDocumentoHandlerTest() 
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new TipoDocumentosMapeador()));
            _mapper = config.CreateMapper();
            mockDocumentoRepositorio = new Mock<IDocumentoRepositorio>();
            _listarDocumentos = new Listar(mockDocumentoRepositorio.Object);
        
        }


        [Theory]
        [ClassData(typeof(TiposDocumentoHandlerDataTest))]
        public async Task TiposDocumentoHandler_Respuestas(List<Documento> documentos, ListaTipoDocumentosOut respuesta)
        {
            mockDocumentoRepositorio.Setup(m => m.ListarTiposDocumento()).ReturnsAsync(documentos);
            
            var objPrueba = new TiposDocumentoHandler(_listarDocumentos, _mapper);

            var resultado = await objPrueba.Handle(new TiposDocumentoConsulta(), CancellationToken.None);

            var verResultado = Assert.IsType<ListaTipoDocumentosOut>(resultado);
            Assert.Equal(respuesta.Resultado, verResultado.Resultado);
            Assert.Contains(respuesta.Mensaje, verResultado.Mensaje);
            Assert.Equal(respuesta.Status, verResultado.Status);
            Assert.Equal(respuesta.Documentos.Count, verResultado.Documentos.Count);

        }

        [Fact]
        public async Task TiposDocumentoHandler_Excepcion()
        {
            mockDocumentoRepositorio.Setup(m => m.ListarTiposDocumento()).ThrowsAsync(new Exception("Error en la consulta"));
            var objPrueba = new TiposDocumentoHandler(_listarDocumentos, _mapper);
            var resultado = await objPrueba.Handle(new TiposDocumentoConsulta(), CancellationToken.None);
            var verResultado = Assert.IsType<ListaTipoDocumentosOut>(resultado);
            Assert.Equal(Resultado.Error, verResultado.Resultado);
            Assert.Contains("Error en la consulta", verResultado.Mensaje);
            Assert.Equal(HttpStatusCode.InternalServerError, verResultado.Status);
        }


    }
}
