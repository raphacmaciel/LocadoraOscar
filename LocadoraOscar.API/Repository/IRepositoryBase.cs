using LocadoraOscar.API.Models;
using System.Threading.Tasks;

namespace LocadoraOscar.API.Repository
{
    public interface IRepositoryBase
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        //Filmes
        Task<Filme[]> ObterTodosFilmesAsync();
        Task<Filme> ObterFilmePorIdAsync(int id);
    }
}
