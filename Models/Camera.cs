using System.ComponentModel.DataAnnotations.Schema;

namespace DMobileSite.Models
{
    [Table("Camera")]
    public class Camera
    {
        public int Id { get; set; }
        public string PrimaryCameraSetup { get; set; } = default!;
        public string Resolution { get; set; } = default!;
        public string AutoFocus { get; set; } = default!;
  
        public string Flash { get; set; } = default!;
        public string ImageResolution { get; set; } = default!;
        public string Settings { get; set; } = default!;
        public string Zoom { get; set; } = default!;
        public string CameraFeatures { get; set; } = default!;
        public string VideoRecording { get; set; } = default!;
        public string SelfieCameraSetup { get; set; } = default!;
        public string SelfieCameraResolution { get; set; } = default!;
        public string SelfieCameraVideoRecording { get; set; } = default!;
        public string SelfieCameraVideoFPS { get; set; } = default!;
        public string SelfieCameraAperture { get; set; } = default!;
      public Mobile Mobile { get; set; }

    }
}
