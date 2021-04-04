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
    public class SongsController : ControllerBase
    {

        private ApiDbContext _dbContext;

        public SongsController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        //public async Task<IActionResult> Post([FromForm] Song song)
        //{
        //    var imageUrl = await FileHelper.UploadImage(song.Image);
        //    song.ImageUrl = imageUrl;

        //    var audioUrl = await FileHelper.UploadFile(song.AudioFile);
        //    song.AudioUrl = audioUrl;

        //    song.UploadedDate = DateTime.Now;

        //    await _dbContext.Songs.AddAsync(song);
        //    await _dbContext.SaveChangesAsync();

        //    return StatusCode(StatusCodes.Status201Created);


        //}


        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Song song)
        {


            var imageUrl = await FileHelper.UploadSongImage(song.Image);
            song.ImageUrl = imageUrl;

            song.UploadedDate = DateTime.Now;
            await _dbContext.Songs.AddAsync(song);

            await _dbContext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status201Created);
        }

    }
}
