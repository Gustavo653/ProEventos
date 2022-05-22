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
        void DeleteRange<t>(t[] entityArray) where t : class;
        Task<bool> SaveChangesAsync();

        //Eventos
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrante);
        Task<Evento[]> GetAllEventosAsync(bool includePalestrante);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrante);

        //Palestrantes
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool incluedPalestrante);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool incluedPalestrante);
        Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool incluedPalestrante);
    }
}