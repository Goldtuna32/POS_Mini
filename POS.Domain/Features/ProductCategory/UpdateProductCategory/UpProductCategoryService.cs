namespace POS.Domain.Features.ProductCategory.UpdateProductCategory
{
    public class UpProductCategoryService
    {
        private readonly AppDbContext _db;

        public UpProductCategoryService(AppDbContext db)
        {
            _db = db;
        }

        //Update Product Category Name
        public async Task<Result<UpProductCategoryResponse>> UpdateProductCategory(UpProductCategoryRequest request)
        {
            Result<UpProductCategoryResponse> model;
            try
            {
                var item = await _db.ProductCategoryTables.FirstOrDefaultAsync(x => x.ProductCategoryId == request.id);
                if (item is null)
                {
                    model = Result<UpProductCategoryResponse>.NotFound("Product Category with this name can't found");
                }

                var result = await new UpProductCategoryValidator()
                    .ValidateAsync(request);
                if (result.Errors.Any())
                {
                    model = Result<UpProductCategoryResponse>.ValidationError("Validation error");
                    return model;
                }

                var updatedProduct = new ProductCategoryTable
                {
                    ProductCategoryName = request.productCategoryName
                };
                _db.Entry(updatedProduct).CurrentValues.SetValues(updatedProduct);
                await _db.SaveChangesAsync();

                model = Result<UpProductCategoryResponse>.Success("Product Category Name has been changed");
            }
            catch (Exception ex)
            {
                return Result<UpProductCategoryResponse>.Error($"Failed to update : {ex.Message}");
            }
            return model;
        }
    }
}
