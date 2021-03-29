using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class ProductController : ControllerBase
    {

        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;

        public ProductController(IGenericRepository<Product> productRepo,
                                 IGenericRepository<ProductType> productTypeRepo,
                                 IGenericRepository<ProductBrand> productBrandRepo
                                )
        {
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
            _productRepo = productRepo;


        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts()
        {
            var spec = new ProductsWithTypesAndBrandsSpecification();
            var products =await _productRepo.ListAsync(spec);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _productRepo.GetEntityWithSpec(spec);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpGet("ProductType")]
        public async Task<ActionResult<ProductType>> GetAllProductTypes()
        {

            return Ok(await _productTypeRepo.ListAllAsync());
        }

        [HttpGet("ProductBrand")]
        public async Task<ActionResult<ProductType>> GetAllProductBrands()
        {

            return Ok(await _productBrandRepo.ListAllAsync());
        }


    }
}