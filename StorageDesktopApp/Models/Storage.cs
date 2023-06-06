using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageDesktopApp.Models
{
    public class Storage
    {

        public static List<Storage>? StoragesList;
        public uint Id { get; set; }
        public string? Name { get; set; }
        public string? KindOfStorage { get; set; }
        public string? Address { get; set; }
    }
}
