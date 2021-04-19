using JMusic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JMusic.Data.Configuration
{
    public class DetalleOrdenConfiguration : IEntityTypeConfiguration<DetalleOrden>
    {
        public void Configure(EntityTypeBuilder<DetalleOrden> builder)
        {
            builder.ToTable("DetalleOrden", "tienda");

            builder.HasIndex(e => e.OrdenId);

            builder.HasIndex(e => e.ProductoId);

            builder.Property(e => e.Cantidad).HasColumnType("decimal(18, 2)");

            builder.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 2)");

            builder.Property(e => e.Total).HasColumnType("decimal(18, 2)");

            builder.HasOne(d => d.Orden)
                .WithMany(p => p.DetalleOrden)
                .HasForeignKey(d => d.OrdenId);

            builder.HasOne(d => d.Producto)
                .WithMany(p => p.DetalleOrden)
                .HasForeignKey(d => d.ProductoId);
        }
    }
}
