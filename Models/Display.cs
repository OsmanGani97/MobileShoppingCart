using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMobileSite.Models
{
    [Table("Display")]
    public class Display
    {
        public int Id { get; set; }
        [Required]
        public string DisplayType { get; set; } = default!;
        [Required]
        public string ScreenSize { get; set; } = default!;
        [Required]
        public string Resolution { get; set; } = default!;
        [Required]
        public string AspectRatio { get; set; } = default!;
        [Required]
        public string PixelDensity { get; set; } = default!;
        [Required]
        public string ScreenProtection { get; set; } = default!;
        [Required]
        public string RefreshRate { get; set; } = default!;
        [Required]
        public string Notch { get; set; } = default!;
        public Mobile Mobile { get; set; }


    }
}
