using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Dtos;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public ProductController(IGenericRepository<Product> productRepo,
                                 IGenericRepository<ProductType> productTypeRepo,
                                 IGenericRepository<ProductBrand> productBrandRepo,
                                 IMapper mapper
                                )
        {
            _productBrandRepo = productBrandRepo;
            _mapper = mapper;
            _productTypeRepo = productTypeRepo;
            _productRepo = productRepo;


        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts()
        {
            var spec = new ProductsWithTypesAndBrandsSpecification();
            var products =await _productRepo.ListAsync(spec);
            var data =_mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturnDTO>>(products);
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _productRepo.GetEntityWithSpec(spec);
            if (product == null) return NotFound();

             var data =_mapper.Map<Product,ProductToReturnDTO>(product);
            return Ok(data);
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