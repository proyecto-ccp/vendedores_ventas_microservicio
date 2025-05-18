
using Vendedor.Dominio.Puerto.Repositorios;

namespace Vendedor.Dominio.Servicios.Vendedores
{
    public class ReporteVentas(IReporteVentasRepositorio reporteRepositorio)
    {
        private readonly IReporteVentasRepositorio _reporteRepositorio = reporteRepositorio;

        public async Task<List<Entidades.ReporteVentas>> ObtenerReporte(Guid idVendedor, DateOnly fechaInicio, DateOnly fechaFin)
        {
            return await _reporteRepositorio.ObtenerReporteVentas(idVendedor, fechaInicio, fechaFin);
        }
    }
}
