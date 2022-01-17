using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductWebApi.Data.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public double CostPrice { get; set; }
        public double SalePrice { get; set; }
        public string Image { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
