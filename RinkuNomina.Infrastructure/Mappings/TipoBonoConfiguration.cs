using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RinkuNomina.Domain.Model;

namespace RinkuNomina.Infrastructure.Mappings
{
    public class TipoBonoConfiguration : IEntityTypeConfiguration<TipoBono>
    {
        public void Configure(EntityTypeBuilder<TipoBono> builder)
        {
            builder.ToTable("TipoBono");
            builder.Property(model => model.IdTipoBono).HasColumnName("IdTipoBono").HasDefaultValueSql("NEWSEQUENTIALID()").HasComment("Llave principal de la tabla");

        }
    }
}
