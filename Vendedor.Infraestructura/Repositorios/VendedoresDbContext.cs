using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using Vendedor.Dominio.Entidades;
using Vendedor.Dominio.ObjetoValor;
using Vendedor.Infraestructura.Adaptadores.Configuraciones;
using Vendedor.Infraestructura.Configuraciones;

namespace Productos.Infraestructura.Adaptadores.Repositorios
{
    [ExcludeFromCodeCoverage]
    public class VendedoresDbContext : DbContext
    {
        public VendedoresDbContext(DbContextOptions<VendedoresDbContext> options): base(options){ }

        public DbSet<Vendedor.Dominio.Entidades.Vendedor> Vendedores { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<ReporteVentas> ReporteVentas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VendedorConfiguracion());
            modelBuilder.ApplyConfiguration(new TipoDocumentoConfiguracion());
            modelBuilder.ApplyConfiguration(new ReporteVentasConfiguracion());
        }
    }
}
