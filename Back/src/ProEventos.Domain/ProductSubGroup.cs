using System.Collections.Generic;

namespace ProEventos.Domain
{
    public class ProductSubGroup : Base
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public ProductGroup Group { get; set; }
    }
}
