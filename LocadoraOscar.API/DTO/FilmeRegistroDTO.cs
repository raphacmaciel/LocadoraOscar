using System.ComponentModel.DataAnnotations;

namespace LocadoraOscar.API.DTO
{
    /// <summary>
    /// DTO utilizado para realizar o cadastro de um novo filme.
    /// </summary>
    public class FilmeRegistroDTO
    {
        [StringLength(200)]
        [Required]
        public string Nome { get; set; }
        public int GeneroId { get; set; }
    }
}
