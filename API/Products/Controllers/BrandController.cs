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
        public IQueryable GetAllBrands()
        {

            var result = from brand in _context.Brand
                         join prod in _context.Product on brand.BrandName equals prod.BrandName
                         select new
                         {
                             brand.BrandName,
                             brand.Value
                         };
            return result;

        }

        [HttpGet("{brandName}", Name = "GetBrand")]
        // GET api/brand/adidas
        public IActionResult GetBrand(string brandName)
        {
            // LINQ query, find matching entry for brand
            var entry = from brand in _context.Brand
                        join prod in _context.Product on brand.BrandName equals prod.BrandName
                        where brand.BrandName.ToUpper() == brandName.ToUpper()
                        select new
                        {
                            brand.BrandName,
                            brand.Value
                        };
            if (entry == null)
            {
                return NotFound();
            }
            return Ok(entry);
        }
    }
}
