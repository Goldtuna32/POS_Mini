namespace POS.Domain.Features.ProductCategory.UpdateProductCategory
{
    public class UpProductCategoryValidator : AbstractValidator<UpProductCategoryRequest>
    {
        public UpProductCategoryValidator() 
        {
            RuleFor(x => x.productCategoryName)
                .NotEmpty().WithMessage("Product Category Name can't be empty")
                .MaximumLength(50).WithMessage("Product Category name can't be too long");
        }
    }
}
