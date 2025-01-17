using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using server.Configurations;

namespace server.Models
{
    // [EntityTypeConfiguration(typeof(UserTypeConfiguration))]
    public class User
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(40)")]
        public string Username { get; set; } = string.Empty;
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Date of birth"), DataType(DataType.Date)]
        public DateTime? Dob { get; set; }
        public Role Role { get; set; }
    }
}
