
using System.Diagnostics.CodeAnalysis;
using Vendedor.Dominio.Puerto.Repositorios;
using Vendedor.Infraestructura.Adaptadores.RepositorioGenerico;

namespace Vendedor.Infraestructura.Adaptadores.Repositorios
{
    [ExcludeFromCodeCoverage]
    public class VendedorRepositorio : IVendedorRepositorio
    {
        private readonly IRepositorioBase<Dominio.Entidades.Vendedor> _repositorioVendedor;

        public VendedorRepositorio(IRepositorioBase<Dominio.Entidades.Vendedor> repositorioVendedor)
        {
            _repositorioVendedor = repositorioVendedor;
        }

        public async Task Guardar(Dominio.Entidades.Vendedor vendedor)
        {
            await _repositorioVendedor.Guardar(vendedor);
        }

        public async Task<Dominio.Entidades.Vendedor> ObtenerVendedorPorId(Guid id)
        {
            return await _repositorioVendedor.BuscarPorLlave(id);
        }

        public async Task<Dominio.Entidades.Vendedor> ObtenerVendedorPorDocumento(int idTipoDocumento, string numeroDocumento)
        {
            return await _repositorioVendedor.BuscarPorCampos(x => x.IdTipoDocumento == idTipoDocumento && x.NumeroDocumento == numeroDocumento);
        }

        public async Task<List<Dominio.Entidades.Vendedor>> ObtenerVendedores()
        {
            return await _repositorioVendedor.DarListado();
        }

    }
}
