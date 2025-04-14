
using Vendedor.Dominio.ObjetoValor;
using Vendedor.Dominio.Puerto.Repositorios;

namespace Vendedor.Dominio.Servicios.Documentos
{
    public class Listar (IDocumentoRepositorio documentoRepositorio)
    {
        private readonly IDocumentoRepositorio _documentoRepositorio = documentoRepositorio;

        public async Task<List<Documento>> Ejecutar()
        {
            return await _documentoRepositorio.ListarTiposDocumento();
        }

    }
}
