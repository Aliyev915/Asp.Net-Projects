using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductWebApi.DTOs.ProductDTOs
{
    public class ProductPostDto
    {
        public string Name { get; set; }
        public double CostPrice { get; set; }
        public double SalePrice { get; set; }
    }

    public class ProductPostDtoValidator : AbstractValidator<ProductPostDto>
    {
        public ProductPostDtoValidator()
        {
            RuleFor(x => x.Name).MaximumLength(100).MinimumLength(3).NotNull().NotEmpty();
            RuleFor(x => x.CostPrice).GreaterThanOrEqualTo(0);
            RuleFor(x => x.CostPrice).GreaterThan(0);
            RuleFor(x => x).Custom((x,context) =>
            {
                if (x.SalePrice < x.CostPrice)
                {
                    context.AddFailure("Sale Price must not less than Cost Price");
                }
            });
            


        }
    }
}
