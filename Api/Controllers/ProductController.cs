using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ShopAppDbContext _context;
        public ProductController(ShopAppDbContext context)
        {
            _context = context;
           
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAll(){

            return await _context.Products.ToListAsync();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id){

            var product = await _context.Products.FindAsync(id);
            if(product==null) return NotFound();
            return Ok(product);
        }

       
    }
}