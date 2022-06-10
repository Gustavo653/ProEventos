using ProEventos.Application;
using System.Collections.Generic;

namespace ProEventos.Application.Dtos
{
    public class ProductGroupDTO : BaseDTO
    {
        public string Name { get; set; }
        public List<ProductSubGroupDTO> SubGroups { get; set; }
    }
}
