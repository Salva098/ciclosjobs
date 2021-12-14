using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
#nullable disable

namespace ciclojobs.DAL.Entities
{
    public partial class ciclojobsContext : DbContext
    {

        public DbSet<Alumno> Alumno { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Ofertas> Ofertas { get; set; }
        public DbSet<Provincias> Provincias { get; set; }
        public DbSet<Inscripciones> Inscripciones { get; set; }
        public DbSet<Ciclo> Ciclo { get; set; }
        public DbSet<FamiliaProfe> FamiliaProfe { get; set; }
        public DbSet<TipoCiclo> TipoCiclo { get; set; }

        
        public ciclojobsContext()
        {
        }

        public ciclojobsContext(DbContextOptions<ciclojobsContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=123456;database=ciclojobs", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.26-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

         modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<Ofertas>()
                .HasMany(co => co.ciclo)
                .WithMany(co=> co.oferta);

            base.OnModelCreating(modelBuilder);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
