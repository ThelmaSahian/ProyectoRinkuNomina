using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RinkuNomina.Domain.Model;

namespace RinkuNomina.Infrastructure.Mappings
{
    public class EntregasPorEmpleadoConfiguration : IEntityTypeConfiguration<EntregasPorEmpleado>
    {
        public void Configure(EntityTypeBuilder<EntregasPorEmpleado> builder)
        {
            builder.ToTable("EntregasPorEmpleado");
            builder.Property(model => model.IdEntrega).HasColumnName("IdEntrega").HasDefaultValueSql("NEWSEQUENTIALID()").HasComment("Llave principal de la tabla");

        }
    }
}
