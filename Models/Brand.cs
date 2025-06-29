using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMobileSite.Models
{
    [Table("Brand")]
    public class Brand
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string BrandName { get; set; } = default!;
        public List<Mobile> Mobiles { get; set; } 
    }
}
