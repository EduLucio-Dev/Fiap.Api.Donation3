using Fiap.Api.Donation3.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.Donation3.Data
{
    public class DataContext : DbContext
    {
        public DbSet<CategoriaModel> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CategoriaModel>(entity =>
            {
                entity.ToTable("Categoria");
                entity.HasKey(e => e.CategoriaId);
                entity.Property(e => e.CategoriaId).ValueGeneratedOnAdd();
                entity.Property(e => e.NomeCategoria)
                        .IsRequired()
                        .HasMaxLength(50);
            });
            modelBuilder.Entity<CategoriaModel>().HasData(
             new CategoriaModel() { CategoriaId = 1, NomeCategoria = "Celular"},
             new CategoriaModel() { CategoriaId = 2, NomeCategoria = "Celular" }
            );
        }


        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected DataContext()
        {
        }
    }
}
