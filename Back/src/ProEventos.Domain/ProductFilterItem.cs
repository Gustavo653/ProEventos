namespace ProEventos.Domain
{
    public class ProductFilterItem : Base
    {
        public ProductFilter Parent { get; set; }
        public string Name { get; set; }
    }
}