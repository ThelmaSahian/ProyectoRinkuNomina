using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RinkuNomina.Domain.Model;

namespace RinkuNomina.Infrastructure.Mappings
{
    public class FrecuenciaBonoConfiguration : IEntityTypeConfiguration<FrecuenciaBono>
    {
        public void Configure(EntityTypeBuilder<FrecuenciaBono> builder)
        {
            builder.ToTable("FrecuenciaBono");
            builder.Property(model => model.IdFrecuenciaBono).HasColumnName("IdFrecuenciaBono").HasDefaultValueSql("NEWSEQUENTIALID()").HasComment("Llave principal de la tabla");

        }
    }
}
