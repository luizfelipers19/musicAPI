using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using music.Data;
using music.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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


        // GET: api/<SongsController>
        [HttpGet]
        public async Task<IActionResult>  Get()
        {
            // return _dbContext.Songs;
           return Ok(await _dbContext.Songs.ToListAsync());
           
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

        // POST api/<SongsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Song song)
        {
            await _dbContext.Songs.AddAsync(song);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<SongsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult>  Put(int id, [FromBody] Song song)
        {
            var musica = await _dbContext.Songs.FindAsync(id);

            if (musica == null)
            {
                return NotFound("Seu registro não foi encontrado pelo ID passado");
            }
            else
            {
                musica.Title = song.Title;
                            musica.Language = song.Language;
                musica.Duration = song.Duration;
                          await  _dbContext.SaveChangesAsync();
                            return Ok("Registro atualizado com sucesso");
            }

            


        }

        // DELETE api/<SongsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult>  Delete(int id)
        {
            
            var musica = await _dbContext.Songs.FindAsync(id);
            
            if (musica == null)
            {
                return NotFound("Seu registro não foi encontrado pelo ID passado");
            }
            else
            {
                            _dbContext.Songs.Remove(musica);
                           await _dbContext.SaveChangesAsync();
                            return Ok("Registro deletado");
            }


            
            
        }
    }
}
