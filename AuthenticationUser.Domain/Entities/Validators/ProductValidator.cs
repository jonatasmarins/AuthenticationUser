using FluentValidation;

namespace AuthenticationUser.Domain.Entities.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Título não pode ser vazio");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Preço não pode ser zerado");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity não pode ser zerado");
            RuleFor(x => x.CategoryId).GreaterThan(0).WithMessage("Categoria inválida");
        }
    }
}
