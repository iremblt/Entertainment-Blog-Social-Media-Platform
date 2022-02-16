using Entertainment_Blog.DTO.DTOs.UserDTO;
using FluentValidation;

namespace Entertainment_Blog.Bussiness.Concrete.FluentValidation.UserValidation
{
    public class SignInValidator:AbstractValidator<SignInDTO>
    {
        public SignInValidator()
        {
            RuleFor(x=>x.Password).NotEmpty().WithMessage("Password cannot be empty")
                .MinimumLength(6).WithMessage("Password length shouldnt be less than 6");
            RuleFor(x=>x.Email).EmailAddress().WithMessage("Email address should be email address.");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Confirm your password");
            RuleFor(x => x.ConfirmPassword).Matches(x => x.Password).WithMessage("Password and ConfirmPassword are not matches");
        }
    }
}
