using Fiap.Api.Donation3.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.Donation3.Data
{
    public class DataContext : DbContext
    {
        public DbSet<CategoriaModel> Categorias { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }


        // Fluent API - EF
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
            modelBuilder.Entity<UsuarioModel>(entity =>
            {
                entity.ToTable("Usuario");
                entity.HasKey(e => e.UsuarioId);
                entity.Property(e => e.UsuarioId).ValueGeneratedOnAdd();
                entity.Property(e => e.NomeUsuario)
                            .IsRequired()
                            .HasMaxLength(50);
                entity.Property(e => e.Senha)
                            .IsRequired()
                            .HasMaxLength(50);
                entity.Property(e => e.Regra)
                            .IsRequired();
                entity.Property(e => e.EmailUsuario)
                            .IsRequired();
            });
            modelBuilder.Entity<UsuarioModel>().HasData(
                new UsuarioModel()
                {
                    UsuarioId = 1,
                    NomeUsuario = "Eduardo",
                    Senha = "123456"
                ,
                    EmailUsuario = "Teste@teste.com",
                    Regra = "Sim"
                },
                new UsuarioModel()
                {
                    UsuarioId = 2,
                    NomeUsuario = "Suelen",
                    Senha = "654321"
                ,
                    EmailUsuario = "Teste2@teste.com",
                    Regra = "não"
                }
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
