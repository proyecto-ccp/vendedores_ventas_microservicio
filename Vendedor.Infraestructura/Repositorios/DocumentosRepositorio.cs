

using System.Diagnostics.CodeAnalysis;
using Vendedor.Dominio.ObjetoValor;
using Vendedor.Dominio.Puerto.Repositorios;
using Vendedor.Infraestructura.Adaptadores.RepositorioGenerico;

namespace Vendedor.Infraestructura.Adaptadores.Repositorios
{
    [ExcludeFromCodeCoverage]
    public class DocumentosRepositorio : IDocumentoRepositorio
    {
        private readonly IRepositorioBase<Documento> _documento;

        public DocumentosRepositorio(IRepositorioBase<Documento> documento)
        {
            _documento = documento;
        }

        public async Task<List<Documento>> ListarTiposDocumento()
        {
            return await _documento.DarListado();
        }

        public async Task<Documento> ObtenerDocumentoPorId(int tipoDocumento)
        {
            return await _documento.BuscarPorLlave(tipoDocumento);
        }
    }
}
