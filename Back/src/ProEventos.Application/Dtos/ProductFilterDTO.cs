namespace ProEventos.Application.Dtos
{
    public class ProductFilterDTO : BaseDTO
    {
        public string Name { get; set; }
        public int ProductConfigurationId { get; set; }
        public ProductConfigurationDTO ProductConfiguration { get; set; }
    }
}