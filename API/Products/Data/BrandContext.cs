using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Products;
namespace Products.Models
{
    public class BrandContext : DbContext
    {
        public BrandContext(DbContextOptions<BrandContext> options)
            : base(options)
        {
        }

        public DbSet<Products.BrandEntry> BrandEntry { get; set; }
        public DbSet<Products.ProductEntry> ProductEntry { get; set; }
    }
}
