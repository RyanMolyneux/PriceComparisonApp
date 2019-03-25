using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Products
{
    public class ProductEntry
    {
        [Key]
        public string Number { get; set; }              // unique

        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [ForeignKey("Brand")]
        public string BrandNameFK { get; set; }
        

    }
}
