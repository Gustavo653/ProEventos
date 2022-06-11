namespace ProEventos.Domain
{
    public class ProductConfiguration : Base
    {
        public ProductFilter Filter { get; set; }
        public Product Product { get; set; }
        public ProductGradeItem Item { get; set; }
    }
    public enum ProductGradeItem
    {
        ITEM1,
        ITEM2
    }
}
