using System.Threading.Tasks;
using ProEventos.Application.Dtos;

namespace ProEventos.Application.Contratos
{
    public interface IProductService
    {
        Task<ProductDTO> AddProduct(ProductDTO model);
        Task<ProductDTO> UpdateProduct(int productId, ProductDTO model);
        Task<bool> DeleteProduct(int productId);
    }
}