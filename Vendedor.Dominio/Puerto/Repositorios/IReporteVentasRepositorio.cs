

using Vendedor.Dominio.Entidades;

namespace Vendedor.Dominio.Puerto.Repositorios
{
    public interface IReporteVentasRepositorio
    {
        Task<List<ReporteVentas>> ObtenerReporteVentas(Guid idVendedor, DateOnly fechaInicio, DateOnly fechaFin);
    }
}
