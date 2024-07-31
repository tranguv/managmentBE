using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Display(Name = "Created Date"), DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Updated Date"), DataType(DataType.Date)]
        public DateTime UpdatedDate { get; set; }
        public int CreateUserID { get; set; }
        [ForeignKey("CreateUserID")]
        public User User { get; set; }
        [Range(1, (double)decimal.MaxValue, ErrorMessage = "Price must be greater than 0")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public ICollection<Product_Category> Product_Category { get; set; }
    }
}
