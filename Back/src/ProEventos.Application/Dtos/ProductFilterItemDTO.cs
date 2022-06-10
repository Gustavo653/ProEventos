namespace ProEventos.Application.Dtos
{
    public class ProductFilterItemDTO : BaseDTO
    {
        public ProductFilterDTO Parent { get; set; }
        public string Name { get; set; }
    }
}