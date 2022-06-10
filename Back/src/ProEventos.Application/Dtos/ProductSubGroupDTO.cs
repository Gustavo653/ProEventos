using System.Collections.Generic;

namespace ProEventos.Application.Dtos
{
    public class ProductSubGroupDTO : BaseDTO
    {
        public string Name { get; set; }
        public List<ProductDTO> Products { get; set; }
        public ProductGroupDTO Group { get; set; }
    }
}
