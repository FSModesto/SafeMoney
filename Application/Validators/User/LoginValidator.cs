using Application.ViewModel.Request.User;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Application.Validators.User
{
    public class LoginValidator : AbstractValidator<LoginRequest>
    {
        public LoginValidator()
        {
            RuleFor(u => u.Password)
                .NotEmpty()
                .MinimumLength(8)
                .WithMessage("Senha é obrigatório")
                .Matches(@"[a-zA-Z\u00C0-\u00FF ]")
                .WithMessage("Senha do usuário só aceita letras e espaços.")
                .MinimumLength(8);
            RuleFor(u => u.Email)
                .NotEmpty()
                .Matches(new Regex(@"[a-z0-9!#$%&'+/=?^_`{|}~-]+(?:.[a-z0-9!#$%&'+/=?^_`{|}~-]+)@(?:[a-z0-9](?:[a-z0-9-][a-z0-9])?.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?"))
                .WithMessage("O Email não é válido");
        }
    }
}
