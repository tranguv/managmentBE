using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
        public ICollection<Product_Category> Product_Category { get; set; }
    }
}
