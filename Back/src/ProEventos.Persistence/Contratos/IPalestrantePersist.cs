using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface IPalestrantePersist
    {
        //Palestrantes
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool incluedPalestrante);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool incluedPalestrante);
        Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool incluedPalestrante);
    }
}