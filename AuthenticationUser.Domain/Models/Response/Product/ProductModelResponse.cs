namespace AuthenticationUser.Domain.Models.Response.Product
{
    public class ProductModelResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; }
    }
}
