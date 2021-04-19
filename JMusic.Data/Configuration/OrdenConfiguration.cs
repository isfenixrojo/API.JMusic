using JMusic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JMusic.Data.Configuration
{
    public class OrdenConfiguration : IEntityTypeConfiguration<Orden>
    {
        public void Configure(EntityTypeBuilder<Orden> builder)
        {
            builder.ToTable("Orden", "tienda");

            builder.HasIndex(e => e.UsuarioId);

            builder.Property(e => e.CantidadArticulos).HasColumnType("decimal(18, 2)");

            builder.Property(e => e.Importe).HasColumnType("decimal(18, 2)");

            builder.HasOne(d => d.Usuario)
                .WithMany(p => p.Orden)
                .HasForeignKey(d => d.UsuarioId);
        }
    }
}
