namespace LocadoraOscar.API.DTO
{
    /// <summary>
    /// DTO utilizado para que apareça para o usuário apenas as informações relevantes sobre o genero de um determinado filme.
    /// </summary>
    public class GeneroDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
