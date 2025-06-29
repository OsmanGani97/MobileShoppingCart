using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace DMobileSite.Models.DTOs
{
    public class MobileDTO
    {
        public int Id { get; set; }
        [Required]
        public string MobileName { get; set; } = default!;

        public string? Image { get; set; } = default!;
        [Required]
        public double Price { get; set; } = default!;
        [Required]
        public string Stroage { get; set; } = default!;
        [Required]
        public string Ram { get; set; } = default!;
        [Required]
        public string MainCamera { get; set; } = default!;
        [Required]
        public string ForntCamera { get; set; } = default!;
        [Required]
        public string Display { get; set; } = default!;
        [Required]
        public string Battery { get; set; } = default!;
        public string OperatingSystem { get; set; } = default!;
        [Required]
        public int BrandId { get; set; }
        public IFormFile? ImageFile { get; set; }
        public IEnumerable<SelectListItem>? BrandList { get; set; }
    }
}
