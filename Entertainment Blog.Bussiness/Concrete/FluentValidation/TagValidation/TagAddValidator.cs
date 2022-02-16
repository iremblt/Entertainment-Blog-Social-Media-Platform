using Entertainment_Blog.DTO.DTOs.TagDTO;
using FluentValidation;

namespace Entertainment_Blog.Bussiness.Concrete.FluentValidation.TagValidation
{
    public class TagAddValidator:AbstractValidator<TagAddOrEditDTO>
    {
        public TagAddValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("It cant be empty").MaximumLength(20);
        }
    }
}
