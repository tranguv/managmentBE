using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        [Column(TypeName = "varchar(9)")]
        public DateTime UpdatedDate { get; set; }
        public int CreateUserID { get; set; }
        [ForeignKey("CreateUserID")]
        public User User { get; set; }
        public decimal Price { get; set; }
        public ICollection<Product_Category> Product_Category { get; set; }
    }
}
