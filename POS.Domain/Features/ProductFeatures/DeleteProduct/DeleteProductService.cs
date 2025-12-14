using Microsoft.EntityFrameworkCore;
using POS.Domain.ResultPattern;

namespace POS.Domain.Features.ProductFeatures.DeleteProduct
{
    public class DeleteProductService
    {
        private readonly AppDbContext _db;

        public DeleteProductService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Result<DeleteProductResponse>> DeleteProductAsync(DeleteProductRequest request)
        {
            Result<DeleteProductResponse> model;

            try
            {
                var product = await _db.ProductTables.FirstOrDefaultAsync(p => p.ProductId == request.Id);
                if (product is null)
                {
                    model = Result<DeleteProductResponse>.NotFound("Product not found.");
                    return model;
                }
                product.DeleteFlag = true;
                _db.Entry(product).State = EntityState.Deleted;
                await _db.SaveChangesAsync();

                model = Result<DeleteProductResponse>.Success("Product deleted successfull");
                return model;

            }
            catch (Exception ex)
            {
                model = Result<DeleteProductResponse>.Failure($"Error deleting product: {ex.Message}");
            }
            return model;
        }
    }
}
