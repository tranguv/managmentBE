using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [Range(1, (double)decimal.MaxValue, ErrorMessage = "Price must be greater than 0")]
        [DataType(DataType.Currency)]
        public decimal TotalAmount { get; set; }
        // public int Quantity { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "Created Date"), DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Updated Date"), DataType(DataType.Date)]
        public DateTime UpdatedDate { get; set; }
        public int CreateUserID { get; set; }
        [ForeignKey("CreateUserID")]
        public User User { get; set; }
    }
}
