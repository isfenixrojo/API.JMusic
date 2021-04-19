using JMusic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JMusic.Data.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario", "tienda");

            builder.HasIndex(e => e.PerfilId);

            builder.Property(e => e.Apellidos).HasMaxLength(256);

            builder.Property(e => e.Email).HasMaxLength(100);

            builder.Property(e => e.Nombre).HasMaxLength(50);

            builder.Property(e => e.Password).HasMaxLength(512);

            builder.Property(e => e.Username).HasMaxLength(25);

            builder.HasOne(d => d.Perfil)
                .WithMany(p => p.Usuario)
                .HasForeignKey(d => d.PerfilId);
        }
    }
}
