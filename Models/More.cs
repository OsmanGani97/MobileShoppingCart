using System.ComponentModel.DataAnnotations.Schema;

namespace DMobileSite.Models
{
    [Table("More")]
    public class More
    {
        public int Id { get; set; }
        public string MadeBy { get; set; } = default!;
        public string Features { get; set; } = default!;
        public Mobile Mobile { get; set; }

    }
}
