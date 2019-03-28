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

        public DbSet<Products.Brand> Brand { get; set; }
        public DbSet<Products.Product> Product { get; set; }
    }
}
