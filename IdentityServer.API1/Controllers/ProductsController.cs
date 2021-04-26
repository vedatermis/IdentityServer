using System.Collections.Generic;
using IdentityServer.API1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.API1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        [Authorize("ReadProduct")]
        public IActionResult GetProducts()
        {
            var productList = new List<Product>
            {
                new() {Id = 1, Name = "Kalem", Price = 100, Stock = 500},
                new() {Id = 2, Name = "Silgi", Price = 100, Stock = 500},
                new() {Id = 3, Name = "Defter", Price = 100, Stock = 500},
                new() {Id = 4, Name = "Kitap", Price = 100, Stock = 500},
                new() {Id = 5, Name = "Bant", Price = 100, Stock = 500},
            };

            return Ok(productList);
        }

        [Authorize(policy: "UpdateOrCreate")]
        public IActionResult UpdateProduct(int id)
        {
            return Ok($"Id: {id} updated.");
        }

        [Authorize(policy: "UpdateOrCreate")]
        public IActionResult CreateProduct(Product product)
        {
            return Ok(product);
        }
    }
}
