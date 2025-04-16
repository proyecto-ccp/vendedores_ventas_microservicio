
using Vendedor.Dominio.ObjetoValor;
using Vendedor.Dominio.Puerto.Repositorios;

namespace Vendedor.Dominio.Servicios.Vendedores
{
    public class Registrar(IDocumentoRepositorio documentoRepositorio, IVendedorRepositorio vendedorRepositorio)
    {
        private readonly IDocumentoRepositorio _documentoRepositorio = documentoRepositorio;
        private readonly IVendedorRepositorio _vendedorRepositorio = vendedorRepositorio;

        private readonly string _paramErrorTipoDocumento = "TipoDocumento";

        public async Task Ejecutar(Entidades.Vendedor input)
        {
            var documento = await EstablecerDocumento(input);
            input.IdTipoDocumento = documento.Id;
            input.Id = Guid.NewGuid();
            input.FechaCreacion = DateTime.Now;
            await _vendedorRepositorio.Guardar(input);
        }

        private async Task<Documento> EstablecerDocumento(Entidades.Vendedor input)
        {
            var documento = await _documentoRepositorio.ObtenerDocumentoPorId(input.IdTipoDocumento) ?? throw new ArgumentNullException(_paramErrorTipoDocumento, "El tipo de documento no existe");
            return documento;
        }

    }
}
