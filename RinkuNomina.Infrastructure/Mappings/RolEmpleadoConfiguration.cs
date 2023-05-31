using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RinkuNomina.Domain.Model;

namespace RinkuNomina.Infrastructure.Mappings
{
    public class RolEmpleadoConfiguration : IEntityTypeConfiguration<RolEmpleado>
    {
        public void Configure(EntityTypeBuilder<RolEmpleado> builder)
        {
            builder.ToTable("RolEmpleado");
            builder.Property(model => model.IdRol).HasColumnName("IdRol").HasDefaultValueSql("NEWSEQUENTIALID()").HasComment("Llave principal de la tabla");

        }
    }
}
