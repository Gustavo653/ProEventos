using AutoMapper;
using ProEventos.Application.Contratos;
using ProEventos.Application.Dtos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;
using System;
using System.Threading.Tasks;

namespace ProEventos.Application
{
    public class ProductService : IProductService
    {
        private readonly IProductPersist _productPersist;
        private readonly IGeralPersist _geralPersist;
        private readonly IMapper _mapper;
        public ProductService(IGeralPersist geralPersist, IMapper mapper, IProductPersist productPersist)
        {
            _mapper = mapper;
            _geralPersist = geralPersist;
            _productPersist = productPersist;
        }
        public async Task<ProductDTO> AddProduct(ProductDTO model)
        {
            try
            {
                var product = _mapper.Map<Product>(model);
                _geralPersist.Add(product);
                if (await _geralPersist.SaveChangesAsync())
                {
                    var productResponse = await _productPersist.GetProductByIdAsync(product.Id);
                    return _mapper.Map<ProductDTO>(productResponse);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProductDTO> UpdateProduct(int productId, ProductDTO model)
        {
            try
            {
                var product = await _productPersist.GetProductByIdAsync(model.Id);
                if (product == null)
                    return null;
                model.Id = productId;
                _mapper.Map(model, product);
                _geralPersist.Update(product);
                if (await _geralPersist.SaveChangesAsync())
                {
                    var productResponse = await _productPersist.GetProductByIdAsync(product.Id);
                    return _mapper.Map<ProductDTO>(productResponse);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                var product = await _productPersist.GetProductByIdAsync(productId);
                if (product == null)
                    throw new Exception("Produto para delete não encontrado.");
                _geralPersist.Delete(product);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}