
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
    }
}
