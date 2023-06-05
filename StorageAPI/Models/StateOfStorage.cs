using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StorageAPI.Models
{
    [Table("StatesOfStorages", Schema = "Storages")]
    public class StateOfStorage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; set; }

        // Foreign key for Product
        public uint ProductId { get; set; }
        public Product? Product { get; set; }

        // Foreign key for Storage
        public uint StorageId { get; set; }
        public Storage? Storage { get; set; }

        public ulong Quantity { get; set; }
    }
}
