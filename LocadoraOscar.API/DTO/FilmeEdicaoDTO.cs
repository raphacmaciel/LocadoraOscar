using System.ComponentModel.DataAnnotations;

namespace LocadoraOscar.API.DTO
{
    /// <summary>
    /// DTO utilizado para realizar a edição de um filme.
    /// </summary>
    public class FilmeEdicaoDTO
    {
        public int Id { get; set; }
        [StringLength(200)]
        [Required]
        public string Nome { get; set; }
        public int GeneroId { get; set; }
        public bool Ativo { get; set; }
    }
}
