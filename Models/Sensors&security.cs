using NuGet.Protocol.Plugins;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMobileSite.Models
{
    [Table("Sensors_security")]
    public class Sensors_security
    {
        public int Id { get; set; }
        public string LightSensor { get; set; } = default!;
        public string FingerprintSensor { get; set; } = default!;
        public string FingerSensorPosition { get; set; } = default!;
        public string FingerSensorType { get; set; } = default!;
        public string FaceUnlock { get; set; } = default!;
      public Mobile Mobile { get; set; }

    }
}
