using Domain.Entities.ProductModule;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction.Contracts;
using Shared.Dtos;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IServiceManager _serviceManager) : ControllerBase
    {
        //Get All Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResultDto>>> GetAllProductsAsync()
        {
            return Ok(await _serviceManager.ProductService.GetAllProductsAsync());
        }

        //Get All Brands
        [HttpGet("Brands")]
        public async Task<ActionResult<IEnumerable<BrandResultDto>>> GetAllBrandsAsync()
        {
            return Ok(await _serviceManager.ProductService.GetAllBrandsAsync());
        }


        //Get All Types
        [HttpGet("Types")]
        public async Task<ActionResult<IEnumerable<TypeResultDto>>> GetAllTypesAsync()
        {
            return Ok(await _serviceManager.ProductService.GetAllTypesAsync());
        }


        //Get Product By Id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductResultDto>>GetProductById(int id)
        {
            return Ok(await _serviceManager.ProductService.GetProductByIdAsync(id));
        }
        
    }
}
