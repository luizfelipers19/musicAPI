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


        [HttpGet]
        public async Task<IActionResult>  GetAllSongs()
        {

            var songs = await (from song in _dbContext.Songs
                              select new
                              {
                                  Id = song.Id,
                                  Title = song.Title,
                                  Duration = song.Duration,
                                  Image = song.ImageUrl,
                                  AvailableAt = song.SongUrl
                              }).ToListAsync();
            return Ok(songs);
        }

        // GET api/<SongsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var musica = await _dbContext.Songs.FindAsync(id);
            //return musica;
            if (musica == null)
            {
                return NotFound("Nenhum registro foi encontrado com esse ID");
            }
            return Ok(musica);

        }



        [HttpGet("[action]")]
        public async Task<IActionResult> FeaturedSongs()
        {

            var songs = await (from song in _dbContext.Songs
                               where song.IsFeatured == true
                               select new
                               {
                                   Id = song.Id,
                                   Title = song.Title,
                                   Duration = song.Duration,
                                   Image = song.ImageUrl,
                                   AvailableAt = song.SongUrl
                               }).ToListAsync();
            return Ok(songs);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> NewSongs()
        {

            var songs = await (from song in _dbContext.Songs
                               orderby song.UploadedDate descending
                               select new
                               {
                                   Id = song.Id,
                                   Title = song.Title,
                                   Duration = song.Duration,
                                   Image = song.ImageUrl,
                                   AvailableAt = song.SongUrl
                               }).Take(10).ToListAsync();
            return Ok(songs);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> SearchSongs(string query)
        {

            var songs = await (from song in _dbContext.Songs
                               where song.Title.StartsWith(query)
                               select new
                               {
                                   Id = song.Id,
                                   Title = song.Title,
                                   Duration = song.Duration,
                                   Image = song.ImageUrl,
                                   AvailableAt = song.SongUrl
                               }).Take(10).ToListAsync();
            return Ok(songs);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> SongDetails(int songId)
        {
            var songDetails = await _dbContext.Songs.Where(s => s.Id == songId).ToListAsync();
            return Ok(songDetails);
        }

    }
}
