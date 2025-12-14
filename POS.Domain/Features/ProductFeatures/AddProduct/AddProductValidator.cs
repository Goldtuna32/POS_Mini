namespace POS.Domain.Features.Product.AddProduct
{
    public class AddProductValidator : AbstractValidator<AddProductRequest>
    {
        public AddProductValidator() 
        {
            RuleFor(n=> n.ProductName)
                .NotEmpty().WithMessage("Product Name is required.")
                .MaximumLength(50).WithMessage("Product Name must not exceed 50 characters.");

            RuleFor(c => c.ProductCode)
                .NotEmpty().WithMessage("Product Code is required.")
                .MaximumLength(50).WithMessage("Product Code must not exceed 50 characters.");

            RuleFor(p => p.ProductPrice)
                .NotEmpty().WithMessage("Product Price is required.")
                .GreaterThan(0).WithMessage("Product Price must be greater than zero.");
                
            RuleFor(pc => pc.ProductCategoryCode)
                .NotEmpty().WithMessage("Product Category Code is required.")
                .MaximumLength(50).WithMessage("Product Category Code must not exceed 50 characters.");
        }
    }
}
