using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageDesktopApp.Models
{
    public class StateOfStorage
    {
        public uint Id { get; set; }
        public uint ProductId { get; set; }
        public Product? Product { get; set; }
        public uint StorageId { get; set; }
        public Storage? Storage { get; set; }
        public ulong Quantity { get; set; }
    }
}
