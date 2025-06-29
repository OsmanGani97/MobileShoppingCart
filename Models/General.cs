using System.ComponentModel.DataAnnotations.Schema;

namespace DMobileSite.Models
{
    [Table("General")]
    public class General
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;
        public string Brand { get; set; } = default!;
        public string Model { get; set; } = default!;
        public DateTime ReleseDate { get; set; } = DateTime.UtcNow;
        public bool Available { get; set; }
        public  Mobile Mobile {  get; set; }

    }
}
