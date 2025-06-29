using System.ComponentModel.DataAnnotations.Schema;

namespace DMobileSite.Models
{
    [Table("Design")]
    public class Design
    {
        public int Id { get; set; }
        public string Height { get; set; } = default!;
        public string Width { get; set; } = default!;
        public string Thickness { get; set; } = default!;
        public string Weight { get; set; } = default!;
        public string Build { get; set; } = default!;
        public string Colors { get; set; } = default!;
        public string Waterproof { get; set; } = default!;
        public string IPRating { get; set; } = default!;
        public string Ruggedness { get; set; } = default!;
        public Mobile Mobile {  get; set; }
    }
}
