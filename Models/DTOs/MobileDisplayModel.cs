using Humanizer.Localisation;

namespace DMobileSite.Models.DTOs
{
    public class MobileDisplayModel
    {
        public IEnumerable<Mobile> Mobiles { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public string STerm { get; set; } = "";
        public int BrandId { get; set; } = 0;
    }
}
