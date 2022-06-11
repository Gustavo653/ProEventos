using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Application.Contratos;
using ProEventos.Application.Dtos;
using ProEventos.Persistence.Contratos;
using System;
using System.Threading.Tasks;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IProductPersist _productPersist;
        public ProductController(IProductService productService, IProductPersist productPersist)
        {
            _productService = productService;
            _productPersist = productPersist;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var products = await _productPersist.GetAllProductsAsync();
                if (products == null)
                    return NoContent();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar produtos. Erro: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var product = await _productPersist.GetProductByIdAsync(id);
                if (product == null)
                    return NoContent();
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar product. Erro: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(ProductDTO model)
        {
            try
            {
                var evento = await _productService.AddProduct(model);
                if (evento == null)
                    return BadRequest("Erro ao tentar adicionar produto.");
                return Ok(evento);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar produto. Erro: {ex.Message}");
            }
        }
        [HttpPut]
        public async Task<IActionResult> Put(int id, ProductDTO model)
        {
            try
            {
                var evento = await _productService.UpdateProduct(id, model);
                if (evento == null)
                    return BadRequest("Erro ao tentar atualizar produto.");
                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar produtos. Erro: {ex.Message}");
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (await _productService.DeleteProduct(id))
                    return Ok("Deletado.");
                else
                    return BadRequest("Produto não deletado.");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar produto. Erro: {ex.Message}");
            }
        }
    }
}
