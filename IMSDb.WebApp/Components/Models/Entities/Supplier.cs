using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSDb.WebApp.Components.Models.Entities
{
    [Table("suppliers")]
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string? Name { get; set; }

        [MaxLength(100)]
        public string? ContactPerson { get; set; }

        

        [MaxLength(20)]
        [RegularExpression(@"^\+?[0-9\s\-]{10,15}$", ErrorMessage = "pls enter correct phone number")]
        public string? Phone { get; set; }

        [MaxLength(100)]
        public string? Email { get; set; }

        [MaxLength(250)]
        public string? Address { get; set; }
        
        // Navigation Properties
        public ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();
    }
}
