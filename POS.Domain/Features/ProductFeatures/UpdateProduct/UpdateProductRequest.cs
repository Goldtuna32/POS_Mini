namespace POS.Domain.Features.ProductFeatures.UpdateProduct
{
    public class UpdateProductRequest
    {
        public int productId { get; set; }

        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }
    }
}
