using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RinkuNomina.Domain.Model;

namespace RinkuNomina.Infrastructure.Mappings
{
    public class SueldoBaseConfiguration : IEntityTypeConfiguration<SueldoBase>
    {
        public void Configure(EntityTypeBuilder<SueldoBase> builder)
        {
            builder.ToTable("SueldoBase");
            builder.Property(model => model.IdSueldoBase).HasColumnName("IdSueldoBase").HasDefaultValueSql("NEWSEQUENTIALID()").HasComment("Llave principal de la tabla");

        }
    }
}
