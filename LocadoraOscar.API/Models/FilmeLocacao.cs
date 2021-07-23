namespace LocadoraOscar.API.Models
{
    public class FilmeLocacao
    {
        public int FilmeId { get; set; }
        public Filme Filme { get; set; }
        public int LocacaoId { get; set; }
        public Locacao Locacao { get; set; }
    }
}
