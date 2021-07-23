using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LocadoraOscar.API.Models
{
    public class Filme
    {
        #region Construtores

        public Filme() { }
        public Filme(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
        public Filme(int id, string nome, int generoId) : this(id, nome)
        {
            GeneroId = generoId;
        }
        public Filme(int id, string nome, int generoId, DateTime dataDeCriacao, bool ativo) : this(id, nome, generoId)
        {
            DataDeCriacao = dataDeCriacao;
            Ativo = ativo;
        }

        #endregion

        #region Propriedades

        public int Id { get; set; }

        [StringLength(200)]
        [Required]
        public string Nome { get; set; }
        public Genero Genero { get; set; }
        public int GeneroId { get; set; }
        public DateTime DataDeCriacao { get; set; } = DateTime.Now;
        public bool? Ativo { get; set; } = true;
        public IEnumerable<FilmeLocacao> FilmesLocacoes { get; set; }

        #endregion
    }
}