using System;
using System.Collections.Generic;
using System.Linq;
using Products.Models;
using Microsoft.AspNetCore.Mvc;

namespace Products.Controllers
{
    [Produces("application/json")]
    [Route("api/brand")]
    [ApiController]
    public class BrandController : Controller
    {
        private readonly BrandContext _context;

        // injected
        public BrandController(BrandContext context)
        {
            _context = context;
        }


        [HttpGet("all")]
        // GET api/brand/all
        public IEnumerable<BrandEntry> GetAllBrands()
        {
            var entries = _context.BrandEntry.OrderBy(e => e.BrandName);
            return entries;
        }

        [HttpGet("name/{name}", Name = "GetBrand")]
        // GET api/brand/name
        public IActionResult GetBrand(string brand)
        {
            // LINQ query, find matching entry for brand
            var entry = _context.BrandEntry.FirstOrDefault(e => e.BrandName.ToUpper() == brand.ToUpper());
            if (entry == null)
            {
                return NotFound();
            }
            return Ok(entry);
        }





    }
}
