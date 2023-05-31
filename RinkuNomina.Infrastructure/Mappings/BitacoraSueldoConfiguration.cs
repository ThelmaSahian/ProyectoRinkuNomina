using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RinkuNomina.Domain.Model;

namespace RinkuNomina.Infrastructure.Mappings
{
    public class BitacoraSueldoConfiguration : IEntityTypeConfiguration<BitacoraSueldo>
    {
        public void Configure(EntityTypeBuilder<BitacoraSueldo> builder)
        {
            builder.ToTable("BitacoraSueldo");
            builder.Property(model => model.IdBitacoraSueldo).HasColumnName("IdBitacoraSueldo").HasDefaultValueSql("NEWSEQUENTIALID()").HasComment("Llave principal de la tabla");

        }
    }
}
