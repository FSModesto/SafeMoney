using Application.ViewModel.Request.User;
using FluentValidation;

namespace Application.Validators.User
{
    public class GetByIdValidator : AbstractValidator<GetUserByIdRequest>
    {
        public GetByIdValidator()
        {
            RuleFor(c => c.Id)
                .NotNull()
                .WithMessage("O Id é obrigatório");
        }
    }
}
