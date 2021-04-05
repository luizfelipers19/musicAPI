using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet]
        public async Task<IActionResult> GetAlbums(int? pageNumber, int? pageSize)
        {
            //setting default values if no value is passed as parameter to pageNumber and pageSize
            int currentPageNumber = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 5;

            var albums = await (from album in _dbContext.Albums
                                select new
                                {
                                    Id = album.Id,
                                    Name = album.Name,
                                    ImageUrl = album.ImageUrl
                                }).ToListAsync();
            //returns the results, paginated to the parameters passed in the url
            return Ok(albums.Skip((currentPageNumber - 1) * currentPageSize).Take(currentPageSize));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> AlbumDetails(int albumId)
        {
            var albumDetails = await _dbContext.Albums.Where(a => a.Id == albumId).Include(a => a.Songs).ToListAsync();
            return Ok(albumDetails);
        }
    }
}
