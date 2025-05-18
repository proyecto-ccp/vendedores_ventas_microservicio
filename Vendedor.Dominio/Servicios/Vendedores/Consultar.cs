
using Vendedor.Dominio.Puerto.Repositorios;

namespace Vendedor.Dominio.Servicios.Vendedores
{
    public class Consultar(IVendedorRepositorio vendedorRepositorio)
    {
        private readonly IVendedorRepositorio _vendedorRepositorio = vendedorRepositorio;
        public async Task<List<Entidades.Vendedor>> Vendedores()
        {
            return await _vendedorRepositorio.ObtenerVendedores();
        }

        public async Task<Entidades.Vendedor> VendedorPorId(Guid id)
        {
            return await _vendedorRepositorio.ObtenerVendedorPorId(id);
        }

        public async Task<Entidades.Vendedor> VendedorPorDocumento(int idTipoDocumento, string numeroDocumento)
        {
            return await _vendedorRepositorio.ObtenerVendedorPorDocumento(idTipoDocumento, numeroDocumento);
        }

    }
}
