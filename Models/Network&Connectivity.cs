using System.ComponentModel.DataAnnotations.Schema;

namespace DMobileSite.Models
{
    [Table("Network_Connectivity")]
    public class Network_Connectivity
    {
        public int Id { get; set; }
        public string Network { get; set; } = default!;
        public string SimSlot { get; set; } = default!;
        public string SimSize { get; set; } = default!;
        public string Speed { get; set; } = default!;
        public string SarValue { get; set; } = default!;
        public string WLAN { get; set; } = default!;
        public string Bluetooth { get; set; } = default!;
        public string GPS { get; set; } = default!;
        public string WifiHotspot { get; set; } = default!;
        public string USB { get; set; } = default!;
        public Mobile Mobile {  get; set; }

    }
}
