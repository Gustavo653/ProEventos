namespace ProEventos.Application.Dtos
{
    public class ProductGradeDTO : BaseDTO
    {
        public ProductDTO Product { get; set; }
        public ProductFilterDTO Item1 { get; set; }
        public ProductFilterDTO Item2 { get; set; }
        public ProductFilterDTO Item3 { get; set; }
        public ProductFilterDTO Item4 { get; set; }
    }
}
