using FluentValidation;
using Movies.Core.Requests.Login;

namespace Movies.Core.Validators.Login;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.EmailOrUsername)
            .NotEmpty().WithMessage("Email não pode estar vazio!");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Senha não pode estar vazia!");
    }
}
