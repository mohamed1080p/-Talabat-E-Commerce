using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ProductModule
{
    public class Product:BaseEntity<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string PictureUrl { get; set; } = string.Empty;
        public decimal Price { get; set; }


        public ProductType productType { get; set; }
        public int TypeId { get; set; }


        public ProductBrand productBrand { get; set; }
        public int BrandId { get; set; }
    }
}
