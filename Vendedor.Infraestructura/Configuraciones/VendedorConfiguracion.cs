

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace Vendedor.Infraestructura.Adaptadores.Configuraciones
{
    [ExcludeFromCodeCoverage]
    public class VendedorConfiguracion : IEntityTypeConfiguration<Dominio.Entidades.Vendedor>
    {
        public void Configure(EntityTypeBuilder<Dominio.Entidades.Vendedor> builder)
        {
            builder.ToTable("tbl_vendedor");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id").IsRequired().ValueGeneratedOnAdd();

            builder.Property(x => x.Nombre)
                .HasColumnName("nombre")
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Apellido)
                .HasColumnName("apellido")
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Direccion)
                .HasColumnName("direccion")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Correo)
                .HasColumnName("email")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Telefono)
               .HasColumnName("telefono")
               .IsRequired()
               .HasMaxLength(100);

            builder.Property(x => x.FechaCreacion)
                .HasColumnName("fecharegistro")
                .HasColumnType("timestamp(6)")
                .IsRequired();

            builder.Property(x => x.FechaModificacion)
                .HasColumnName("fechaactualizacion")
                .HasColumnType("timestamp(6)");

            builder.HasIndex(x => x.Nombre)
                .IsUnique();

            builder.HasIndex(x => x.Correo)
                .IsUnique();

            builder.Property(x => x.IdTipoDocumento)
                .HasColumnName("idtipodocumento")
                .IsRequired();

            builder.Property(x => x.NumeroDocumento)
                .HasColumnName("numerodocumento")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.Idzona)
                .HasColumnName("idzona")
                .IsRequired();

        }
    }
}
