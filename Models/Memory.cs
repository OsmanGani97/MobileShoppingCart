using System.ComponentModel.DataAnnotations.Schema;

namespace DMobileSite.Models
{
    [Table("Memory")]
    public class Memory
    {
        public int Id { get; set; }
        public string InternalStorage { get; set; } = default!;
        public string StorageType { get; set; } = default!;
        public string RAM { get; set; } = default!;
        public string RAMType { get; set; } = default!;
      public Mobile Mobile { get; set; }

    }
}
