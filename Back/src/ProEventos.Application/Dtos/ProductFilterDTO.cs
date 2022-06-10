using System;

namespace ProEventos.Application.Dtos
{
    public class ProductFilterDTO : BaseDTO
    {
        public string Name { get; set; }
        public Guid ID_ProductConfiguration { get; set; }
        public ProductConfigurationDTO ProductConfiguration { get; set; }
    }
}