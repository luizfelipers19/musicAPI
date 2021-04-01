using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        private static List<Song> songs = new List<Song>()
        {
            new Song(){Id = 0, Title="Cabeça de Gelo", Language = "Português" } ,
            new Song(){Id = 1, Title="Estilo Cachorro", Language = "Português" } ,
           
        };

        [HttpGet]
        public IEnumerable<Song> Get()
        {

            return songs;
        }

        [HttpPost]
        public void Post([FromBody]Song song)
        {
            songs.Add(song);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Song song)
        {
            songs[id] = song;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            songs.RemoveAt(id);
        }
    }
}
