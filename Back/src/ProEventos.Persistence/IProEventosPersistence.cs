using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence
{
    public interface IProEventosPersistence
    {
        //Geral
        void Add<t>(t entity) where t : class;
        void Update<t>(t entity) where t : class;
        void Delete<t>(t entity) where t : class;
        void DeleteRange<t>(t entity) where t : class;
        Task<bool> SaveChangesAsync();

        //Eventos
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrante);
        Task<Evento[]> GetAllEventosAsync(bool includePalestrante);
        Task<Evento[]> GetEventoByIdAsync(int eventoId, bool includePalestrante);

        //Palestrantes
        Task<Evento[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos);
        Task<Evento[]> GetAllPalestrantesAsync(bool includeEventos);
        Task<Evento[]> GetPalestranteByIdAsync(int eventoId, bool includeEventos);
    }
}