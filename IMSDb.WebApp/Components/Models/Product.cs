namespace IMSDb.WebApp.Components.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public float Price { get; set; }
    }
}
