using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Persistence
{
    public class ProductPersist : IProductPersist
    {
        private readonly ProEventosContext _context;
        public ProductPersist(ProEventosContext context)
        {
            _context = context;
        }
        public async Task<Product[]> GetAllProductsAsync()
        {
            IQueryable<Product> query = _context.Products;
            return await query.ToArrayAsync();
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            IQueryable<Product> query = _context.Products.Where(x => x.Id == productId);
            return await query.FirstOrDefaultAsync();
        }
    }
}
