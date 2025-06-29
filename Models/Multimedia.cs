using System.ComponentModel.DataAnnotations.Schema;

namespace DMobileSite.Models
{
    [Table("Multimedia")]
    public class Multimedia
    {
        public int Id { get; set; }

        public string Loudspeaker { get; set; } = default!;
        public string AudioJack { get; set; } = default!;
        public string Video { get; set; } = default!;
        public Mobile Mobile { get; set; }

    }
}
