using ProEventos.Application.Dtos;
using System.Threading.Tasks;

namespace ProEventos.Application.Contratos
{
    public interface IProductService
    {
        Task<ProductDTO> AddProduct(ProductDTO model);
        Task<ProductDTO> UpdateProduct(int productId, ProductDTO model);
        Task<bool> DeleteProduct(int productId);
    }
}