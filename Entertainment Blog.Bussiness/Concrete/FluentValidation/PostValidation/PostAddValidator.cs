using Entertainment_Blog.DTO.DTOs.PostDTO;
using FluentValidation;

namespace Entertainment_Blog.Bussiness.Concrete.FluentValidation.PostValidation
{
    public class PostAddValidator:AbstractValidator<PostAddDTO>
    {
        public PostAddValidator()
        {
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Post should have a title").MaximumLength(120);
            RuleFor(x => x.Thumbnail).NotEmpty().WithMessage("Post thumbnail should upload");
            RuleFor(x=>x.PublishDate).GreaterThanOrEqualTo(System.DateTime.Today).NotEmpty();        }
    }
}
