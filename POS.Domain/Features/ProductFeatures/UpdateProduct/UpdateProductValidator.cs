namespace POS.Domain.Features.ProductFeatures.UpdateProduct
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductValidator()
        {
            RuleFor(n => n.ProductName)
                .NotEmpty().WithMessage("Product Name is required.")
                .MaximumLength(50).WithMessage("Product Name must not exceed 50 characters.");
            RuleFor(p => p.ProductPrice)
                .NotEmpty().WithMessage("Product Price is required.")
                .GreaterThan(0).WithMessage("Product Price must be greater than zero.");
        }
    }
}
