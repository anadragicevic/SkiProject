using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repo)
        {
            _repo = repo;

        }

        [HttpGet]

        public async Task<ActionResult<List<Product>>> GetProducts(){

            return Ok(await _repo.GetProductsAsync());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Product>> GetProduct(int id){

            return await _repo.GetProductByIdAsync(id);
        }

        [HttpGet("brands")]

        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands(){
            
            return Ok(await _repo.GetProductBrandsAsync());    
               
            
             }
    

        [HttpGet("types")]

        public async Task<ActionResult<List<ProductType>>> GetProductTypes(){
            
            return Ok(await _repo.GetProductTypesAsync());
        }
}
}
