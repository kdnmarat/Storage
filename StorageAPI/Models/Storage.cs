using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StorageAPI.Models
{
    [Table("Storages", Schema = "Storages")]
    public class Storage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public ulong Id { get; set; }

        [MaxLength(120)]
        public string? Name { get; set; }

        [MaxLength(500)]
        public string? KindOfStorage { get; set; }

        [MaxLength(500)]
        public string? Address { get; set; }
    }
}
