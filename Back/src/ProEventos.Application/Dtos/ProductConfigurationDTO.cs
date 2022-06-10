using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Application.Dtos
{
    public class ProductConfigurationDTO : BaseDTO
    {
        public ProductFilterDTO Filter { get; set; }
        public ProductDTO Product { get; set; }
        //public ProductGradeItem Item { get; set; }
    }
}
