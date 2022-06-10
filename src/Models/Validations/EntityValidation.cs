using FluentValidation;

namespace FluentResultTests.Models.Validations
{
    public class EntityValidation : AbstractValidator<Entity>
    {
        public EntityValidation()
        {
            RuleFor(e => e.Id)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
        }
    }
}
