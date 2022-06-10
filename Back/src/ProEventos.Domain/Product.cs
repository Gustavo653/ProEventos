using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProEventos.Domain
{
    public class Product : Base
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public List<ProductConfiguration> Configs { get; set; }
        public decimal Weight { get; set; }
    }
}
