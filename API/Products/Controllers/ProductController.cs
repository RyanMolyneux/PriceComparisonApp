using System;
using System.Collections.Generic;
using System.Linq;
using Products.Models;
using Microsoft.AspNetCore.Mvc;

namespace Products.Controllers
{
    [Produces("application/json")]
    [Route("api/products")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly BrandContext _context;
      
        // injected
        public ProductController(BrandContext context)
        {
            _context = context;
        }
        

        [HttpGet("all")]
        // GET api/products/all
        public IEnumerable<ProductEntry> GetAllEntries()
        {
            var entries = _context.ProductEntry.OrderBy(e => e.Number);
            return entries;
        }

        [HttpGet("id/{Id}", Name = "GetEntry")]
        // GET api/product/id/01
        public IActionResult GetEntry(string number)
        {
            // LINQ query, find matching entry for number
            var entry = _context.ProductEntry.FirstOrDefault(e => e.Number.ToUpper() == number.ToUpper());
            if (entry == null)
            {
                return NotFound();
            }
            return Ok(entry);
        }

    }
}
