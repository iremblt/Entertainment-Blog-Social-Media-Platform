using Entertainment_Blog.DTO.DTOs.CategoryDTO;
using FluentValidation;

namespace Entertainment_Blog.Bussiness.Concrete.FluentValidation.CategoryValidation
{
    public class CategoryAddValidator:AbstractValidator<CategoryAddDTO>
    {
        public CategoryAddValidator()
        {
            RuleFor(x => x.Name).NotEmpty()
                .WithMessage("Category name should be added!")
                .MaximumLength(20);
        }  
    }
}
