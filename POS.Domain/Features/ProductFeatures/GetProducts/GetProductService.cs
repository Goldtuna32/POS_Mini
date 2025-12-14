

namespace POS.Domain.Features.ProductFeatures.GetProducts
{
    public class GetProductService
    {
        private readonly AppDbContext _db;

        public GetProductService(AppDbContext db)
        {
            _db = db;
        }

        //Get All Products (that are not deleted)
        public async Task<Result<List<GetProductResponse>>> GetProductAsync()
        {
            Result<List<GetProductResponse>> model;
            try
            {
                var products = await _db.ProductTables
                    .Where(p => p.DeleteFlag == false)
                    .Select(p => new GetProductResponse
                    {
                        productId = p.ProductId,
                        productCode = p.ProductCode,
                        productName = p.ProductName,
                        price = p.ProductPrice,
                        productCategoryCode = p.ProductCategoryCode
                    })
                    .ToListAsync();
                if (products == null || products.Count == 0)
                {
                    model = Result<List<GetProductResponse>>.NotFound("No products found.");
                    return model;
                }

                model = Result<List<GetProductResponse>>.Success(products, "Product fetched successfully");
                return model;

            }
            catch (Exception ex)
            {
                model = Result<List<GetProductResponse>>.Failure($"Error retrieving products: {ex.Message}");
            }
            return model;
        }

        //Get Product By Id (that is not deleted)
        public async Task<Result<GetProductResponse>> GetProductByIdAsync(GetProductRequest request)
        {
            Result<GetProductResponse> model;
            try
            {
                var product = await _db.ProductTables
                    .FirstOrDefaultAsync(p => p.ProductId == request.id && p.DeleteFlag == false);
                if (product is null)
                {
                    model = Result<GetProductResponse>.NotFound("Product not found.");
                    return model;
                }
                var productResponse = new GetProductResponse
                {
                    productId = product.ProductId,
                    productCode = product.ProductCode,
                    productName = product.ProductName,
                    price = product.ProductPrice,
                };
                model = Result<GetProductResponse>.Success(productResponse, "Product fetched successfully");
                return model;
            }
            catch (Exception ex)
            {
                model = Result<GetProductResponse>.Failure($"Error retrieving product: {ex.Message}");
            }
            return model;
        }

        //Get Products By Category Code (that are not deleted)
        public async Task<Result<List<GetProductResponse>>> GetProductByCategoryCodeAsync(GetProductRequest request)
        {
            Result<List<GetProductResponse>> model;
            try
            {
                var products = await _db.ProductTables
                    .Where(p => p.ProductCategoryCode == request.productCategoryCode && p.DeleteFlag == false)
                    .Select(p => new GetProductResponse
                    {
                        productId = p.ProductId,
                        productCode = p.ProductCode,
                        productName = p.ProductName,
                        price = p.ProductPrice,
                        productCategoryCode = p.ProductCategoryCode
                    })
                    .ToListAsync();
                if (products == null || products.Count == 0)
                {
                    model = Result<List<GetProductResponse>>.NotFound("No products found for the given category code.");
                    return model;
                }
                model = Result<List<GetProductResponse>>.Success(products, "Products fetched successfully");
                return model;
            }
            catch (Exception ex)
            {
                model = Result<List<GetProductResponse>>.Failure($"Error retrieving products: {ex.Message}");
            }
            return model;
        }

    }
}