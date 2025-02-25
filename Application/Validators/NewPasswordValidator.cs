using Application.ViewModel.Request;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Application.Validators
{
    public class NewPasswordValidator : AbstractValidator<ResetPasswordEmailRequest> 
    {
        public NewPasswordValidator() 
        {
            RuleFor(u => u.NewPassword)
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
