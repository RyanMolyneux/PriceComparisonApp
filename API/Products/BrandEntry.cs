using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Products
{
    public class BrandEntry
    {
        [Key]
        public string BrandName { get; set; } // unique

        [Required]
        public double Value { get; set; }

        public ICollection<ProductEntry> Products { get; set; }
    }
}
