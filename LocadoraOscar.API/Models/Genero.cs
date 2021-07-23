using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LocadoraOscar.API.Models
{
    public class Genero
    {
        #region Construtores
        public Genero() { }
        public Genero(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
        public Genero(int id, string nome, DateTime dataDeCriacao, bool ativo) : this(id, nome)
        {
            DataDeCriacao = dataDeCriacao;
            Ativo = ativo;
        }
        #endregion

        #region Propriedades

        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        public string Nome { get; set; }
        public DateTime DataDeCriacao { get; set; } = DateTime.Now;
        public bool Ativo { get; set; } = true;
        public IEnumerable<Filme> Filmes { get; set; }

        #endregion
    }
}