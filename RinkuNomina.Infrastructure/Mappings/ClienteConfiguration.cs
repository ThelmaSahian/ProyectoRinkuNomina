using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RinkuNomina.Domain.Model;

namespace RinkuNomina.Infrastructure.Mappings
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.Property(model => model.IdCliente).HasColumnName("IdCliente").HasDefaultValueSql("NEWSEQUENTIALID()").HasComment("Llave principal de la tabla");

        }
    }
}
