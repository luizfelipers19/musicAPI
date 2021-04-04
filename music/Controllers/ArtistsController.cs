using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using music.Data;
using music.Helpers;
using music.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace music.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private ApiDbContext _dbContext;

        public ArtistsController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Artist artist)
        {
            

            var imageUrl = await FileHelper.UploadArtistImage(artist.Image);

            artist.ImageUrl = imageUrl;
            await _dbContext.Artists.AddAsync(artist);

            await _dbContext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status201Created);
        } 

    }
}
