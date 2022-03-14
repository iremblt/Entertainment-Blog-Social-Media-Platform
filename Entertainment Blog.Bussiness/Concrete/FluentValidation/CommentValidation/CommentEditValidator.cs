using Entertainment_Blog.DTO.DTOs.CommentDTO;
using FluentValidation;

namespace Entertainment_Blog.Bussiness.Concrete.FluentValidation.CommentValidation
{
    public class CommentEditValidator:AbstractValidator<CommentEditDTO>
    {
        public CommentEditValidator()
        {
            RuleFor(x => x.Message).NotEmpty()
                .WithMessage("You cannot add empty comment!")
                .Matches("Fuck").WithMessage("Comment cannot contain insults");
        }
    }
}
