using FluentValidation;

namespace AuthenticationUser.Domain.Entities.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Title).NotEmpty().NotNull().WithMessage("Título não pode ser vazio");
        }
    }
}
