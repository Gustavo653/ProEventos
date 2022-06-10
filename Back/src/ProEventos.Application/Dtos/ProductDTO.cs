using ProEventos.Application;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProEventos.Application.Dtos
{
    public class ProductDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public List<ProductConfigurationDTO> Configs { get; set; }
        public decimal Weight { get; set; }
    }
}
