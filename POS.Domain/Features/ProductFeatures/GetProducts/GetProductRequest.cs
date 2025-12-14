namespace POS.Domain.Features.ProductFeatures.GetProducts
{
    public class GetProductRequest
    {
        public int id {  get; set; } 
        public string productCode { get; set; }
        public string productName { get; set; }
        public decimal price { get; set; }
        public string productCategoryCode { get; set; }

    }
}
