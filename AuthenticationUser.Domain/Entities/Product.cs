using AuthenticationUser.Shared.Entities;
using Flunt.Validations;

namespace AuthenticationUser.Domain.Entities
{    
    public class Product : Entity
    {
        public Product(string title, string description, decimal price, int quantity, int categoryId)
        {
            Title = title;
            Description = description;
            Price = price;
            Quantity = quantity;
            CategoryId = categoryId;                        
        }
        
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }        
        public Category Category { get; set; }
    }
}
