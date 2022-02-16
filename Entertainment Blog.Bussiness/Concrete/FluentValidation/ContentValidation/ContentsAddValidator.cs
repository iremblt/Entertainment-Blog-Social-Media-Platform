using Entertainment_Blog.DTO.DTOs.ContentDTO;
using FluentValidation;

namespace Entertainment_Blog.Bussiness.Concrete.FluentValidation.ContentValidatation
{
    public class ContentsAddValidator:AbstractValidator<ContentsAddDTO>
    {
        public ContentsAddValidator()
        {
            RuleFor(x=>x.Text).NotEmpty().WithMessage("You should enter the content");
            RuleFor(x=>x.Image).NotEmpty().WithMessage("You should upload the image of the content");
        }
    }
}
