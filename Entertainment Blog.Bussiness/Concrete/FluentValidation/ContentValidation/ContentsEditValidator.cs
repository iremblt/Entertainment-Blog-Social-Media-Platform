using Entertainment_Blog.DTO.DTOs.ContentDTO;
using FluentValidation;

namespace Entertainment_Blog.Bussiness.Concrete.FluentValidation.ContentValidatation
{
    public class ContentsEditValidator:AbstractValidator<ContentsEditDTO>
    {
        public ContentsEditValidator()
        {
            RuleFor(x=>x.Text).NotEmpty().WithMessage("You should enter the content");
        }
    }
}
