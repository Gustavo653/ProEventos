using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class PalestrantePersist : IPalestrantePersist
    {
        private readonly ProEventosContext _context;
        public PalestrantePersist(ProEventosContext context)
        {
            this._context = context;
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includePalestrante = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.Include(e => e.RedesSociais);
            if (includePalestrante)
                query = query.Include(e => e.PalestrantesEventos).ThenInclude(pe => pe.Evento);
            query = query.OrderBy(e => e.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includePalestrante = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.Include(e => e.RedesSociais);
            if (includePalestrante)
                query = query.Include(e => e.PalestrantesEventos).ThenInclude(pe => pe.Evento);
            query = query.OrderBy(e => e.Id).Where(e => e.Nome.ToLower().Contains(nome.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includePalestrante = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.Include(e => e.RedesSociais);
            if (includePalestrante)
                query = query.Include(e => e.PalestrantesEventos).ThenInclude(pe => pe.Evento);
            query = query.OrderBy(e => e.Id).Where(e => e.Id == palestranteId);
            return await query.FirstOrDefaultAsync();
        }
    }
}