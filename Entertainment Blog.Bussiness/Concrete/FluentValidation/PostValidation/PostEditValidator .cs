using Entertainment_Blog.DTO.DTOs.PostDTO;
using FluentValidation;

namespace Entertainment_Blog.Bussiness.Concrete.FluentValidation.PostValidation
{
    public class PostEditValidator:AbstractValidator<PostEditDTO>
    {
        public PostEditValidator()
        {
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Post should have a title").MaximumLength(50);
            RuleFor(x => x.PublishDate).GreaterThanOrEqualTo(System.DateTime.Today).NotEmpty();
            RuleFor(x=>x.IsPublished).NotEmpty();
            RuleFor(x=>x.Thumbnail).NotEmpty().WithMessage("You have to add a thumbnail");
            RuleFor(x=>x.Summary).NotEmpty().WithMessage("You have to add a short content");
        }
    }
}
