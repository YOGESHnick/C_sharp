namespace ProductMicroservice.Models
{
    public class Product
    {
        public int Id { get; set; }  // EF Core will auto-increment this
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
