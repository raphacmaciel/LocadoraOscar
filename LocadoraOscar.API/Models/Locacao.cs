using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LocadoraOscar.API.Models
{
    public class Locacao
    {
        #region Construtores
        public Locacao() { }
        public Locacao(int id, IEnumerable<Filme> listaDeFilmes, string cpfDoCliente, DateTime dataDaLocacao)
        {
            Id = id;
            ListaDeFilmes = listaDeFilmes;
            CPFDoCliente = cpfDoCliente;
            DataDaLocacao = dataDaLocacao;
        }
        #endregion

        #region Propriedades
        public int Id { get; set; }
        [Required]
        public IEnumerable<Filme> ListaDeFilmes { get; set; }
        [StringLength(14)]
        [Required]
        public string CPFDoCliente { get; set; }
        [Required]
        public DateTime DataDaLocacao { get; set; }
        public IEnumerable<FilmeLocacao> FilmesLocacoes { get; set; }

        #endregion
    }
}
