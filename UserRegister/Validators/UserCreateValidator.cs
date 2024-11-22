using FluentValidation;
using UserRegister.Models;

namespace UserRegister.Validators
{
    public class UserCreateValidator : AbstractValidator<UserCreateDTO>
    {
        public UserCreateValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password)
                .NotEmpty()
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$") // Configurable
                .WithMessage("La contraseña debe tener al menos una letra mayúscula, una minúscula, un número y 8 caracteres.");
        }
    }
}
