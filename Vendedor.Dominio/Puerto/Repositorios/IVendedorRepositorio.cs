
namespace Vendedor.Dominio.Puerto.Repositorios
{
    public interface IVendedorRepositorio
    {
        Task Guardar(Entidades.Vendedor vendedor);
        Task<Entidades.Vendedor> ObtenerVendedorPorId(Guid id);
        Task<Entidades.Vendedor> ObtenerVendedorPorDocumento(int idTipoDocumento, string numeroDocumento);
        Task<List<Entidades.Vendedor>> ObtenerVendedores();

    }
}
