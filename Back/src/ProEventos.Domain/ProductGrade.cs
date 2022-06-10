namespace ProEventos.Domain
{
    public class ProductGrade : Base
    {
        public Product Product { get; set; }
        public ProductFilter Item1 { get; set; }
        public ProductFilter Item2 { get; set; }
        public ProductFilter Item3 { get; set; }
        public ProductFilter Item4 { get; set; }
    }
}
