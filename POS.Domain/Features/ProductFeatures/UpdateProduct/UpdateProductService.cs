using Microsoft.EntityFrameworkCore;
using POS.Domain.ResultPattern;

namespace POS.Domain.Features.ProductFeatures.UpdateProduct
{
    public class UpdateProductService
    {
        private readonly AppDbContext _db;

        public UpdateProductService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Result<UpdateProductResponse>> UpdateProductAsync(int productId,UpdateProductRequest request)
        {
            Result<UpdateProductResponse> model;

            try
            {
                var result = await new UpdateProductValidator()
                    .ValidateAsync(request);

                if (result.Errors.Any())
                {
                    var errors = result.Errors
                        .Select(e => e.ErrorMessage)
                        .ToList();
                    model = Result<UpdateProductResponse>.ValidationError(
                        "Validation errors occurred.");
                    return model;
                }
                var item = await _db.ProductTables.FirstOrDefaultAsync(x=> x.ProductId == productId);
                if (item is null)
                {
                    model =  Result<UpdateProductResponse>.NotFound("Product not found.");
                    return model;
                }
                var productModel = new ProductTable
                {
                    ProductName = request.ProductName,
                    ProductPrice = request.ProductPrice
                };
                _db.Entry(item).CurrentValues.SetValues(productModel);
                await  _db.SaveChangesAsync();

                model = Result<UpdateProductResponse>.Success("Product updated successfully.");
            }
            catch (Exception ex)
            {
                model = Result<UpdateProductResponse>.Failure($"An error occurred while updating the product: {ex.Message}");
            }
            return model;
        }
    }
}
