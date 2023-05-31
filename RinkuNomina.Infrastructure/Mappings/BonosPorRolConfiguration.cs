using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RinkuNomina.Domain.Model;

namespace RinkuNomina.Infrastructure.Mappings
{
    public class BonosPorRolConfiguration : IEntityTypeConfiguration<BonosPorRol>
    {
        public void Configure(EntityTypeBuilder<BonosPorRol> builder)
        {
            builder.ToTable("BonosPorRol");
            builder.Property(model => model.IdBonoRol).HasColumnName("IdBonoRol").HasDefaultValueSql("NEWSEQUENTIALID()").HasComment("Llave principal de la tabla");

        }
    }
}
