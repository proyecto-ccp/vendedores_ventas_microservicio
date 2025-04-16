
namespace Vendedor.Dominio.Puerto.Repositorios
{
    public interface IVendedorRepositorio
    {
        Task Guardar(Entidades.Vendedor vendedor);

    }
}
