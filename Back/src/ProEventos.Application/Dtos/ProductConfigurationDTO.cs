namespace ProEventos.Application.Dtos
{
    public class ProductConfigurationDTO : BaseDTO
    {
        public ProductFilterDTO Filter { get; set; }
        public ProductDTO Product { get; set; }
        //public ProductGradeItem Item { get; set; }
    }
}
