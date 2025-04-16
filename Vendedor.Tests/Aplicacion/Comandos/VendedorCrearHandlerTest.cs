
using AutoMapper;
using Moq;
using Vendedor.Aplicacion.Comun;
using Vendedor.Aplicacion.Vendedor.Comandos;
using Vendedor.Aplicacion.Vendedor.Mapeadores;
using Vendedor.Dominio.ObjetoValor;
using Vendedor.Dominio.Puerto.Repositorios;
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

        public VendedorCrearHandlerTest() 
        {
            mockDocumentoRepositorio = new Mock<IDocumentoRepositorio>();
            mockVendedorRepositorio = new Mock<IVendedorRepositorio>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new VendedorMapeador()));
            _mapper = config.CreateMapper();
            _registrarVendedor = new Registrar(mockDocumentoRepositorio.Object, mockVendedorRepositorio.Object);
        }

        [Theory]
        [ClassData(typeof(VendedorCrearHandlerDataTest))]
        public async Task VendedorCrearComando(Documento documento, VendedorCrear peticion, BaseOut validacion) 
        {
            mockDocumentoRepositorio.Setup(m => m.ObtenerDocumentoPorId(It.IsAny<int>())).ReturnsAsync(documento);

            var objPrueba = new VendedorCrearHandler(_mapper, _registrarVendedor);

            var resultado = await objPrueba.Handle(peticion, CancellationToken.None);

            var verResultado = Assert.IsType<BaseOut>(resultado);
            Assert.Equal(validacion.Resultado, verResultado.Resultado);
            Assert.Contains(validacion.Mensaje, verResultado.Mensaje);
            Assert.Equal(validacion.Status, verResultado.Status);   

        }

    }
}
