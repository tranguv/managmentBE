
namespace server.Models
{
    public class DateTimeEntity
    {
        public DateTimeEntity CreatedDate { get; set; }
        public DateTimeEntity UpdatedDate { get; set; }

        public static explicit operator DateTimeEntity(DateTime v)
        {
            throw new NotImplementedException();
        }
    }
}
