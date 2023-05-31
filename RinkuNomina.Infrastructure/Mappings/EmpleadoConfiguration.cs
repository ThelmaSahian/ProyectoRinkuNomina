using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RinkuNominaDomain.Model;

namespace RinkuNomina.Infrastructure.Mappings
{
    public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.ToTable("Empleado");
            builder.Property(model => model.IdEmpleado).HasColumnName("IdEmpleado").HasDefaultValueSql("NEWSEQUENTIALID()").HasComment("Llave principal de la tabla");

        }
    }
}
