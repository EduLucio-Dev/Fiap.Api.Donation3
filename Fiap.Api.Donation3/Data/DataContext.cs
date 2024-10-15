using Fiap.Api.Donation3.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.Donation3.Data
{
    public class DataContext : DbContext
    {
        public DbSet<CategoriaModel> Categorias { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }


        // Fluent API - EF
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Categoria
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
            #endregion

            #region Usuario
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
            #endregion


            #region Produto
            modelBuilder.Entity<ProdutoModel>(entity =>
            {
                entity.ToTable("Produto");
                entity.HasKey(e => e.ProdutoId);
                entity.Property(e => e.ProdutoId)
                  .ValueGeneratedOnAdd();

                entity.Property(e => e.Nome)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.SugestaoTroca)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(e => e.Valor)
                      .IsRequired()
                      .HasPrecision(18, 2);

                entity.Property(e => e.DataCadastro)
                      .IsRequired();

                entity.Property(e => e.DataExpiracao)
                      .IsRequired();

                // Relacionamento Categoria
                entity.HasOne(e => e.Categoria)
                        .WithMany()
                        .HasForeignKey(e => e.CategoriaId)
                        .IsRequired();

                // Relacionamento Usuario
                entity.HasOne(e => e.Usuario)
                        .WithMany()
                        .HasForeignKey(e => e.UsuarioId)
                        .IsRequired();
            });
            #endregion
        }


        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected DataContext()
        {
        }
    }
}
