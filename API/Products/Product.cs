using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Products
{
    public class Product
    {
        [Key]
        public int id { get; set; }              // unique

        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }
      
        public string BrandName { get; set; }
        public Brand Brand { get; set; }
        
    }
}
