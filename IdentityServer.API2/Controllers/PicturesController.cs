using System.Collections.Generic;
using IdentityServer.API2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.API2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PicturesController: ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult GetPictures()
        {
            var pictures = new List<Picture>
            {
                new() {Id = 1, Name = "Doğa Resmi", Url = "resim1.jpg"},
                new() {Id = 2, Name = "Kedi Resmi", Url = "resim2.jpg"},
                new() {Id = 3, Name = "Köpek Resmi", Url = "resim3.jpg"},
                new() {Id = 4, Name = "Fil Resmi", Url = "resim4.jpg"},
                new() {Id = 5, Name = "Aslan Resmi", Url = "resim5.jpg"},
            };

            return Ok(pictures);
        }
    }
}
