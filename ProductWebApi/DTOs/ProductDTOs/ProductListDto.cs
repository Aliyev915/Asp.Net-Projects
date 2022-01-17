using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductWebApi.DTOs.ProductDTOs
{
    public class ProductListDto:ProductListItemDto
    {
        public int Count { get; set; }
        public bool HasNext { get; set; }
        public bool HasPrev { get; set; }
        public int Page { get; set; }

    }

    public class ProductListItemDto
    {
        public string Name { get; set; }
        public double SalePrice { get; set; }
        public double CostPrice { get; set; }
        public string CategoryName { get; set; }
    }
}
