using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageDesktopApp.Models
{
    public class Product
    {
        public static List<Product>? ProductsList;

        public uint Id { get; set; }
        public string? Name { get; set; }
        public decimal Cost { get; set; }
    }
}
