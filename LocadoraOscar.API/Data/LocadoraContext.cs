using LocadoraOscar.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LocadoraOscar.API.Data
{
    public class LocadoraContext : DbContext
    {
        public LocadoraContext(DbContextOptions<LocadoraContext> options) : base(options) { }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }
        public DbSet<FilmeLocacao> FilmesLocacoes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilmeLocacao>(entity =>
            {
                entity.HasKey(e => new { e.FilmeId, e.LocacaoId });
            });

            modelBuilder.Entity<Filme>()
                .HasData(new List<Filme>(){
                    new Filme(1, "O Poderoso Chefão", 1),
                    new Filme(2, "O Rei Leão", 1),
                    new Filme(3, "Star Wars", 3),
                    new Filme(4, "Intocáveis", 4),
                    new Filme(5, "O Exorcista", 2)
                });

            modelBuilder.Entity<Genero>()
                .HasData(new List<Genero>(){
                    new Genero(1, "Ação e Aventura"),
                    new Genero(2, "Terror"),
                    new Genero(3, "Ficção Científica"),
                    new Genero(4, "Comédia")
                });
        }
    }
}
