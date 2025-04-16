
using Vendedor.Dominio.ObjetoValor;

namespace Vendedor.Dominio.Puerto.Repositorios
{
    public interface IDocumentoRepositorio
    {
        public Task<Documento> ObtenerDocumentoPorId(int tipoDocumento);
        public Task<List<Documento>> ListarTiposDocumento();
    }
}
