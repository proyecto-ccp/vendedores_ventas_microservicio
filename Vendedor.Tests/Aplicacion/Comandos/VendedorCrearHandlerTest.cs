
using AutoMapper;
using Moq;
using Vendedor.Aplicacion.Comun;
using Vendedor.Aplicacion.Vendedor.Comandos;
using Vendedor.Aplicacion.Vendedor.Mapeadores;
using Vendedor.Dominio.ObjetoValor;
using Vendedor.Dominio.Puerto.Integraciones;
using Vendedor.Dominio.Puerto.Repositorios;
using Vendedor.Dominio.Puertos.Integraciones;
using Vendedor.Dominio.Servicios.Vendedores;
using Vendedor.Tests.Aplicacion.DataTests;

namespace Vendedor.Tests.Aplicacion.Comandos
{
    public class VendedorCrearHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Registrar _registrarVendedor;
        private readonly Mock<IDocumentoRepositorio> mockDocumentoRepositorio;
        private readonly Mock<IVendedorRepositorio> mockVendedorRepositorio;
        private readonly Mock<IServicioAuditoriaApi> mockServicioAuditoriaApi;
        private readonly Mock<IServicioUsuariosApi> mockServicioUsuariosApi;

        public VendedorCrearHandlerTest() 
        {
            mockDocumentoRepositorio = new Mock<IDocumentoRepositorio>();
            mockVendedorRepositorio = new Mock<IVendedorRepositorio>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new VendedorMapeador()));
            _mapper = config.CreateMapper();
            _registrarVendedor = new Registrar(mockDocumentoRepositorio.Object, mockVendedorRepositorio.Object);
            mockServicioAuditoriaApi = new Mock<IServicioAuditoriaApi>();
            mockServicioUsuariosApi = new Mock<IServicioUsuariosApi>();
        }

        [Theory]
        [ClassData(typeof(VendedorCrearHandlerDataTest))]
        public async Task VendedorCrearComando(Documento documento, VendedorCrear peticion, BaseOut validacion) 
        {
            mockDocumentoRepositorio.Setup(m => m.ObtenerDocumentoPorId(It.IsAny<int>())).ReturnsAsync(documento);

            var objPrueba = new VendedorCrearHandler(_mapper, _registrarVendedor, mockServicioAuditoriaApi.Object, mockServicioUsuariosApi.Object);

            var resultado = await objPrueba.Handle(peticion, CancellationToken.None);

            var verResultado = Assert.IsType<BaseOut>(resultado);
            Assert.Equal(validacion.Resultado, verResultado.Resultado);
            Assert.Contains(validacion.Mensaje, verResultado.Mensaje);
            Assert.Equal(validacion.Status, verResultado.Status);   

        }

    }
}
