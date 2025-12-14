namespace POS.Domain.Features.ProductCategory.CreateProductCategory
{
    public class CreateProductCategoryValidator : AbstractValidator<CreateProductCategoryRequest>
    {
        public CreateProductCategoryValidator() 
        {
            RuleFor(n => n.productCategoryCode)
                .NotEmpty().WithMessage("Product Category Code is required.")
                .MaximumLength(50).WithMessage("Product Category Code must not exceed 50 characters.");

            RuleFor(n => n.productCategoryName)
                .NotEmpty().WithMessage("Product Category Name is required.")
                .MaximumLength(50).WithMessage("Product Category Name must not exceed 50 characters.");

        }
    }
}
