namespace MyProduct.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        
        public decimal Price { get; set; }

        public int CategoryId { get; set; } //foreign key para Category

        public Category? Category { get; set; } //navegation property para Category
    }
}
