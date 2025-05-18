
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Productos.Infraestructura.Adaptadores.Repositorios;
using Vendedor.Dominio.Entidades;
using Vendedor.Dominio.Puerto.Repositorios;

namespace Vendedor.Infraestructura.Repositorios
{
    public class ReporteVentasRepositorio : IReporteVentasRepositorio
    {
        private readonly IServiceProvider _serviceProvider;

        public ReporteVentasRepositorio(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        private VendedoresDbContext GetContext()
        {
            return _serviceProvider.GetService<VendedoresDbContext>();
        }

        public async Task<List<ReporteVentas>> ObtenerReporteVentas(Guid idVendedor, DateOnly fechaInicio, DateOnly fechaFin)
        {
            var ctx = GetContext();
            var reporte = await ctx.ReporteVentas.FromSqlRaw("SELECT * FROM fun_ventasporvendedor({0},{1},{2})", idVendedor, fechaInicio, fechaFin)
                .ToListAsync();
            await ctx.DisposeAsync();
            return reporte;
        }
    }
}
