using JMusic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JMusic.Data.Configuration
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Producto", "tienda");

            builder.Property(e => e.Nombre).HasMaxLength(256);

            builder.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
        }
    }
}
