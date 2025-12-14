using POS.Database.AppDbContextModels;
using POS.Domain.Features.Product.AddProduct;
using POS.Domain.ResultPattern;

namespace POS.Domain.Features.ProductFeatures.AddProduct
{
    public class AddProductService
    {
        private readonly AppDbContext _dbContext;

        public AddProductService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<AddProductResponse>> AddProductAsync(AddProductRequest newProduct)
        {
            Result<AddProductResponse> model;
            try
            {
                var result = await new AddProductValidator()
                    .ValidateAsync(newProduct);
                if (result.Errors.Any())
                {
                    var errors = string.Join(", ", result.Errors.Select(e => e.ErrorMessage));
                    return Result<AddProductResponse>.ValidationError(errors);
                }

                var newProductModel = new ProductTable
                {
                    ProductName = newProduct.ProductName,
                    ProductCode = newProduct.ProductCode,
                    ProductPrice = newProduct.ProductPrice,
                    ProductCategoryCode = newProduct.ProductCategoryCode
                };

                _dbContext.ProductTables.Add(newProductModel);
                await _dbContext.SaveChangesAsync();

                model = Result<AddProductResponse>.Success("Product Created successfully");
            }
            catch (Exception ex)
            {
                return Result<AddProductResponse>.Error($"An error occurred while adding the product: {ex.Message}");
            }
            return model;
        }
    }
    }
