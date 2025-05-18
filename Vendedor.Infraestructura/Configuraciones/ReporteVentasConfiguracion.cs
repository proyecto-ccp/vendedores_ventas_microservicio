
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vendedor.Dominio.Entidades;

namespace Vendedor.Infraestructura.Configuraciones
{
    public class ReporteVentasConfiguracion : IEntityTypeConfiguration<ReporteVentas>
    {
        public void Configure(EntityTypeBuilder<ReporteVentas> builder)
        {
            builder.HasNoKey();
        }
    }
}
