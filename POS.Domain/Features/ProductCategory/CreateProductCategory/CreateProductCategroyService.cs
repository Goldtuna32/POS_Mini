namespace POS.Domain.Features.ProductCategory.CreateProductCategory
{
    public class CreateProductCategroyService
    {
        private readonly AppDbContext _db;

        public CreateProductCategroyService(AppDbContext db)
        {
            _db = db;
        }


        //Create Product Category
        public async Task<Result<CreateProductCategoryResponse>> CreateProductCategoryAsync(CreateProductCategoryRequest request)
        {
            Result<CreateProductCategoryResponse> model;

            try
            {
                var result = await new CreateProductCategoryValidator()
                    .ValidateAsync(request);

                if (result.Errors.Any())
                {
                    model = Result<CreateProductCategoryResponse>.ValidationError("Validation Failed");
                    return model;
                }

                var item = new ProductCategoryTable
                {
                    ProductCategoryName = request.productCategoryName,
                    ProductCategoryCode = request.productCategoryCode,
                };
                _db.ProductCategoryTables.Add(item);
                await _db.SaveChangesAsync();

                model = Result<CreateProductCategoryResponse>.Success("Product Category Created Successfully");
                
            }
            catch (Exception ex)
            {
                return Result<CreateProductCategoryResponse>.Error($"Failed to create product category + {ex.Message}");
            }
            return model;
        }
    }
}
