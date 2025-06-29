using System.ComponentModel.DataAnnotations.Schema;

namespace DMobileSite.Models
{
    [Table("Stock")]
    public class Stock
    {
        public int Id { get; set; }
        public int MobileId { get; set; }
        public int Quantity { get; set; }

        public Mobile? Mobile { get; set; }
    }
}
