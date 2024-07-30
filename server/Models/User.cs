using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    public class User
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(40)")]
        public string Username { get; set; } = string.Empty;
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; } = string.Empty;
        public DateTime Dob { get; set; }
        public Role Role { get; set; }
    }
}
