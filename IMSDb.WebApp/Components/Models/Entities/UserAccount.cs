using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace IMSDb.WebApp.Components.Models.Entities
{
    [Table("user_accounts")]
    public class UserAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("UserName")]
        [MaxLength(100)]
        public string? UserName { get; set; }

        [Column("Password")]
        [MaxLength(100)]
        public string? Password { get; set; }

        [Column("Role")]
        [MaxLength(50)]
        public string? Role { get; set; }  


    }
}
