
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;
using Vendedor.Dominio.ObjetoValor;

namespace Vendedor.Infraestructura.Configuraciones
{
    [ExcludeFromCodeCoverage]
    public class TipoDocumentoConfiguracion : IEntityTypeConfiguration<Documento>
    {
        public void Configure(EntityTypeBuilder<Documento> builder)
        {
            builder.ToTable("tbl_tipodocumento");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id").IsRequired().ValueGeneratedOnAdd();

            builder.Property(x => x.Nombre)
                .HasColumnName("nombre")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Codigo)
                .HasColumnName("codigo")
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(x => x.Codigo)
                .IsUnique();
        }

    }
}
