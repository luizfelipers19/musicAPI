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
    public class AlbumsController : ControllerBase
    {


        private ApiDbContext _dbContext;

        public AlbumsController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Album album)
        {


            var imageUrl = await FileHelper.UploadAlbumImage(album.Image);

            album.ImageUrl = imageUrl;
            await _dbContext.Albums.AddAsync(album);

            await _dbContext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
