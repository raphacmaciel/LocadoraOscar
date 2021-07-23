using System;
using System.ComponentModel.DataAnnotations;

namespace LocadoraOscar.API.DTO
{
    /// <summary>
    /// DTO utilizado para exibir somente o necessário para o usuário.
    /// </summary>
    public class FilmeDTO
    {
        public int Id { get; set; }
        [StringLength(200)]
        [Required]
        public string Nome { get; set; }
        public GeneroDTO Genero { get; set; }
        public DateTime DataDeCriacao { get; set; }
        public bool Ativo { get; set; }
    }
}
