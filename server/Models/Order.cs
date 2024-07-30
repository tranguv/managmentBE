using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public float TotalAmount { get; set; }
        public int Quantity { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreateUserID { get; set; }
        [ForeignKey("CreateUserID")]
        public User User { get; set; }
    }
}
