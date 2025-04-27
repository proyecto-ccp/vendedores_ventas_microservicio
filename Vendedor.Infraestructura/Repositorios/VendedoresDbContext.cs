using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using Vendedor.Infraestructura.Adaptadores.Configuraciones;

namespace Productos.Infraestructura.Adaptadores.Repositorios
{
    [ExcludeFromCodeCoverage]
    public class VendedoresDbContext : DbContext
    {
        public VendedoresDbContext(DbContextOptions<VendedoresDbContext> options): base(options){ }

        public DbSet<Vendedor.Dominio.Entidades.Vendedor> Vendedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VendedorConfiguracion());
        }
    }
}
