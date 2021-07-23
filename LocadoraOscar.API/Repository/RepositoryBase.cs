using LocadoraOscar.API.Data;
using LocadoraOscar.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraOscar.API.Repository
{
    public class RepositoryBase : IRepositoryBase
    {
        private readonly LocadoraContext _context;

        public RepositoryBase(LocadoraContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        //filme
        public async Task<Filme[]> ObterTodosFilmesAsync()
        {
            IQueryable<Filme> query = _context.Filmes;
            query = query.AsNoTracking().OrderBy(a => a.Id);
            query = query.Include(f => f.Genero);
            return await query.ToArrayAsync();
        }

        public async Task<Filme> ObterFilmePorIdAsync(int id)
        {
            IQueryable<Filme> query = _context.Filmes;
            query = query.AsNoTracking().OrderBy(a => a.Id).Include(f => f.Genero).Where(m => m.Id == id);
            return await query.FirstOrDefaultAsync();
        }
    }
}
