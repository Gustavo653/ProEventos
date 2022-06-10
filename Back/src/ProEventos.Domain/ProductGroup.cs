using System.Collections.Generic;

namespace ProEventos.Domain
{
    public class ProductGroup : Base
    {
        public string Name { get; set; }
        public List<ProductSubGroup> SubGroups { get; set; }
    }
}
