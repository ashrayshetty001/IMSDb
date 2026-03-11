using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSDb.WebApp.Components.Models.Entities
{
    [Table("product_audits")]
    public class ProductAudit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Guid ProductId { get; set; }

        [MaxLength(100)]
        public string? ProductName { get; set; }

        [MaxLength(50)]
        public string? Action { get; set; } // "Create", "Update", "Delete"

        [MaxLength(100)]
        public string? ChangedBy { get; set; }

        public DateTime ChangedAt { get; set; } = DateTime.UtcNow;

        public int Quantity { get; set; }

        public float Price { get; set; }
    }
}
