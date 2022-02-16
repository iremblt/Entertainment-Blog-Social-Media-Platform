using Entertainment_Blog.DTO.DTOs.UserDTO;
using FluentValidation;

namespace Entertainment_Blog.Bussiness.Concrete.FluentValidation.UserValidation
{
    public class RegisterValidator:AbstractValidator<RegisterDTO>
    {
        public RegisterValidator()
        {
            RuleFor(x=>x.UserName).NotEmpty().WithMessage("Username cannot be empty");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password cannot be empty")
                .MinimumLength(6).WithMessage("Password length shouldnt be less than 6")
                .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.");
            RuleFor(x=>x.Email).NotEmpty().WithMessage("Email cannot be empty").EmailAddress().WithMessage("Email address should be email address.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(x=>x.Name).Matches("^[A-Za-z]+$").WithMessage("Name should have characters only");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname cannot be empty");
            RuleFor(x => x.Surname).Matches("^[A-Za-z]+$").WithMessage("Surname should have characters only");
            RuleFor(x => x.DateOfBirth).LessThanOrEqualTo(System.DateTime.Today).WithMessage("Person's birthdate shouldn't future date");
        }
    }
}
