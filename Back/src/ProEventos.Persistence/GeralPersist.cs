using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class GeralPersist : IGeralPersist
    {
        private readonly ProEventosContext _context;
        public GeralPersist(ProEventosContext context)
        {
            this._context = context;
        }

        public void Add<t>(t entity) where t : class
        {
            _context.Add(entity);
        }

        public void Update<t>(t entity) where t : class
        {
            _context.Update(entity);
        }

        public void Delete<t>(t entity) where t : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<t>(t[] entityArray) where t : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}