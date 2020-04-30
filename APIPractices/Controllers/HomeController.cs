using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIPractices.Services.interfaces;
using APIPractices.Models;


namespace APIPractices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHomeServices _home;
        public HomeController(IHomeServices Home)
        {
            this._home = Home;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //_home.GetProductsVM("sp_products");
            var products = await _home.GetProductsVM("sp_products"); ;
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductsModel products)
        {
            return Ok(await _home.AddProduct(products));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductsModel products)
        {
            return Ok(await _home.UpdateProduct(products));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] ProductsModel products)
        {
            return Ok(await _home.DeleteProduct(products));
        }
    }
}