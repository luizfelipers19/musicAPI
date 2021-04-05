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
        //get all artists details
        //api/artists
        [HttpGet]
        public async Task<IActionResult> GetArtists()
        {
           var artists = await (from artist in _dbContext.Artists
            select new
            {
                Id = artist.Id,
                ArtistName = artist.Name,
                Image = artist.ImageUrl
            }).ToListAsync();

            return Ok(artists);
        }

        //get single artist detail
        //api/artists/artistdetails?artistId=2
        [HttpGet("[action]")]
        public async  Task<IActionResult> ArtistDetails(int artistId)
        {
            var artistDetails = await _dbContext.Artists.Where(a => a.Id == artistId).Include(a => a.Songs).ToListAsync();
            return Ok(artistDetails);
        }

    }
}
