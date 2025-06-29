using System.ComponentModel.DataAnnotations.Schema;

namespace DMobileSite.Models
{
    [Table("Battery")]
    public class Battery
    {
        public int Id { get; set; }
        public string BatteryType { get; set; } = default!;
        public string Capacity { get; set; } = default!;
        public string QuickCharging { get; set; } = default!;
        public string USBTypeC { get; set; } = default!;
      public Mobile Mobile { get; set; }

    }
}
