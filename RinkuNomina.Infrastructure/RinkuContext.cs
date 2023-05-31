using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RinkuNomina.Infrastructure.Mappings;

namespace RinkuNomina.Application
{
    public class RinkuContext : DbContext
    {

        public RinkuContext()
        {
        }

        public RinkuContext(DbContextOptions<RinkuContext> options) : base(options)
        {
            this.Database.SetCommandTimeout(180);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConfigurationBuilder configurationBuilder = new();
            configurationBuilder.AddJsonFile(
                Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"), false);
            IConfiguration root = configurationBuilder.Build();
            var dbString = root.GetConnectionString("RinkuDb") ?? "";
            _ = optionsBuilder.UseSqlServer(dbString, builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            });
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BitacoraSueldoConfiguration());
            modelBuilder.ApplyConfiguration(new BonosPorRolConfiguration());
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new EmpleadoConfiguration());
            modelBuilder.ApplyConfiguration(new EntregasPorEmpleadoConfiguration());
            modelBuilder.ApplyConfiguration(new FrecuenciaBonoConfiguration());
            modelBuilder.ApplyConfiguration(new RolEmpleadoConfiguration());
            modelBuilder.ApplyConfiguration(new SueldoBaseConfiguration());
            modelBuilder.ApplyConfiguration(new TipoBonoConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}