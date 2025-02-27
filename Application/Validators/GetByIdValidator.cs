using Application.ViewModel.Request;
using FluentValidation;

namespace Application.Validators
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
