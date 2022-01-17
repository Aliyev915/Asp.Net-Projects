using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductWebApi.DTOs.CategoryDTOs
{
    public class CategoryPostDto
    {
        public string Name { get; set; }
    }
    public class CategoryPostDtoValidator : AbstractValidator<CategoryPostDto>
    {
        public CategoryPostDtoValidator()
        {
            RuleFor(x => x.Name).MaximumLength(25).MinimumLength(3).NotNull().NotEmpty();
        }
    }
}
