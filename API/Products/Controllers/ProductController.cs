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
        public IQueryable GetAllEntries()
        {
            var result = from prod in _context.Product
                         join brand in _context.Brand on prod.BrandName equals brand.BrandName
                         select new
                         {
                             prod.id,
                             prod.Name,
                             prod.Price,
                             prod.BrandName
                         };
            return result;
        }

    }
}
