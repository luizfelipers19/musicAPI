using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Get()
        {
            // return _dbContext.Songs;
           return Ok(_dbContext.Songs);
           
        }

        // GET api/<SongsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var musica = _dbContext.Songs.Find(id);
            //return musica;
            if (musica == null)
            {
                return NotFound("Nenhum registro foi encontrado com esse ID");
            }
            return Ok(musica);

        }

        // POST api/<SongsController>
        [HttpPost]
        public IActionResult Post([FromBody] Song song)
        {
            _dbContext.Songs.Add(song);
            _dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<SongsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Song song)
        {
            var musica = _dbContext.Songs.Find(id);

            if (musica == null)
            {
                return NotFound("Seu registro não foi encontrado pelo ID passado");
            }
            else
            {
                musica.Title = song.Title;
                            musica.Language = song.Language;
                            _dbContext.SaveChanges();
                            return Ok("Registro atualizado com sucesso");
            }

            


        }

        // DELETE api/<SongsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            
            var musica =  _dbContext.Songs.Find(id);
            
            if (musica == null)
            {
                return NotFound("Seu registro não foi encontrado pelo ID passado");
            }
            else
            {
                _dbContext.Songs.Remove(musica);
                            _dbContext.SaveChanges();
                            return Ok("Registro deletado");
            }


            
            
        }
    }
}
