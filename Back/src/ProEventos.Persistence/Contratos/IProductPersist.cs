using ProEventos.Domain;
using System.Threading.Tasks;

namespace ProEventos.Persistence.Contratos
{
    public interface IProductPersist
    {
        Task<Product[]> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int productId);
    }
}