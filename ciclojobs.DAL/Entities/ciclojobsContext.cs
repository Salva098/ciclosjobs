using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ciclojobs.DAL.Entities
{
    public partial class ciclojobsContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
