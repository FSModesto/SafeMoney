using Application.ViewModel.Request.User;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Application.Validators.User
{
    public class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty()
                .MinimumLength(8)
                .WithMessage("Nome do usuário é obrigatório")
                .Matches(@"[a-zA-Z\u00C0-\u00FF ]")
                .WithMessage("Nome do usuário só aceita letras e espaços.")
                .MaximumLength(255);
            RuleFor(u => u.Email)
                .NotEmpty()
                .Matches(new Regex(@"[a-z0-9!#$%&'+/=?^_`{|}~-]+(?:.[a-z0-9!#$%&'+/=?^_`{|}~-]+)@(?:[a-z0-9](?:[a-z0-9-][a-z0-9])?.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?"))
                .WithMessage("O Email não é válido");
        }
    }
}
