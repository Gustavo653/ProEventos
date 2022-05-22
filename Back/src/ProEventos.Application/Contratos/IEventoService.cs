using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Application.Contratos
{
    public interface IEventoService
    {
         Task<Evento> AddEvento(Evento model);
         Task<Evento> UpdateEVento(int eventoId, Evento model);
         Task<bool> DeleteEventos(int eventoId);

    }
}