using FluentValidation;
using Movies.Common;
using Movies.Core.Requests.Users;


namespace Movies.Core.Validators.User;

public class UserCreateRequestValidator : AbstractValidator<UserCreateRequest>
{
    public UserCreateRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email é um campo obrigatório!")
            .MinimumLength(5).WithMessage("Email deve ter pelo menos 5 caracteres!")
            .MaximumLength(60).WithMessage("Email deve ter no máximo 60 caracteres");

        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("Nome de usuário é um campo obrigatório!")
            .MinimumLength(5).WithMessage("Nome de usuário deve ter pelo menos 5 caracteres!")
            .MaximumLength(45).WithMessage("Nome de usuário deve ter no máximo 45 caracteres");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Senha é um campo obrigatório!")
            .Matches(CommonRegex.Password).WithMessage("Senha inválida!");
    }
}
