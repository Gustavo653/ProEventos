using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence
{
    public class ProEventosPersistence : IProEventosPersistence
    {
        private readonly ProEventosContext _context;
        public ProEventosPersistence(ProEventosContext context)
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


        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrante = false)
        {
            IQueryable<Evento> query = _context.Eventos.Include(e => e.Lotes).Include(e => e.RedesSociais);
            if (includePalestrante)
                query = query.Include(e => e.PalestrantesEventos).ThenInclude(pe => pe.Palestrante);
            query = query.OrderBy(e => e.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrante = false)
        {
            IQueryable<Evento> query = _context.Eventos.Include(e => e.Lotes).Include(e => e.RedesSociais);
            if (includePalestrante)
                query = query.Include(e => e.PalestrantesEventos).ThenInclude(pe => pe.Palestrante);
            query = query.OrderBy(e => e.Id).Where(e => e.Tema.ToLower().Contains(tema.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrante = false)
        {
            IQueryable<Evento> query = _context.Eventos.Include(e => e.Lotes).Include(e => e.RedesSociais);
            if (includePalestrante)
                query = query.Include(e => e.PalestrantesEventos).ThenInclude(pe => pe.Palestrante);
            query = query.OrderBy(e => e.Id).Where(e => e.Id == eventoId);
            return await query.FirstOrDefaultAsync();
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