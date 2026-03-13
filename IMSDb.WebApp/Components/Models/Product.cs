using System.ComponentModel.DataAnnotations;

namespace IMSDb.WebApp.Components.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be in the range 0 to 2,147,483,647")]
        public int Quantity { get; set; }
        public float Price { get; set; }
    }
}
