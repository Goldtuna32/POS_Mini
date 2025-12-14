namespace POS.Domain.Features.Product.AddProduct
{
    public class AddProductRequest
    {

        public string ProductCode { get; set; } = string.Empty;

        public string ProductName { get; set; } = string.Empty;

        public decimal ProductPrice { get; set; }

        public string ProductCategoryCode { get; set; } = string.Empty;
    }
}
