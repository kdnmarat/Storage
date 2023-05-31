using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StorageAPI.Models
{
    [Table("Products", Schema = "Storages")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; set; }

        [MaxLength(120)]
        public string ?Name { get; set; }

        [Precision(12, 2)]
        public decimal Cost { get; set; }
    }
}