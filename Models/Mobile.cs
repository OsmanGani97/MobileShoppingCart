using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMobileSite.Models
{
    [Table("Mobile")]
    public class Mobile
    {
        public int Id { get; set; }
        [Required]
        public string MobileName { get; set; } = default!;
       
        public string? Image {  get; set; }= default!;
        [Required]
        public double Price {  get; set; } = default!;
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
        public   Brand Brands { get; set; } 
        //public List<Hardware_SoftWare> Hardware_SoftWare {  get; set; }
        public List<General> General { get; set; }
        public List<Camera> Camera { get; set; }
        public List<Display> Displays { get; set; }
        public List<Design> Designs {  get; set; }
        public List<Battery> Batterys {  get; set; }
        public List<Memory> Memory {  get; set; }
        public List<Network_Connectivity> Network_Connectivity {  get; set; }
        public List<Sensors_security> Sensors_security {  get; set; }
        public List<Multimedia> Multimedia {  get; set; }
        public List<More> More {  get; set; }
        public List<OrderDetail> OrderDetail { get; set; }
        public List<CartDetail> CartDetail { get; set; }
        public Stock Stock { get; set; }

        [NotMapped]
        public string BrandName { get; set; }
        [NotMapped]
        public int Quantity { get; set; }

    }
}
