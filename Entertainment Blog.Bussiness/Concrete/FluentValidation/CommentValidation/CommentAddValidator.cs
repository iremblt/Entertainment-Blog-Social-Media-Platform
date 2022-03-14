using Entertainment_Blog.DTO.DTOs.CommentDTO;
using FluentValidation;

namespace Entertainment_Blog.Bussiness.Concrete.FluentValidation.CommentValidation
{
    public class CommentAddValidator:AbstractValidator<CommentAddDTO>
    {
        public CommentAddValidator()
        {
            RuleFor(x => x.Message).NotEmpty()
                .WithMessage("You cannot add empty comment!");
            RuleFor(x=>x.Message).Matches("Fuck").WithMessage("Comment cannot contain insults");
            RuleFor(x => x.UserId).NotEmpty()
                .WithMessage("User cannot leave comments without login");
        }
    }
}
